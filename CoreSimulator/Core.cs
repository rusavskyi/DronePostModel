using System;
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

        public Core(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public void StartHost()
        {
            Uri baseAddress = new Uri("http://localhost:8888/Core");
            _host = new ServiceHost(typeof(CoreService.CoreService), baseAddress);

            try
            {
                ServiceEndpoint endpoint = _host.AddServiceEndpoint(typeof(ICoreService),new WSHttpBinding(),"");
                ServiceMetadataBehavior bechavior = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true
                };
                _host.Description.Behaviors.Add(bechavior);
                _host.Open();
                _messageHandler.Handle("Core has started on address: "+baseAddress.ToString());
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
            } catch (Exception e)
            {
                _messageHandler.Handle("Error: "+e.Message);
            }
        }



        public Package RegisterPackage(GeneratedPackage package)
        {
            throw new NotImplementedException();
        }

        public int RegisterTransfer(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public int RegisterDrone(Drone drone)
        {
            throw new NotImplementedException();
        }

        public int RegisterStation(Station station)
        {
            throw new NotImplementedException();
        }

        public int RegisterCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void SendDroneOnCharge(Drone drone, Station station)
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
