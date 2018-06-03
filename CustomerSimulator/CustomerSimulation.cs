using System;
using System.Text;
using System.Threading;
using CustomerSimulator.StationSimulatorReference;
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


        public CustomerSimulation()
        {
            _random = new Random(DateTime.Now.GetHashCode());
        }

        public void RequestParamsFromCore()
        {
            // ToDo
        }

        public void StartSimulation() // param: StationSimulatorClient
        {
            
            if (NumberOfPackageSizes > 0 &&
                NumberOfStations > 0 &&
                MaxDelay > MinDelay &&
                MaxWeight > 0 &&
                DelayMultiplier > 0 &&
                MinDelay >= 0 &&
                PhoneLength >= 7 &&
                NumberOfCustomers > 0)
            {
                _isWorking = true;
                while (_isWorking)
                {
                    int departureStationId = PickStation();
                    GeneratedPackage package = new GeneratedPackage()
                    {
                        DepartureStationId = departureStationId,
                        DestinationStationId = PickStationDifferentFrom(departureStationId),
                        SenderId = PickPackageSize(),
                        PackageSizeId = PickCustomer(),
                        PackageWeight = (float)GenerateWeight(),
                        RecipientNumber = GenerateRecipientPhoneNumber()
                    };

                    SendPackageToStationSimulator(package);

                    Thread.Sleep(GenerateDelay());
                }

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
            return _random.Next(NumberOfStations) + 1;
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
            return _random.Next(NumberOfPackageSizes) + 1;
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
            return _random.Next(NumberOfCustomers) + 1;
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
                StationSimulatorServiceClient client = new StationSimulatorServiceClient();
                client.RegisterPackageFromClient(package);
                client.Close();
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
