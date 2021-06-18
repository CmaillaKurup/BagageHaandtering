using System.Collections.Generic;
using System.Threading;

namespace BagageHåndtering
{
    public class Gate
    {
        private Queue<Suitcase> _gateQueue = new Queue<Suitcase>();
        private bool open;

        //constructor
        public Gate()
        {
            Thread worker = new Thread(HandleLuggage);
            worker.Start();
        }
        
        //incapsulation
       
        public Queue<Suitcase> GateQueue
        {
            get => _gateQueue;
            set => _gateQueue = value;
        }

        //Functionality
        public void HandleLuggage()
        {
            while (true)
            {
                Suitcase tempSuitcase;

                int temp = Program._mng._randome.Next(100, 2000);
                
                lock (GateQueue)
                {
                    if (GateQueue.Count == 0)
                    {
                        Monitor.Wait(GateQueue);
                    }
                    tempSuitcase = GateQueue.Dequeue();
                    Monitor.PulseAll(GateQueue);
                }
                Thread.Sleep(temp);
            }
        }
    }
}