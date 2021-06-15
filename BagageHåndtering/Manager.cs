using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    public class Manager
    {
        private List<Suitcases> _suitcasesList;
        private List<Gagts> _gagtsList;
        private List<Counters> _countersList;
        //static object _lock = new object();
        //static Random _random = new Random();
        
        static Queue<int> _CounterQueue = new Queue<int>();
        static Queue<int> _SortingQueue = new Queue<int>();


        private Counters counters = new Counters();
        public Manager()
        {
            Thread counterGet = new Thread(counters.GetLuggage);
            Thread counterMove = new Thread(counters.MoveToSorting);
            
            counterGet.Start();
            counterMove.Start();
        }

        public void NewSuitcases(string name, string destination, int id)
        {
            _suitcasesList.Add(new Suitcases(name, destination, id));
        }
        
        
        // lav en methode som returner en ny suitcase:
        // _suitcasesList.Add( new Suitcases());

    }
}