using System;
using System.Threading;

namespace BagageHåndtering
{
    public class Counter
    {
        //constructor
        public Counter()
        {
            
        }

        //incapsulation
        
        //funktionalitet

        //Producer
        //Consumer
        public void HandleLuggage()
        {
            Console.WriteLine("Counter oppend - Thread started");
            while (true)
            {
                Suitcase tempSuitcase;
                lock (Program._mng.CounterQueue)
                {
                    if (Program._mng.CounterQueue.Count == 0)
                    {
                        Monitor.Wait(Program._mng.CounterQueue);   
                    }
                    tempSuitcase = Program._mng.CounterQueue.Dequeue();
                    Monitor.PulseAll(Program._mng.CounterQueue);
                }

                tempSuitcase.CheckedIn = DateTime.Now;
                int temp = Program._mng._randome.Next(100, 2000);
                Thread.Sleep(temp);

                lock (Program._mng.SortingQueue)
                {
                    if (Program._mng.SortingQueue.Count > 9)
                    {
                        Monitor.Wait(Program._mng.SortingQueue);   
                    }
                    Program._mng.SortingQueue.Enqueue(tempSuitcase); 
                    Monitor.PulseAll(Program._mng.SortingQueue);
                }
            }
        }
    }
}