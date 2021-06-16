using System;
using System.Threading;

namespace BagageHåndtering
{
    internal class Program
    {
        public static Manager _mng = new Manager(); 
        public static Suitcase _suitcase = new Suitcase(null, null, 0);

        public static Random randome = new Random();

        public static void Main()
        {
            _mng.NewSuitcase("jens", "London", 1);
            _mng.NewSuitcase("Hanne", "Paris", 2);
            _mng.NewSuitcase("Claus", "Tralala", 3);
            _mng.NewSuitcase("jens", "London", 4);
            _mng.NewSuitcase("Frank", "Paris", 5);
            _mng.NewSuitcase("Mogens", "Tralala", 6);
            _mng.NewSuitcase("Signe", "London", 7);
            _mng.NewSuitcase("Hanne", "Paris", 8);
            _mng.NewSuitcase("Flemming", "Tralala", 9);
            _mng.NewSuitcase("jens", "London", 10);
            _mng.NewSuitcase("Kurt", "Paris", 11);
            _mng.NewSuitcase("Claus", "Tralala", 12);
            _mng.NewSuitcase("jens", "London", 13);
            _mng.NewSuitcase("Signe", "Paris", 14);
            _mng.NewSuitcase("Sol", "Tralala", 15);
            _mng.NewSuitcase("Theodor", "London", 16);
            _mng.NewSuitcase("Max", "Paris", 17);
            _mng.NewSuitcase("Mickey", "Tralala", 18);
            _mng.NewSuitcase("Jonas", "London", 19);
            _mng.NewSuitcase("Rasmus", "Paris", 20);
            _mng.NewSuitcase("Lars", "Tralala", 21);
            _mng.NewSuitcase("Chris", "London", 22);
            _mng.NewSuitcase("Bo", "Paris", 23);
            _mng.NewSuitcase("Denise", "London", 24);
            _mng.NewSuitcase("Daniel", "Paris", 25);
            _mng.NewSuitcase("Cassandra", "Tralala", 26);
            _mng.NewSuitcase("Anne-marie", "London", 27);
            _mng.NewSuitcase("Michael", "Paris", 28);
            _mng.NewSuitcase("Hans", "Tralala", 29);
            _mng.NewSuitcase("Mikkel", "London", 30);
            _mng.NewSuitcase("Christian", "Paris", 31);
            _mng.NewSuitcase("Lone", "Tralala", 32);
            _mng.NewSuitcase("Sigurd", "Tralala", 33);
            
            while (true)
            {
                int temp = randome.Next(100, 2000);
                Thread.Sleep(temp);
                Console.WriteLine(_mng.CounterQueue.Count + " counter");
                Console.WriteLine(_mng.SortingQueue.Count + " sorting");
                Console.WriteLine(_mng.GateQueue.Count + " Gate");
                Console.WriteLine(_mng.LondonQueue.Count + " Flyes to London");
                Console.WriteLine(_mng.ParisQueue.Count + " Flyes to Paris");
                Console.WriteLine(_mng.TralalaQueue.Count + " Flyes to - god knows where ");
            }
        }
    }
}