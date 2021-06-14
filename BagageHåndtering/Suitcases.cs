namespace BagageHåndtering
{
    public class Suitcases
    {
        private string name;
        private string destination;
        private int id;
        
        //constructor
        public Suitcases(string name, string destination, int id)
        {
            this.name = name;
            this.destination = destination;
            this.id = id;
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
        public int Id
        {
            get => id;
            set => id = value;
        }
        //opret kuffert
        //har methoderne der setter checin time og sorting time
        //øvrige classer benytter disse methoder
        
        //Producer
    }
}