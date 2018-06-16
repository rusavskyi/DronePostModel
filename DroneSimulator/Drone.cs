using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace DroneSimulator
{
    public class Drone : DronePost.DataModel.Drone, IDrone
    {
        private bool _isWorking { get; set; }
        private Thread _thread;
        private Queue<DroneTask> _tasks;
        private DroneTask _currentTask;
        private bool _currentTaskIsFinished;
        private float _batteryCharge;


        public Drone()
        {
            
        }

        public Drone(DronePost.DataModel.Drone drone)
        {
            Id = drone.Id;
            Latitude = drone.Latitude;
            Longitude = drone.Longitude;
            Model = drone.Model;
            _batteryCharge = drone.Model.BatteryCapacity;
        }
        public DroneTechInfo GetTechInfo()
        {
            return new DroneTechInfo(Model, 0, _tasks.Count, Longitude, Latitude);
        }

        public void AddTask(DroneTask task)
        {
            _tasks.Enqueue(task);
        }

        public void SetTask(DroneTask task)
        {
            _currentTask = task;
        }

        public void DoNextTask(bool force = false)
        {
            if (_currentTaskIsFinished)
            {
                _currentTask = _tasks.Dequeue();
            }
        }

        public bool Start()
        {
            _isWorking = true;
            _thread = new Thread(() =>
            {
                Simulation();
            });
            return true;
        }

        public bool Stop()
        {
            _isWorking = false;
            return true;
        }

        private void Simulation()
        {
            while (_isWorking)
            {
                if (_tasks.Count > 0)
                {
                    switch (_currentTask.Type)
                    {
                        case DroneTaskType.TakePackage:

                            break;
                        case DroneTaskType.GoToStation:
                            Debug.WriteLine("Drone {0} {1} moved to statation {2}", Model, Id, _currentTask.Station.Id);
                            // todo over time
                            Latitude = _currentTask.Station.Latitude;
                            Longitude = _currentTask.Station.Longitude;
                            // todo commit arrival
                            DoNextTask();
                            break;
                        case DroneTaskType.LeavePackage:

                            break;
                        case DroneTaskType.ChargeAtStation:

                            break;
                    }
                }
                else
                {
                    Thread.Sleep(5000); // Wait 5 secends for new tasks.
                }
            }
        }
    }
}
