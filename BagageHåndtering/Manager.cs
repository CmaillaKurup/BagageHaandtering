using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    public class Manager
    {
        static Queue<Suitcase> _counterQueue = new Queue<Suitcase>();
        static Queue<Suitcase> _sortingQueue = new Queue<Suitcase>();
        static Queue<Suitcase> _gateQueue = new Queue<Suitcase>();
        private static Queue<Suitcase> _londonQueue = new Queue<Suitcase>();
        private static Queue<Suitcase> _parisQueue = new Queue<Suitcase>();
        private static Queue<Suitcase> _tralalaQueue = new Queue<Suitcase>();

        private Counter _counter = new Counter();
        private Sorting _sorting = new Sorting();
        private Gate _gate = new Gate();
        
        public Random _randome = new Random();

        public Manager()
        {
            Thread counter = new Thread(_counter.HandleLuggage);
            Thread sorting = new Thread(_sorting.HanddleLuggage);
            Thread gate = new Thread(_gate.HandleLuggage);

            counter.Start();
            sorting.Start();
            gate.Start();
        }

        public Queue<Suitcase> CounterQueue
        {
            get { return _counterQueue; }
            set { _counterQueue = value; }
        }

        public Queue<Suitcase> SortingQueue
        {
            get { return _sortingQueue; }
            set { _sortingQueue = value; }
        }
        public Queue<Suitcase> GateQueue
        {
            get { return _gateQueue; }
            set { _gateQueue = value; }
        }

        public Random Random
        {
            get { return _randome; }
            set { _randome = value; }
        }

        public Queue<Suitcase> LondonQueue
        {
            get => _londonQueue;
            set => _londonQueue = value;
        }

        public Queue<Suitcase> ParisQueue
        {
            get => _parisQueue;
            set => _parisQueue = value;
        }

        public Queue<Suitcase> TralalaQueue
        {
            get => _tralalaQueue;
            set => _tralalaQueue = value;
        }
        public void NewSuitcase(string name, string destination, int id)
        {
            _counterQueue.Enqueue(new Suitcase(name, destination, id));
        }
    }
}