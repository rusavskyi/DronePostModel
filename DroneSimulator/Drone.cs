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
        private IMessageHandlerDrone _messageHandler;


        public Drone() { }

        public Drone(DronePost.DataModel.Drone drone, IMessageHandlerDrone handler)
        {
            Id = drone.Id;
            Latitude = drone.Latitude;
            Longitude = drone.Longitude;
            Model = drone.Model;
            _batteryCharge = drone.Model.BatteryCapacity;
            _tasks = new Queue<DroneTask>();
            _messageHandler = handler;
        }
        public DroneTechInfo GetTechInfo()
        {
            return new DroneTechInfo(Model, 0, _tasks.Count + (_currentTaskIsFinished ? 0 : 1), Longitude, Latitude);
        }

        public void AddTask(DroneTask task)
        {
            _tasks.Enqueue(task);
            Log("received task: " + task.Type);
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
            if (!_isWorking)
            {
                _isWorking = true;
                _thread = new Thread(Simulation);
                _thread.Start();
                return true;
            }
            return false;
        }

        public bool Stop()
        {
            if (_isWorking)
            {
                _isWorking = false;
                //todo Thread stop
            }

            return true;
        }

        private void Simulation()
        {
            _currentTaskIsFinished = true;
            while (_isWorking)
            {
                if (_tasks.Count > 0)
                {
                    DoNextTask();
                    _currentTaskIsFinished = false;
                    switch (_currentTask.Type)
                    {
                        case DroneTaskType.TakePackage:

                            break;
                        case DroneTaskType.GoToStation:
                            Log($"started moving to statation {_currentTask.Station.Id}");
                            // todo over time
                            float distanceLat = Math.Abs(_currentTask.Station.Latitude - Latitude);
                            float distanceLon = Math.Abs(_currentTask.Station.Longitude - Longitude);
                            int ticks = (int)Math.Sqrt(Math.Pow(distanceLat, 2) + Math.Pow(distanceLon, 2));
                            distanceLat *= Latitude > _currentTask.Station.Latitude ? 1 : -1;
                            distanceLon *= Longitude > _currentTask.Station.Longitude ? 1 : -1;
                            ticks %= 100;
                            _messageHandler.Handle("Ticks " + ticks);
                            for (int i = 0; i < ticks; i++)
                            {
                                Thread.Sleep(5000);
                                Latitude += distanceLat / 100;
                                Longitude += distanceLon / 100;
                            }

                            Latitude = _currentTask.Station.Latitude;
                            Longitude = _currentTask.Station.Longitude;
                            // todo commit arrival
                            Log($"moved to statation {_currentTask.Station.Id}");
                            break;
                        case DroneTaskType.LeavePackage:

                            break;
                        case DroneTaskType.ChargeAtStation:

                            break;

                    }
                    _currentTaskIsFinished = true;
                }
                else
                {
                    Thread.Sleep(5000); // Wait 5 secends for new tasks.
                }
            }
        }




        private void Log(string message)
        {
            _messageHandler.Handle("Drone " + Model.ModelName + " " + Id + ": " + message);
        }
    }
}
