using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    public class Manager
    {
        private List<Gagts> _gagtsList;
        private List<Counter> _countersList;
        
        static Queue<Suitcases> _counterQueue = new Queue<Suitcases>();
        static Queue<Suitcases> _sortingQueue = new Queue<Suitcases>();
        static Queue<int> _GateQueue = new Queue<int>();

        private Counter _counter = new Counter();
        public Manager()
        {
            Thread counter = new Thread(_counter.HandleLuggage);

            counter.Start();
        }

        public Queue<Suitcases> CounterQueue
        {
            get { return _counterQueue; }
            set { _counterQueue = value; }
        }

        public Queue<Suitcases> SortingQueue
        {
            get { return _sortingQueue; }
            set { _sortingQueue = value; }
        }

        public void NewSuitcase(string name, string destination, int id)
        {
            _counterQueue.Enqueue(new Suitcases(name, destination, id));
        }
    }
}