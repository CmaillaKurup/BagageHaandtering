using System.Collections.Generic;

namespace BagageHåndtering
{
    public class Gagts
    {
        private string destinationGate; 
        
        //constructor
        public Gagts()
        {
            
        }
        
        //incapsulation
        public string DestinationGate
        {
            get => destinationGate;
            set => destinationGate = value;
        }
        
        //SortingGateQueue
        static Queue<int> _GateQueue = new Queue<int>();

        public void SortingGateQueue()
        {
            
        }
        
        //consumer og tjekker sin egen kø
        public void CheckSortingGateQueu()
        {
            SortingGateQueue();
        }
        
        //samler op fra køen hvis der ligger noget
        public void AddToGate()
        {
            
        }
        
        //skal kunne åbne gate 
        public void OpenQueue()
        {
            
        }
        //skal kunne lukkes igen (en methode til at slette sig selv)
        public void CloseQueue()
        {
            
        }
        //hvis der er bagage kan der samles op og håndteres
    }
}