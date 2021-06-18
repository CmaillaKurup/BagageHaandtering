using System;

namespace BagageHåndtering
{
    public class FlightPlan
    {
        private string destination;
        private int gate;
        private DateTime flightTime;
        private int flightNumber;

        public FlightPlan(string destination, int gate, int flightNumber)
        {
            this.destination = destination;
            this.gate = gate;
            this.flightNumber = flightNumber;
        }

        public string Destination
        {
            get => destination;
            set => destination = value;
        }

        public int Gate
        {
            get => gate;
            set => gate = value;
        }

        public int FlightNumber
        {
            get => flightNumber;
            set => flightNumber = value;
        }

        
    }
}