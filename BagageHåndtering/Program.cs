using System;

namespace BagageHåndtering
{
    internal class Program
    {
        public static void Main()
        {
            Manager mng = new Manager();
            mng.NewSuitcases("jens", "London", 1);
            mng.NewSuitcases("Hanne", "Paris", 2);
            mng.NewSuitcases("Claus", "Tralala", 3);

            Counters counter = new Counters();
            
            Console.WriteLine(counter);
        }
    }
}