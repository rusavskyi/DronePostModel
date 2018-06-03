using System;
using System.Threading;

namespace CustomerSimulator
{
    class Source
    {
        public static void Main(string[] args)
        {
            CustomerSimulation sim = new CustomerSimulation()
            {
                AddPlusBeforePhoneNumber = true,
                DelayMultiplier = 1000,
                MaxDelay = 5,
                MaxWeight = 20,
                MinDelay = 1,
                NumberOfPackageSizes = 1,
                NumberOfCustomers = 1,
                NumberOfStations = 1,
                PhoneLength = 9
            };


            Thread thread = new Thread(() =>
            {
                sim.StartSimulation();
            });
            Console.WriteLine(@"Press 'Enter' to stop.");
            Console.ReadLine();
            sim.StopSimulation();
            if (thread.IsAlive) thread.Interrupt();
        }
    }
}
