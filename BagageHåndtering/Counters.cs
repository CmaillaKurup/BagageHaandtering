
using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    public class Counters
    {
        //constructor
        public Counters()
        {
            //Suitcases _suitcases = new Suitcases("", "", 0);
        }
        static object _lock = new object();
        static Random _random = new Random();
        private static int _id = 0;
        static Queue<int> _CounterQueue = new Queue<int>();

        
        //incapsulation
        
        //funktionalitet
        
        public void GetLuggage()
        {
            while (true)
            {
                lock (_lock)
                {
                    _id = _random.Next(1, 10);
                    if (_CounterQueue.Count < 10)
                    {
                        _CounterQueue.Enqueue(_CounterQueue.Count);
                        //Console.WriteLine(_CounterQueue);
                        Monitor.PulseAll(_lock);
                    }
                    else
                    {
                        Monitor.Wait(_lock);
                        //Console.WriteLine("Counter is waiting");
                    }
                    Thread.Sleep(_random.Next(200, 1000));
                }
            }
        }
        //skal give bagae mangelnde informtion
        //sæt checkout tidspunkt
        public void CheckoutTime()
        {
            
        }
        //kig på destination og oversæt til gatenummer
        public void TranslateDestinationToGate()
        {
            
        }
        //flyt fra suitcase til sorting
        public void MoveToSorting()
        {
            while (true)
            {
                lock (_lock)
                {
                    if (_CounterQueue.Count != 0)
                    {
                        if (_CounterQueue.Count > 0)
                        {
                            _CounterQueue.Dequeue();
                            //Console.WriteLine();
                            Monitor.PulseAll(_lock);
                        }
                        else
                        {
                            Monitor.Wait(_lock);
                            //Console.WriteLine();
                        }
                    }

                    Thread.Sleep(_random.Next(200, 1000));
                }
            }
        }
        //Producer
        //Consumer
    }
}