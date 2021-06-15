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
                int temp = Program.mng._randome.Next(100, 2000);
                Thread.Sleep(temp);

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
    }
}