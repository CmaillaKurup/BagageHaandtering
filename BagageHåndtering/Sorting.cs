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
                
                Gate gate = Program._mng.GateArray[tempSuitcase.GateNumber];
                
                lock (gate.GateQueue)
                {
                    if (gate.GateQueue.Count == 0)
                    {
                        Monitor.Wait(gate.GateQueue);
                    }
                    
                    if (gate.GateQueue.Count > 9)
                    {
                        gate.GateQueue.Enqueue(tempSuitcase);
                        Monitor.PulseAll(gate.GateQueue);
                    }
                    
                }
            }
        }
    }
}