using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
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
            result = _context.Packages.Include("Stations").Include("PackageSizes").First(p =>
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
            throw new NotImplementedException();
        }

        public void RequestDroneForPackage(Package package)
        {
            throw new NotImplementedException();
        }

        public void RequestDroneForPackages(params Package[] packages)
        {
            throw new NotImplementedException();
        }
    }
}
