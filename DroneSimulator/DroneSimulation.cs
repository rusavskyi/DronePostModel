using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace DroneSimulator
{
	public class DroneSimulation : IDrone
	{
		public Drone Drone { get; set; }
		public bool _isWorking { get; set; }

		private Thread thread;

		private Queue<DroneTask> _tasks;
		private DroneTask _currenTask;
		private bool _currentTaskIsFinished;
		

		


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
			_tasks.Enqueue(task);
		}

		public void SetTask(DroneTask task)
		{
			List<DroneTask> droneTask = _tasks.ToList();
			_tasks.Clear();
			_tasks.Enqueue(task);
			foreach (DroneTask taskItem in droneTask) {
				_tasks.Enqueue(taskItem);
			}
		}

		public void DoNextTask(bool force = false)
		{
			if (_tasks.Count >= 1)
			{
				DroneTask nextTask = _tasks.Dequeue();

				switch (nextTask.Type)
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
			else {
				// print "Drone Task queue is empty"
			}
		}

		public bool Start()
		{
			_isWorking = true;
			thread = new Thread(WorkSimulationThread);
			thread.Start();
			return thread.IsAlive;
		}

		public bool Stop()
		{
			_isWorking = false;
			thread.Abort();
			return !thread.IsAlive;
			
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
