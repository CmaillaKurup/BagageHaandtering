using System;
using System.Threading;

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
        
        //Adding a new suitcase
        public void NewSuitcase()
        {
            
        }

        //This methode is used by counter
        public void SetCheckinTime()
        {
            
        }

        //This methode is used by sorting
        public void SetSortingTime()
        {
            
        }

        //Producer
    }
}