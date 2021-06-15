using System.Threading;

namespace BagageHåndtering
{
    public class Sorting
    {
        //constructor
        public Sorting()
        {
            
        }
        //incapsulation
        
        //funktionalitet
        public void HanddleLuggage()
        {
            while (true)
            {
                Suitcases tempSuitcase;
                lock (Program.mng.SortingQueue)
                {
                    if (Program.mng.SortingQueue.Count == 0)
                    {
                        Monitor.Wait(Program.mng.SortingQueue);
                    }
                    tempSuitcase = Program.mng.SortingQueue.Dequeue();
                    Monitor.PulseAll(Program.mng.SortingQueue);
                }
                Thread.Sleep(1000);
                lock (Program.mng.GateQueue)
                {
                    if (Program.mng.GateQueue.Count > 9)
                    {
                        Monitor.Wait(Program.mng.GateQueue);
                    }
                    Program.mng.GateQueue.Enqueue(tempSuitcase);
                    Monitor.PulseAll(Program.mng.GateQueue);
                }
            }
        }
        
        //Producer
        //Consumer
    }
}