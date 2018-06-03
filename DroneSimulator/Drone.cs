using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace DroneSimulator
{
    public class Drone : DronePost.DataModel.Drone, IDrone
    {
        public Drone()
        {
            
        }

        public Drone(DronePost.DataModel.Drone drone)
        {
            Id = drone.Id;
            Latitude = drone.Latitude;
            Longitude = drone.Longitude;
            Model = drone.Model;
        }
        public DroneTechInfo GetTechInfo()
        {

            throw new NotImplementedException();
        }

        public void AddTask(DroneTask task)
        {
            throw new NotImplementedException();
        }

        public void SetTask(DroneTask task)
        {
            throw new NotImplementedException();
        }

        public void DoNextTask(bool force = false)
        {
            throw new NotImplementedException();
        }

        public bool Start()
        {
            throw new NotImplementedException();
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }
    }
}
