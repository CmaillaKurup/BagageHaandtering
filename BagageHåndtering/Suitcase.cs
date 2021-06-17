using System;

namespace BagageHåndtering
{
    public class Suitcase
    {
        private string name;
        private string destination;
        private int gateNumber;
        private int flightNumber;
        private int luggageId;
        private DateTime checkedIn;

        //constructor
        public Suitcase(string name, int flightNumber, int luggageId)
        {
            this.name = name;
            this.flightNumber = flightNumber;
            this.luggageId = luggageId;
        }

        //incapsulation
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Destination
        {
            get => destination;
            set => destination = value;
        }

        public int GateNumber
        {
            get => gateNumber;
            set => gateNumber = value;
        }
        public int FlightNumber
        {
            get => flightNumber;
            set => flightNumber = value;
        }
        public int Id
        {
            get => luggageId;
            set => luggageId = value;
        }

        public DateTime CheckedIn
        {
            get => checkedIn;
            set => checkedIn = value;
        }
    }
}