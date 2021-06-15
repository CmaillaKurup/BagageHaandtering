
using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    public class Counter
    {
        //constructor
        public Counter()
        {
            
        }
        
        static object _lock = new object();
        static Random _random = new Random();
        private static int _id = 0;
        
        //incapsulation
        
        //funktionalitet
        //Producer
        //Consumer
        public void HandleLuggage()
        {
            Console.WriteLine("Counter oppend - Thread started");
            while (true)
            {
                
                Suitcases tempSuitcase;
                lock (Program.mng.CounterQueue)
                {
                    if (Program.mng.CounterQueue.Count == 0)
                    {
                        Monitor.Wait(Program.mng.CounterQueue);   
                    }
                    tempSuitcase = Program.mng.CounterQueue.Dequeue();
                    Monitor.PulseAll(Program.mng.CounterQueue);
                }

                tempSuitcase.CheckedIn = DateTime.Now;
                Thread.Sleep(1000);

                lock (Program.mng.SortingQueue)
                {
                    if (Program.mng.SortingQueue.Count > 9)
                    {
                        Monitor.Wait(Program.mng.SortingQueue);   
                    }
                    Program.mng.SortingQueue.Enqueue(tempSuitcase); 
                    Monitor.PulseAll(Program.mng.SortingQueue);
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
    }
}