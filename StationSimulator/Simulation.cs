using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using StationSimulatorService;

namespace StationSimulator
{
    class Simulation
    {
        private readonly IMessageHandler _messageHandler;

        public Simulation(IMessageHandler messageHandler)
        {
            HostService();
            _messageHandler = messageHandler;
        }

        public void Log(string message)
        {
            _messageHandler.Handle(message);
        }


        public void HostService()
        {
            Uri baseAddress = new Uri("http://localhost:5000/StationSimulator");
            ServiceHost host = new ServiceHost(typeof(StationSimulatorService.StationSimulatorService), baseAddress);

            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                host.AddServiceEndpoint(typeof(IStationSimulatorService), binding, baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior() {HttpGetEnabled = true};
                host.Description.Behaviors.Add(smb);
                host.Open();
            }
            catch (CommunicationException ce)
            {
                Log(String.Format("Exception: {0}", ce.Message));
                host.Abort();
            }
        }

        public void StopHost()
        {

        }
    }
}
