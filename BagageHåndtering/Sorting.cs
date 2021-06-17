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
                Suitcase tempSuitcase;
                lock (Program._mng.SortingQueue)
                {
                    if (Program._mng.SortingQueue.Count == 0)
                    {
                        Monitor.Wait(Program._mng.SortingQueue);
                    }
                    tempSuitcase = Program._mng.SortingQueue.Dequeue();
                    Monitor.PulseAll(Program._mng.SortingQueue);
                }
                
                int temp = Program._mng._randome.Next(100, 2000);
                Thread.Sleep(temp);
                
                lock (Program._mng.GateOneQueue)
                {
                    if (Program._mng.GateOneQueue.Count > 9)
                    {
                        Monitor.Wait(Program._mng.GateOneQueue);
                    }
                    Program._mng.GateOneQueue.Enqueue(tempSuitcase);
                    Monitor.PulseAll(Program._mng.GateOneQueue);
                }
            }
        }
        
        //Producer
        //Consumer
    }
}