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

        private Queue<DroneTask> _tasks;
        private DroneTask _currenTask;

        public DroneSimulation(Drone drone)
        {
            Drone = drone;
            _tasks = new Queue<DroneTask>();
        }

        public DroneTechInfo GetTechInfo()
        {
            throw new NotImplementedException();
        }

        public void AddTask(DroneTask task)
        {
            _tasks.Enqueue(task);
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
