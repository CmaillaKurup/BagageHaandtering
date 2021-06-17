using System;
using System.Runtime.InteropServices;
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
                
                FlightPlan flightPlan = GetFlightplan(tempSuitcase.FlightNumber);
                tempSuitcase.CheckedIn = DateTime.Now;
                tempSuitcase.GateNumber = flightPlan.Gate;
                tempSuitcase.Destination = flightPlan.Destination;
                
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

        public FlightPlan GetFlightplan(int flightNumber)
        {
            for (int i = 0; i < Program.flightPlans.Count; i++)
            {
                if (flightNumber == Program.flightPlans[i].FlightNumber)
                {
                    return Program.flightPlans[i];
                }
            }
            //the most correct would be to have an exception handling here - I might get back to this
            return null;
        }
    }
}