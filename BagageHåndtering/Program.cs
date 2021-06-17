using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    internal class Program
    {
        public static Manager _mng = new Manager();
        //public static Suitcase _suitcase = new Suitcase(null, 0, 0);

        public static Random randome = new Random();

        public static List<FlightPlan> flightPlans = new List<FlightPlan>();

        public static void Main()
        {
            flightPlans.Add(new FlightPlan("London", 1,123));
            flightPlans.Add(new FlightPlan("Paris", 2,124));
            
            _mng.NewSuitcase("jens", 123, 1);
            _mng.NewSuitcase("jens", 123, 2);
            _mng.NewSuitcase("jens", 124, 3);
            _mng.NewSuitcase("jens", 124, 4);

            while (true)
            {
                int temp = randome.Next(100, 2000);
                Thread.Sleep(temp);
                
                
                Console.WriteLine(_mng.CounterQueue.Count + " counter");
                Console.WriteLine(_mng.SortingQueue.Count + " sorting");
                Console.WriteLine(_mng.GateOneQueue.Count + " Gate");
            }
        }
    }
}