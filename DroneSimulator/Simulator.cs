using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DronePost.DataModel;


namespace DroneSimulator
{
    class Simulator
    {
        public List<DroneSimulation> Drones { get; protected set; }

        public Simulator()
        {
            Drones = new List<DroneSimulation>();
        }


    }
}
