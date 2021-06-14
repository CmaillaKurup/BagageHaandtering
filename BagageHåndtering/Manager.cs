using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    public class Manager
    {
        private List<Suitcases> _suitcasesList;
        //private List<Sorting> _sortingsList;
        private List<Gagts> _gagtsList;
        private List<Counters> _countersList;
        static object _lock = new object();
        static Random _random = new Random();
        
        static Queue<int> _suitcaseCounterQueue = new Queue<int>();
        static Queue<int> _counterSortingQueue = new Queue<int>();

        //suitcaseCounterQueue
        //counterSortingQueue
        
        public Manager()
        {
            //_suitcasesList.Add( new Suitcases());
            //_sortingsList.Add(new Sorting());
            //_gagtsList.Add(new Gagts());
            //_countersList.Add(new Counters());
        }

        public void ProduceBag()
        {
            while (true)
            {
                lock (_lock)
                {
                    //id = _random.Next(1, 10);
                    if (_suitcasesList.Count < 10)
                    {
                        //_suitcasesList.Enqueue(_something.Length);
                        Console.WriteLine();
                        Monitor.PulseAll(_lock);
                    }
                    else
                    {
                        Monitor.Wait(_lock);
                        Console.WriteLine();
                    }
                }
                Thread.Sleep(_random.Next(200, 1000));
            }
        }

        
        public void NewSuitcases(string name, string destination, int id)
        {
            _suitcasesList.Add(new Suitcases(name, destination, id));
        }
        
        
        // lav en methode som returner en ny suitcase:
        // _suitcasesList.Add( new Suitcases());

    }
}