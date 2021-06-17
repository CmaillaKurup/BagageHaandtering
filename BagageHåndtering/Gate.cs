using System.Threading;

namespace BagageHåndtering
{
    public class Gate
    {
        private string _destinationGate;

        //constructor
        public Gate()
        {
            
        }
        
        //incapsulation
        public string DestinationGate
        {
            get => _destinationGate;
            set => _destinationGate = value;
        }

        //Functionality
        public void HandleLuggage()
        {
            //_destinationGate = Program._suitcase.Destination;

            
            while (true)
            {
                Suitcase tempSuitcase;

                int temp = Program._mng._randome.Next(100, 2000);
                
                lock (Program._mng.GateOneQueue)
                {
                    if (Program._mng.GateOneQueue.Count == 0)
                    {
                        Monitor.Wait(Program._mng.GateOneQueue);
                    }
                    tempSuitcase = Program._mng.GateOneQueue.Dequeue();
                    Monitor.PulseAll(Program._mng.GateOneQueue);
                }
                
                Thread.Sleep(temp);
                
                lock (Program._mng.GateTwoQueue)
                {
                    if (Program._mng.GateTwoQueue.Count > 50 && _destinationGate == "London")
                    {
                        Monitor.Wait(Program._mng.GateTwoQueue);
                    }
                    Program._mng.GateTwoQueue.Enqueue(tempSuitcase);
                    Monitor.PulseAll(Program._mng.GateTwoQueue);
                }
            }
        }
    }
}