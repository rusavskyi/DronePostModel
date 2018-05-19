using System.Collections.Generic;


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
