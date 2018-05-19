using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        public float MaxWeight { get; set; }
        public int DelayMultiplier { get; set; }
        public int PhoneLength { get; set; }
        public bool AddPlusBeforePhoneNumber { get; set; }

        protected bool _isWorking;
        Random _random;


        public CustomerSimulation()
        {
            _random =  = new Random(DateTime.Now.GetHashCode());
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
                        PackageWeight = GenerateWeight(),
                        RecipientNumber = GenerateRecipientPhoneNumber()
                    };
                    // ToDo send package to StationSimulator()
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
            return 0;
        }

        protected int PickStationDifferentFrom(int stationId)
        {
            return 0;
        }

        protected int PickPackageSize()
        {
            return 0;
        }

        protected float GenerateWeight()
        {
            return 0f;
        }

        protected int PickCustomer()
        {
            return 0;
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

            return 0;
        }

        // ToDo MB RequestCustomer(int id)
    }

}
