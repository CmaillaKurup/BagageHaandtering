using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    internal class Program
    {
        public static Manager _mng = new Manager();
        public static Random randome = new Random();

        public static List<FlightPlan> flightPlans = new List<FlightPlan>();

        public static void Main()
        {
            flightPlans.Add(new FlightPlan("London", 1,123));
            flightPlans.Add(new FlightPlan("Paris", 2,124));

            lock (_mng.CounterQueue)
            {
                _mng.NewSuitcase("jens", 123, 1);
                _mng.NewSuitcase("Kurt", 123, 2);
                _mng.NewSuitcase("Niels", 124, 3);
                _mng.NewSuitcase("Claus", 124, 4);
                _mng.NewSuitcase("Christian", 123, 5);
                _mng.NewSuitcase("Signe", 123, 6);
                _mng.NewSuitcase("Marie", 124, 7);
                _mng.NewSuitcase("Mille", 124, 8);
                _mng.NewSuitcase("Clara", 123, 9);
                _mng.NewSuitcase("Susan", 123, 10);
                _mng.NewSuitcase("Poul", 124, 11);
                _mng.NewSuitcase("Bo", 124, 12);
                Monitor.PulseAll(_mng.CounterQueue);
            }

            while (true)
            {
                int temp = randome.Next(100, 2000);
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