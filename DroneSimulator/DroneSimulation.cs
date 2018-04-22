using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace DroneSimulator
{
    class DroneSimulation : IDroneAPI
    {
        public Drone Drone { get; set; }

        public DroneSimulation(Drone drone)
        {
            Drone = drone;
        }

        public DroneTechInfo GetTechInfo()
        {
            throw new NotImplementedException();
        }

        public void SetTask(DroneTask task)
        {
            throw new NotImplementedException();
        }
    }
}
