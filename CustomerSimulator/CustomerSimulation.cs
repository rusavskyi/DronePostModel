using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading;
using CustomerSimulator.CoreServiceReference;
using DronePost.DataModel;
using DronePost.SupportClasses;

namespace CustomerSimulator
{
    public class CustomerSimulation
    {
        public int NumberOfStations { get; set; }
        public int NumberOfPackageSizes { get; set; }
        public int NumberOfCustomers { get; set; }
        public int MinDelay { get; set; }
        public int MaxDelay { get; set; }
        public double MaxWeight { get; set; }
        public int DelayMultiplier { get; set; }
        public int PhoneLength { get; set; }
        public bool AddPlusBeforePhoneNumber { get; set; }

        protected bool _isWorking;
        Random _random;

        private CoreServiceClient _coreServiceClient;
        private List<Customer> _customers;
        private List<Station> _stations;
        private List<PackageSize> _sizes;

        public CustomerSimulation()
        {
            _random = new Random(DateTime.Now.GetHashCode());
            _coreServiceClient = new CoreServiceClient();
            _customers = new List<Customer>();
            _stations = new List<Station>();
            _sizes = new List<PackageSize>();
        }

        public void RequestParamsFromCore()
        {
            Console.WriteLine("Requesting data frome core...");
            _customers = new List<Customer>(_coreServiceClient.GetCustomers());
            Console.WriteLine(@"Recived {0} costumers.", _customers.Count);
            _stations = new List<Station>(_coreServiceClient.GetStations());
            Console.WriteLine(@"Recived {0} stations.", _stations.Count);
            _sizes = new List<PackageSize>(_coreServiceClient.GetSizes());
            Console.WriteLine(@"Recived {0} package sizes.", _sizes.Count);
            NumberOfPackageSizes = _sizes.Count;
            NumberOfCustomers = _customers.Count;
            NumberOfStations = _stations.Count;
        }

        public void StartSimulation() // param: StationSimulatorClient
        {

            RequestParamsFromCore();
            //Console.WriteLine("Customers {0}, Station {1}, Sizes {2}", NumberOfCustomers, NumberOfStations, NumberOfPackageSizes);
            if (NumberOfPackageSizes > 0 &&
                NumberOfStations > 0 &&
                MaxDelay > MinDelay &&
                MaxWeight > 0 &&
                DelayMultiplier > 0 &&
                MinDelay >= 0 &&
                PhoneLength >= 7 &&
                NumberOfCustomers > 0)
            {
                Console.WriteLine("Simulation started...");
                _isWorking = true;
                while (_isWorking)
                {
                    int departureStationId = PickStation();
                    GeneratedPackage package = new GeneratedPackage()
                    {
                        DepartureStationId = _stations[departureStationId].Id,
                        DestinationStationId = _stations[PickStationDifferentFrom(departureStationId)].Id,
                        SenderId = _customers[PickCustomer()].Id,
                        PackageSizeId = _sizes[PickPackageSize()].Id,
                        PackageWeight = (float)GenerateWeight(),
                        RecipientNumber = GenerateRecipientPhoneNumber()
                    };

                    SendPackageToStationSimulator(package);

                    Thread.Sleep(GenerateDelay());
                }
                Console.WriteLine("Simulation stoped...");
            }
            else
            {
                throw new WrongSimulationParamsException();
            }
        }

        public void StopSimulation()
        {
            _isWorking = false;
        }

        protected int PickStation()
        {
            return _random.Next(NumberOfStations);
        }

        protected int PickStationDifferentFrom(int stationId)
        {
            int result = PickStation();
            while (result == stationId)
            {
                result = PickStation();
            }
            return result;
        }

        protected int PickPackageSize()
        {
            return _random.Next(NumberOfPackageSizes);
        }

        protected double GenerateWeight()
        {
            double result = _random.NextDouble();
            if (result < 0) result *= -1;
            if (result > MaxWeight) result %= MaxWeight;
            return result;
        }

        protected int PickCustomer()
        {
            return _random.Next(NumberOfCustomers);
        }

        protected string GenerateRecipientPhoneNumber()
        {
            StringBuilder stringBuilder = new StringBuilder(String.Empty);
            if (AddPlusBeforePhoneNumber)
            {
                stringBuilder.Append("+");
            }
            for (int i = 0; i < PhoneLength; i++)
            {
                stringBuilder.Append(i == 0 ? _random.Next(1, 10) : _random.Next(10));
            }
            return stringBuilder.ToString();
        }

        protected int GenerateDelay()
        {
            int result = _random.Next(MinDelay, MaxDelay + 1);
            result *= DelayMultiplier;
            return result;
        }

        public void SendPackageToStationSimulator(GeneratedPackage package)
        {
            try
            {
                string address = "http://localhost:5000/Station/"+package.DepartureStationId;
                StationServiceClient station = new StationServiceClient(new WSHttpBinding(), new EndpointAddress(new Uri(address)));
                station.GetPackageFromCustomer(package);
                station.Close();
            }
            catch (Exception exception)
            {
                Log("Exception: "+exception.Message);
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        // ToDo MB RequestCustomer(int id)
    }

}
