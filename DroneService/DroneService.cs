using System;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace DroneService
{
    public class DroneService : IDroneService
    {
        private readonly IDrone _drone;
        public DroneService(IDrone drone)
        {
            _drone = drone;
        }


        public DroneTechInfo GetTechInfo()
        {
             return new DroneTechInfo(new DroneModel(), 100, 0, 0, 0);
            //return _drone.GetTechInfo();
        }

        public void AddTask(DroneTask task)
        {
            _drone.AddTask(task);
        }

        public void SetTask(DroneTask task)
        {
            _drone.SetTask(task);
        }

        public void DoNextTask(bool force = false)
        {
            _drone.DoNextTask(force);
        }

        public bool Start()
        {
            return _drone.Start();
        }

        public bool Stop()
        {
            return _drone.Stop();
        }
    }
}
