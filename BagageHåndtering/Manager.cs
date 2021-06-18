using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    public class Manager
    {
        static Queue<Suitcase> _counterQueue = new Queue<Suitcase>();
        static Queue<Suitcase> _sortingQueue = new Queue<Suitcase>();
        
        private Counter[] _counterArray = new Counter[10];
        private Sorting _sorting = new Sorting();
        private Gate[] _gateArray = new Gate[2];
        public Random _randome = new Random();

        public Manager()
        {
            Thread sorting = new Thread(_sorting.HanddleLuggage);
            sorting.Start();

            for (int i = 0; i < _gateArray.Length; i++)
            {
                _gateArray[i] = new Gate();
                
                _gateArray[i].Open = true;
            }

            
            for (int i = 0; i < _counterArray.Length; i++)
            {
                _counterArray[i] = new Counter();
                
                _counterArray[i].Open = true;
            }
            
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
        
        public Random Random
        {
            get { return _randome; }
            set { _randome = value; }
        }

        public Gate[] GateArray
        {
            get => _gateArray;
            set => _gateArray = value;
        }
        
        public void NewSuitcase(string name, int flightNumber, int id)
        {
            _counterQueue.Enqueue(new Suitcase(name, flightNumber, id));
        }
    }
}