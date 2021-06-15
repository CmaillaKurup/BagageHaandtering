using System;
using System.Threading;

namespace BagageHåndtering
{
    internal class Program
    {
        public static Manager mng = new Manager();
        public static Random randome = new Random();

        public static void Main()
        {
            mng.NewSuitcase("jens", "London", 1);
            mng.NewSuitcase("Hanne", "Paris", 2);
            mng.NewSuitcase("Claus", "Tralala", 3);
            
            while (true)
            {
                int temp = randome.Next(100, 2000);
                Thread.Sleep(temp);
                Console.WriteLine(mng.CounterQueue.Count + " counter");
                Console.WriteLine(mng.SortingQueue.Count + " sorting");
                Console.WriteLine(mng.GateQueue.Count + " Gate");
            }
        }
    }
}