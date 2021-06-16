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
            _destinationGate = Program._suitcase.Destination;

            while (true)
            {
                Suitcase tempLondon;
                Suitcase tempParis;
                Suitcase tempTralala;
                int temp = Program._mng._randome.Next(100, 2000);
                
                lock (Program._mng.GateQueue)
                {
                    if (Program._mng.GateQueue.Count == 0)
                    {
                        Monitor.Wait(Program._mng.GateQueue);
                    }
                    tempLondon = Program._mng.GateQueue.Dequeue();
                    Monitor.PulseAll(Program._mng.GateQueue);
                }
                
                
                Thread.Sleep(temp);
                
                lock (Program._mng.LondonQueue)
                {
                    if (Program._mng.LondonQueue.Count > 50 && _destinationGate == "London")
                    {
                        Monitor.Wait(Program._mng.LondonQueue);
                    }
                    Program._mng.LondonQueue.Enqueue(tempLondon);
                    Monitor.PulseAll(Program._mng.LondonQueue);
                }
                
                lock (Program._mng.GateQueue)
                {
                    if (Program._mng.GateQueue.Count == 0)
                    {
                        Monitor.Wait(Program._mng.GateQueue);
                    }
                    tempParis = Program._mng.GateQueue.Dequeue();
                    Monitor.PulseAll(Program._mng.GateQueue);
                }
                
                Thread.Sleep(temp);
                
                lock (Program._mng.ParisQueue)
                {
                    if (Program._mng.ParisQueue.Count > 50 && _destinationGate == "Paris")
                    {
                        Monitor.Wait(Program._mng.ParisQueue);
                    }
                    Program._mng.ParisQueue.Enqueue(tempParis);
                    Monitor.PulseAll(Program._mng.ParisQueue);
                }
                
                lock (Program._mng.GateQueue)
                {
                    if (Program._mng.GateQueue.Count == 0)
                    {
                        Monitor.Wait(Program._mng.GateQueue);
                    }
                    tempTralala = Program._mng.GateQueue.Dequeue();
                    Monitor.PulseAll(Program._mng.GateQueue);
                }
                
                Thread.Sleep(temp);
                
                lock (Program._mng.TralalaQueue)
                {
                    if (Program._mng.TralalaQueue.Count > 50)
                    {
                        Monitor.Wait(Program._mng.TralalaQueue);
                    }
                    Program._mng.TralalaQueue.Enqueue(tempTralala);
                    Monitor.PulseAll(Program._mng.TralalaQueue);
                }
            }
        }
    }
}