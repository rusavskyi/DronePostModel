using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;
using CoreService;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace CoreHost
{
    class Core : ICore
    {
        private readonly IMessageHandler _messageHandler;

        // For database
        private readonly DronePostContext _db;

        //For hosting
        private ServiceHost _host;
        private readonly string coreAddress = "http://localhost:8888/Core";

        //Additional
        private bool _isWorking;
        private Queue<CoreTask> _tasks;
        private SortedList<int, DroneTechInfo> _lastDroneTechInfosUpdate; // <droneId, droneInfo>
        private SortedList<int, StationTechInfo> _lasStationTechInfosUpdate;

        public Core(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
            _db = new DronePostContext();
        }

        public void StartHost()
        {
            Uri baseAddress = new Uri(coreAddress);
            _host = new MyServiceHost(this, typeof(CoreService.CoreService), baseAddress);

            try
            {
                _tasks = new Queue<CoreTask>();
                _host.AddServiceEndpoint(typeof(ICoreService), new WSHttpBinding(), "");
                ServiceMetadataBehavior bechavior = new ServiceMetadataBehavior() { HttpGetEnabled = true };
                _host.Description.Behaviors.Add(bechavior);
                _host.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
                _host.Open();
                Log("Core has started on address: " + baseAddress);
            }
            catch (Exception e)
            {
                Log("Error: " + e.Message);
            }
        }

        public void StopHost()
        {
            try
            {
                _host.Close();
                Log("Core has stopped");
            }
            catch (Exception e)
            {
                Log("Error: " + e.Message);
            }
            _isWorking = false;
        }

        public void Test()
        {
            //try
            //{
            //    /*
            //     string address = "http://localhost:4999/Drone/2";
            //    DroneServiceClient _client =
            //        new DroneServiceClient(new WSHttpBinding(), new EndpointAddress(new Uri(address)));
            //    _client.DoNextTask(true);
            //    */

            //    string address = "http://localhost:5000/Station/2";
            //    StationServiceClient _client =
            //        new StationServiceClient(new WSHttpBinding(), new EndpointAddress(new Uri(address)));
            //    _client.DoNextTask(true);

            //}
            //catch (Exception e)
            //{
            //    Log("ERROR: " + e.Message);
            //}
            Log("Test started...");
            StartSimulation();

        }



        // need testing

        public Package RegisterPackage(GeneratedPackage package)
        {
            Package result = new Package
            {
                DestinationStation = _db.Stations.First(s => s.Id == package.DestinationStationId),
                RecipientPhoneNumber = package.RecipientNumber,
                Size = _db.PackageSizes.First(ps => ps.Id == package.PackageSizeId),
                Weight = package.PackageWeight
            };

            _db.Packages.Add(result);
            _db.SaveChanges();

            result = _db.Packages.Include("DestinationStation").Include("Size").First(p =>
                p.DestinationStation.Id == package.DestinationStationId &&
                p.RecipientPhoneNumber == package.RecipientNumber &&
                p.Size.Id == package.PackageSizeId &&
                p.Weight == package.PackageWeight);

            Customer customer = _db.Customers.First(c => c.Id == package.SenderId);

            if (customer != null)
            {
                _db.CustomerPackages.Add(new CustomerPackage { Package = result, Sender = customer });
            }
            else
            {
                if (_db.Customers.Count() > package.SenderId)
                {
                    customer = _db.Customers.ToList()[package.SenderId];
                }
                else
                {
                    customer = _db.Customers.ToList()[0];
                }
                _db.CustomerPackages.Add(new CustomerPackage { Package = result, Sender = customer });
            }

            _db.SaveChanges();

            Transfer transfer = new Transfer()
            {
                ArrivalStation = _db.Stations.First(s => s.Id == package.DestinationStationId),
                ArrivalTime = DateTime.Now,
                Package = result
            };

            Log("Package from " + customer.Id + " to " + package.RecipientNumber + " registred with id: " + result.Id + ".");
            RegisterTransfer(transfer);
            return result;
        }

        public int RegisterTransfer(Transfer transfer)
        {
            Log("Transfer registred.");
            if (transfer.Drone != null)
            {
                DronePost.DataModel.Drone droneInBase = _db.Drones.Include("Model").First(d => d.Id == transfer.Drone.Id);
                droneInBase.Latitude = transfer.Drone.Latitude;
                droneInBase.Longitude = transfer.Drone.Longitude;
                _db.SaveChanges();
                transfer.Drone = droneInBase;
            }

            if (transfer.ArrivalStation != null)
            {
                DronePost.DataModel.Station stationInBase = _db.Stations.First(s => s.Id == transfer.ArrivalStation.Id);
                transfer.ArrivalStation = stationInBase;
            }
            if(transfer.DepartureStation != null)
            {
                DronePost.DataModel.Station stationInBase = _db.Stations.First(s => s.Id == transfer.DepartureStation.Id);
                transfer.DepartureStation = stationInBase;
            }

            _db.Transfers.Add(transfer);
            _db.SaveChanges();
            return 0;
        }

        public int RegisterDrone(Drone drone)
        {
            _db.Drones.Add(drone);
            _db.SaveChanges();
            Log("Drone registred.");
            return 0;
        }

        public int RegisterStation(Station station)
        {
            _db.Stations.Add(station);
            _db.SaveChanges();
            Log("Station registred.");
            return 0;
        }

        public int RegisterCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            Log("Customer registred.");
            return 0;
        }

        public void SendDroneOnCharge(int idDrone)
        {
            // todo set task for drone to charge at station
            throw new NotImplementedException();
            int stationId = FindClosestStation(0, 0);
        }

        public void RequestDroneForPackage(Package package)
        {
            // todo add task for drone to take package
            throw new NotImplementedException();
            // select drones with less tasks
            // find closest
            // give task to get package
        }

        public void RequestDroneForPackages(params Package[] packages)
        {
            foreach (Package package in packages)
            {
                RequestDroneForPackage(package);
            }
        }

        public List<Drone> GetDrones()
        {
            Log("GetDrones request...");
            List<Drone> drones = null;
            try
            {
                drones = _db.Drones.Include("Model").Include("Model.MaxSizeCarry").ToList();
            }
            catch (Exception e)
            {
                Log("Error: " + e.Message + "\nStack trace: " + e.StackTrace);
            }
            return drones;
        }

        public List<Station> GetStations()
        {
            Log("GetStatios request...");
            List<Station> stations = null;
            try
            {
                stations = _db.Stations.ToList();
            }
            catch (Exception e)
            {
                Log("Error: " + e.Message + "\nStack trace: " + e.StackTrace);
            }
            return stations;
        }

        public List<Customer> GetCustomers()
        {
            Log("GetCustomers request...");
            List<Customer> customers = null;
            try
            {
                customers = _db.Customers.Include("City").ToList();
            }
            catch (Exception e)
            {
                Log("Error: " + e.Message + "\nStack trace: " + e.StackTrace);
            }
            return customers;
        }

        public List<PackageSize> GetSizes()
        {
            Log("GetSizes request...");
            List<PackageSize> sizes = null;
            try
            {
                sizes = _db.PackageSizes.ToList();
            }
            catch (Exception e)
            {
                Log("Error: " + e.Message + "\nStack trace: " + e.StackTrace);
            }
            return sizes;
        }

        public void StartSimulation()
        {
            Log("Starting simulation thread...");
            Thread thread = new Thread(Simulation);
            thread.Start();
        }

        private void Simulation()
        {
            _isWorking = true;
            Log("Simulation started.");

            List<Drone> drones = _db.Drones.Include("Model").ToList();
            Random random = new Random(DateTime.Now.GetHashCode());
            int max = _db.Stations.ToList().Count;
            foreach (Drone drone in drones)
            {
                string address = "http://localhost:4999/Drone/" + drone.Id;
                DroneServiceClient client =
                    new DroneServiceClient(new WSHttpBinding(), new EndpointAddress(new Uri(address)));
                int closestStationId = random.Next(max) + 1;
                client.AddTask(new DroneTask(DroneTaskType.GoToStation,
                    _db.Stations.First(s => s.Id == closestStationId)));
                _messageHandler.Handle(String.Format("Drone {0} set to go to station {1}.", drone.Id,
                    closestStationId));
            }

            while (_isWorking)
            {
                if (_tasks.Count > 0)
                {
                    CoreTask task = _tasks.Dequeue();
                    switch (task.Type)
                    {
                        case CoreTaskType.CheckDronesStatus:
                            CheckDronesStatus();
                            break;
                        case CoreTaskType.CheckStationsStatus:
                            CheckStationsStatus();
                            break;
                    }
                }
                else
                {
                    Thread.Sleep(5000);
                    _tasks.Enqueue(new CoreTask(CoreTaskType.CheckDronesStatus));
                    _tasks.Enqueue(new CoreTask(CoreTaskType.CheckStationsStatus));
                }
            }
            _messageHandler.Handle("Simulation stoped.");
        }

        private void CheckStationsStatus()
        {
            // todo
        }

        int FindClosestStation(float longitude, float latitude)
        {
            Station station = null;
            float x = float.MaxValue, y = float.MaxValue, dist = float.MaxValue, bestDist = float.MaxValue;

            foreach (Station s in _db.Stations.ToList())
            {
                if (station == null)
                {
                    station = s;
                    x = Math.Abs(station.Longitude - longitude);
                    y = Math.Abs(station.Latitude - latitude);
                    bestDist = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                }
                else
                {
                    x = Math.Abs(s.Longitude - longitude);
                    y = Math.Abs(s.Latitude - latitude);
                    dist = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                    if (bestDist > dist)
                    {
                        bestDist = dist;
                        station = s;
                    }
                }
            }
            if (station == null) return -1;
            return station.Id;
        }


        private void Log(string message) { _messageHandler.Handle(message); }

        private void CheckDronesStatus()
        {

            if (_lastDroneTechInfosUpdate == null)
            {
                _lastDroneTechInfosUpdate = new SortedList<int, DroneTechInfo>();
            }
            List<Drone> drones = _db.Drones.Include("Model").ToList();
            foreach (Drone drone in drones)
            {
                string address = "http://localhost:4999/Drone/" + drone.Id;
                DroneServiceClient client = new DroneServiceClient(new WSHttpBinding(), new EndpointAddress(new Uri(address)));

                try
                {
                    if (_lastDroneTechInfosUpdate.ContainsKey(drone.Id))
                    {
                        _lastDroneTechInfosUpdate[drone.Id] = client.GetTechInfo();
                    }
                    else
                    {
                        _lastDroneTechInfosUpdate.Add(drone.Id, client.GetTechInfo());
                    }

                    if (_lastDroneTechInfosUpdate[drone.Id].CountOfTasks == 0)
                    {
                        
                        List<Transfer> transfers = _db.Transfers.Include("Drone").ToList();
                        Transfer transfer = null;
                        foreach (Transfer t in transfers)
                        {
                            if (t.Drone != null)
                                if (t.Drone.Id == drone.Id)
                                {
                                    transfer = t;
                                    break;
                                }
                        }
                        if (transfer == null)
                        {
                            
                        }
                    }
                }
                catch (EndpointNotFoundException e)
                {
                    Log("Could not connect to drone (EndpointNotFoundException)");
                }
                catch (CommunicationException e)
                {
                    Log("Could not connect to drone (CommunicationException)");
                }
                catch (Exception e)
                {
                    Log(e.GetType().ToString());
                    Log(e.Message);
                    Log(e.StackTrace);
                }
            }
        }

        public void StopSimulation()
        {
            _isWorking = false;
        }

    }
}
