using System;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace DroneSimulatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DroneSimulatorRevice" in both code and config file together.
    public class DroneSimulatorRevice : IDroneSimulatorRevice
    {
        public IDrone Drone { get; set; }

        public void SetTask(DroneTask task)
        {
            throw new NotImplementedException();
        }
    }
}
