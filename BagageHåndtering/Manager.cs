using System.Collections.Generic;

namespace BagageHåndtering
{
    public class Manager
    {
        private List<Suitcases> _suitcasesList;
        private List<Sorting> _sortingsList;
        private List<Gagts> _gagtsList;
        private List<Counters> _countersList;

        public Manager()
        {
            _suitcasesList.Add( new Suitcases());
            _sortingsList.Add(new Sorting());
            _gagtsList.Add(new Gagts());
            _countersList.Add(new Counters());
        }

    }
}