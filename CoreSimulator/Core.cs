using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using CoreService;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace CoreHost
{
    class Core : ICore
    {
        private IMessageHandler _messageHandler;
        private ServiceHost _host;
        private DronePostContext _context;
        private bool _isWorking;
        private Queue<CoreTask> _tasks;



        public Core(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
            _context = new DronePostContext();
        }

        public void StartHost()
        {
            Uri baseAddress = new Uri("http://localhost:8888/Core");
            _host = new MyServiceHost(this, typeof(CoreService.CoreService), baseAddress);

            try
            {
                ServiceEndpoint endpoint = _host.AddServiceEndpoint(typeof(ICoreService), new WSHttpBinding(), "");
                ServiceMetadataBehavior bechavior = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true
                };
                _host.Description.Behaviors.Add(bechavior);
                _host.Open();
                _messageHandler.Handle("Core has started on address: " + baseAddress.ToString());
            }
            catch (Exception e)
            {
                _messageHandler.Handle("Error: " + e.Message);
            }



        }

        public void Test()
        {
            try
            {
                /*
                 string address = "http://localhost:4999/Drone/2";
                DroneServiceClient _client =
                    new DroneServiceClient(new WSHttpBinding(), new EndpointAddress(new Uri(address)));
                _client.DoNextTask(true);
                */

                string address = "http://localhost:5000/Station/2";
                StationServiceClient _client =
                    new StationServiceClient(new WSHttpBinding(), new EndpointAddress(new Uri(address)));
                _client.DoNextTask(true);

            }
            catch (Exception e)
            {
                _messageHandler.Handle("ERROR: "+e.Message);
            }

        }

    public void StopHost()
        {
            try
            {
                _host.Close();
                _messageHandler.Handle("Core has stopped");
            }
            catch (Exception e)
            {
                _messageHandler.Handle("Error: " + e.Message);
            }
        }

        // need testing

        public Package RegisterPackage(GeneratedPackage package)
        {
            Package result = new Package
            {
                DestinationStation = _context.Stations.First(s => s.Id == package.DestinationStationId),
                //Id = context.Stations.ToList().Count,
                RecipientPhoneNumber = package.RecipientNumber,
                Size = _context.PackageSizes.First(ps => ps.Id == package.PackageSizeId),
                Weight = package.PackageWeight
            };
            _context.Packages.Add(result);
            _context.SaveChanges();
            //List<Package> tmp =
            result = _context.Packages.Include("DestinationStation").Include("Size").First(p =>
                p.DestinationStation.Id == package.DestinationStationId &&
                p.RecipientPhoneNumber == package.RecipientNumber &&
                p.Size.Id == package.PackageSizeId &&
                p.Weight == package.PackageWeight);
            Customer customer = _context.Customers.First(c => c.Id == package.SenderId);
            if (customer != null)
            {
                _context.CustomerPackages.Add(new CustomerPackage { Package = result, Sender = customer });
            }
            else
            {
                if (_context.Customers.Count() > package.SenderId)
                {
                    customer = _context.Customers.ToList()[package.SenderId];
                }
                else
                {
                    customer = _context.Customers.ToList()[0];
                }
                _context.CustomerPackages.Add(new CustomerPackage { Package = result, Sender = customer });
            }
            _context.SaveChanges();
            Transfer transfer = new Transfer()
            {
                ArrivalStation = _context.Stations.First(s => s.Id == package.DestinationStationId),
                ArrivalTime = DateTime.Now,
                Package = result
            };
            _messageHandler.Handle("Package from " + customer.Id + " to " + package.RecipientNumber + " registred with id: " + result.Id + ".");
            RegisterTransfer(transfer);
            return result;
        }

        public int RegisterTransfer(Transfer transfer)
        {
            _context.Transfers.Add(transfer);
            _context.SaveChanges();
            _messageHandler.Handle("Transfer registred.");
            return 0;
        }

        public int RegisterDrone(Drone drone)
        {
            _context.Drones.Add(drone);
            _context.SaveChanges();
            _messageHandler.Handle("Drone registred.");
            return 0;
        }

        public int RegisterStation(Station station)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
            _messageHandler.Handle("Station registred.");
            return 0;
        }

        public int RegisterCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            _messageHandler.Handle("Customer registred.");
            return 0;
        }

        public void SendDroneOnCharge(int idDrone)
        {
            // todo set task for drone to charge at station
            throw new NotImplementedException();
        }

        public void RequestDroneForPackage(Package package)
        {
            // todo add task for drone to take package
            throw new NotImplementedException();
        }

        public void RequestDroneForPackages(params Package[] packages)
        {
            // todo add tasks for drones to take packages
            throw new NotImplementedException();
        }

        public List<Drone> GetDrones()
        {
            _messageHandler.Handle("GetDrones request...");
            List<Drone> drones = null;
            try
            {
                drones = _context.Drones.Include("Model").ToList();
            } catch (Exception e)
            {
                _messageHandler.Handle("Error: "+e.Message + "\nStack trace: " + e.StackTrace);
            }
            return drones;
        }

        public List<Station> GetStations()
        {
            _messageHandler.Handle("GetStatios request...");
            List<Station> stations = null;
            try
            {
                stations = _context.Stations.ToList();
            }
            catch (Exception e)
            {
                _messageHandler.Handle("Error: " + e.Message + "\nStack trace: " + e.StackTrace);
            }
            return stations;
        }

        public List<Customer> GetCustomers()
        {
            _messageHandler.Handle("GetCustomers request...");
            List<Customer> customers = null;
            try
            {
                customers = _context.Customers.Include("City").ToList();
            }
            catch (Exception e)
            {
                _messageHandler.Handle("Error: " + e.Message + "\nStack trace: " + e.StackTrace);
            }
            return customers;
        }

        public List<PackageSize> GetSizes()
        {
            _messageHandler.Handle("GetSizes request...");
            List<PackageSize> sizes = null;
            try
            {
                sizes = _context.PackageSizes.ToList();
            }
            catch (Exception e)
            {
                _messageHandler.Handle("Error: " + e.Message + "\nStack trace: " + e.StackTrace);
            }
            return sizes;
        }

        public void StartSimulation()
        {
            Thread thread = new Thread(() =>
            {
                Simulation();
            });
        }

        private void Simulation()
        {
            _isWorking = true;
            while (_isWorking)
            {
                if (_tasks.Count > 0)
                {
                    CoreTask task = _tasks.Dequeue();
                    switch (task.Type)
                    {
                        case CoreTaskType.CheckDronesStatus:

                            break;
                        case CoreTaskType.CheckStationsStatus:

                            break;
                    }
                }
                else
                {
                   _tasks.Enqueue(new CoreTask(CoreTaskType.CheckDronesStatus));
                   _tasks.Enqueue(new CoreTask(CoreTaskType.CheckStationsStatus));
                }
            }
        }


    }
}
