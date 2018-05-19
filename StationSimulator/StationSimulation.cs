using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;
using System;
using System.Collections.Generic;
using DroneSimulator;

namespace StationSimulator
{
	// ToDo FIX METHODS to fit IStation
	class StationSimulation : IStation
	{
		public Station Station { get; set; }

		private StationTask _currentTask;
		private bool _currentTaskIsFinished;
		private List<Drone> _drones;
		private List<Package> _packagesToSent;
		private List<Package> _packagesToGive;
		private Queue<StationTask> _tasks;
		private List<int> _chargeSlots;

		private List<DroneSimulation> _droneSimulations;

		public StationSimulation(Station station)
		{
			Station = station;
			_currentTask = null;
			_currentTaskIsFinished = true;
			_drones = new List<Drone>();
			_packagesToSent = new List<Package>();
			_packagesToGive = new List<Package>();
			_tasks = new Queue<StationTask>();
			_chargeSlots = new List<int>();
			
			
		}

		public void ChargeDroneOff(Drone drone)
		{
			throw new NotImplementedException();
		}

		public void ChargeDroneOn(Drone drone)
		{
			throw new NotImplementedException();
		}

		public void CheckInDrone(Drone drone)
		{
			_drones.Add(drone);
		}

		public void CheckOutDrone(Drone drone)
		{
			if (drone.Equals(drone))
			{
				_drones.Remove(drone);
			}
			else
			{
				Console.WriteLine("This drone is not on this station"); // todo WPF - print to log view, somehow
			}
		}

		public void RequestDroneForPackage(Package package)
		{
			foreach (DroneSimulation drone in _droneSimulations) {
				if (!drone._isWorking) {

					if (drone.Drone.Model.MaxSizeCarry.Lenght >= package.Size.Lenght && 
						drone.Drone.Model.MaxSizeCarry.Height >= package.Size.Height && 
						drone.Drone.Model.MaxSizeCarry.Width >= package.Size.Width && 
						drone.Drone.Model.MaxWeightCarry >= package.Weight)
					{
						DroneTask t = new DroneTask(DroneTaskType.TakePackage, package, package.DestinationStation);
						drone.AddTask(t);
					}
					else {
						Console.WriteLine("Drone not found 404 :-)");
					}


				}
			}
		}

		public void RequestDroneForPackages(params Package[] packages) // проблема с рассчётом габаритов
		{
			foreach (DroneSimulation drone in _droneSimulations)
			{
				if (!drone._isWorking)
				{
					float length = 0; 
					float height = 0;
					float width = 0;
					float weight = 0;
					foreach(Package package in packages) {
						length += package.Size.Lenght;
						height += package.Size.Height;
						width += package.Size.Width;
						weight += package.Weight;
					}


					if (drone.Drone.Model.MaxSizeCarry.Lenght >= length &&
						drone.Drone.Model.MaxSizeCarry.Height >= height &&
						drone.Drone.Model.MaxSizeCarry.Width >= width &&
						drone.Drone.Model.MaxWeightCarry >= weight)
					{
						foreach(Package package in packages) {
							DroneTask t = new DroneTask(DroneTaskType.TakePackage, package, package.DestinationStation);
							drone.AddTask(t);
						}
					}
					else
					{
						Console.WriteLine("Drone not found 404 :-)");
					}


				}
			}
		} 
		public DroneTechInfo GetDroneTechInfo(Drone drone)
		{
			//return drone.TechInfo;
			throw new NotImplementedException();
		}

		public void CheckIn(Drone drone) // public void CheckIn(DroneSimulation drone) ?
		{
			throw new NotImplementedException();
		}

		public void CheckOut(Drone drone) // public void CheckIn(DroneSimulation drone)?
		{
			throw new NotImplementedException();
		}

		public void GivePackageToRecipient(Customer customer, Package package)  // need CustomerSumilation  ?
		{
			throw new NotImplementedException();

		}

		public Package GetPackageFromCustomer(Package package) // need CustomerSumilation  ?
		{
			throw new NotImplementedException();
		}

		public void SetTask(StationTask stationTask)
		{
			throw new NotImplementedException();
		}

		public void AddTask(StationTask stationTask)
		{
			throw new NotImplementedException();
		}

		public void DoNextTask(bool force = false)
		{
			throw new NotImplementedException();
		}

		public int RequestChargeSlot()
		{
			throw new NotImplementedException();
		}

		public Package GetPackage(Package package)
		{
			_packagesToSent.Add(package);
			return new Package();
		}

		public void GivePackage(Customer customer, Package package)
		{
			_packagesToGive.Add(package);
		}

		public void RequestDrone(Package package, Drone drone)
		{
			// to do
		}

		public void SetTask(DroneTask droneTask, Drone drone) // check method
		{
			foreach (DroneSimulation d in _droneSimulations)
			{
				if (d.Drone.Equals(drone))
				{
					d.AddTask(droneTask);
					break;
				}
				else
				{
					DroneSimulation ds = new DroneSimulation(drone);
					ds.AddTask(droneTask);
					_droneSimulations.Add(ds);
				}
			}
		}
	}
}
