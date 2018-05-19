using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DronePost.DataModel;

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

        public CustomerSimulation()
        {

        }

        public void StartSimulation() // param: StationSimulatorClient
        {
            if (NumberOfPackageSizes > 0 &&
                NumberOfStations > 0 &&
                MaxDelay > MinDelay &&
                MaxWeight > 0 &&
                DelayMultiplier > 0)
            {
                _isWorking = true;
                while (_isWorking)
                {
                    int departureStationId = PickStation();
                    int destinationStationId = PickStationDifferentFrom(departureStationId);
                    int sizeId = PickPackageSize();
                    int senderId = PickCustomer();
                    float weight = GenerateWeight();

                }

            }
            else
            {
                throw new WrongSimulationParamsException();
            }
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
            Random random = new Random(DateTime.Now.GetHashCode());
            StringBuilder stringBuilder = new StringBuilder(String.Empty);
            if (AddPlusBeforePhoneNumber)
            {
                stringBuilder.Append("+");
            }
            for (int i = 0; i < PhoneLength; i++)
            {
                stringBuilder.Append(i == 0 ? random.Next(1, 10) : random.Next(10));
            }
            return stringBuilder.ToString();
        }

        // ToDo MB RequestCustomer(int id)
    }

}
