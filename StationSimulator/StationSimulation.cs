using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationSimulator
{
    class StationSimulation : IStationAPI
    {
        public Station Station { get; set; }

        private ArrayList drones = new ArrayList();
        private ArrayList packagesToSent = new ArrayList();
        private ArrayList packagesToGive = new ArrayList();


        public void ChargeDroneOff(Drone drone)
        {
            throw new NotImplementedException();
        }

        public void ChargeDroneOn(Drone drone)
        {
            throw new NotImplementedException();
        }

        public void CheckInDrone(Drone drone)
        {
            drones.Add(drone);
        }

        public void CheckOutDrone(Drone drone)
        {
            if (drone.Equals(drone))
            {
                drones.Remove(drone);
            }
            else
            {
                Console.WriteLine("This drone is not on this station");
            }
        }

        public DroneTechInfo GetDroneTechInfo(Drone drone)
        {
            //return drone.TechInfo;
            throw new NotImplementedException();
        }

        public Package GetPackage(Package package)
        {
            packagesToSent.Add(package);
            return new Package();
        }

        public void GivePackage(Customer customer, Package package)
        {
            packagesToGive.Add(package);
        }

        public void RequestDrone(Package package, Drone drone)
        {
            // to do
        }

        public void SetTask(DroneTask droneTask, Drone drone)
        {
            // to do
        }
    }
}
