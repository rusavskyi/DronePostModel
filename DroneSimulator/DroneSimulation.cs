using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace DroneSimulator
{
    public class DroneSimulation : IDrone
    {
        public Drone Drone { get; set; }

        private Queue<DroneTask> _tasks;
        private DroneTask _currenTask;
        private bool _currentTaskIsFinished;
        public bool _isWorking { get; set; }

        public DroneSimulation(Drone drone)
        {
            Drone = drone;
            _tasks = new Queue<DroneTask>();
            _currentTaskIsFinished = false;
            _currenTask = null;
            _isWorking = false;
        }

        public DroneTechInfo GetTechInfo()
        {
            throw new NotImplementedException();
        }

        public void AddTask(DroneTask task)
        {
			if (task.Type.CompareTo(DroneTaskType.TakePackage) == 1 || task.Type.CompareTo(DroneTaskType.GoToStation) == 1 ||
				task.Type.CompareTo(DroneTaskType.TakePackage) == 1)
			{
				_isWorking = true;
			}
			else _isWorking = false;

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
            _isWorking = true;
            Thread thread = new Thread(WorkSimulationThread);
            thread.Start();
            return thread.IsAlive;
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }

        private void WorkSimulationThread()
        {
            while (_isWorking)
            {
                if (_currenTask == null)
                {
                    if (_tasks.Count > 0)
                    {
                        _currenTask = _tasks.Dequeue();
                        _currentTaskIsFinished = false;
                    }
                }
                else
                {
                    switch (_currenTask.Type)
                    {
                        case DroneTaskType.TakePackage:
                            _currentTaskIsFinished = TakePackage();
                            break;
                        case DroneTaskType.GoToStation:
                            _currentTaskIsFinished = GoToStation();
                            break;
                        case DroneTaskType.LeavePackage:
                            _currentTaskIsFinished = LeavePackage();
                            break;
                        case DroneTaskType.ChargeAtStation:
                            _currentTaskIsFinished = ChargeAtStation();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        private bool GoToStation()
        {
            
            return true;
        }

        private bool TakePackage()
        {

            return true;
        }

        private bool LeavePackage()
        {

            return true;
        }
        private bool ChargeAtStation()
        {

            return true;
        }
    }
}
