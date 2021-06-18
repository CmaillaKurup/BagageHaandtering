namespace BagageHåndtering
{
    public class Resevation
    {
        private int passengerNumber;
        private string name;
        private int flightNumber;
        
        public Resevation(int passengerNumber, string name, int flightNumber)
        {
            this.passengerNumber = passengerNumber;
            this.name = name;
            this.flightNumber = flightNumber;
        }

        public int PassengerNumber
        {
            get => passengerNumber;
            set => passengerNumber = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int FlightNumber
        {
            get => flightNumber;
            set => flightNumber = value;
        }
    }
}