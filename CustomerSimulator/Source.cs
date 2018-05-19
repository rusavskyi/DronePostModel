﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            // sim.RequestParamsFromCore();

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
