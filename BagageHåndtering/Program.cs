using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    internal class Program
    {
        public static Manager _mng = new Manager();
        public static Random random = new Random();

        public static List<FlightPlan> flightPlans = new List<FlightPlan>();

        public static void Main()
        {
            flightPlans.Add(new FlightPlan("London", 0,123));
            flightPlans.Add(new FlightPlan("Paris", 1,124));

            string[] names = {"jens", "Kurt", "Niels"};
            
            lock (_mng.CounterQueue)
            {

                for (int i = 0; i < 1000; i++)
                {
                    _mng.NewSuitcase(names[random.Next(0,names.Length)], flightPlans[random.Next(0,flightPlans.Count)].FlightNumber, i);
                }
                
                Monitor.PulseAll(_mng.CounterQueue);
            }

            while (true)
            {
                int temp = random.Next(100, 2000);
                Thread.Sleep(temp);

                Console.WriteLine(_mng.CounterQueue.Count + " counter");
                Console.WriteLine(_mng.SortingQueue.Count + " sorting");

                for (int i = 0; i < _mng.GateArray.Length; i++)
                {
                    Console.WriteLine(_mng.GateArray[i].GateQueue.Count + " Gate " + i);
                }
            }
        }
    }
}