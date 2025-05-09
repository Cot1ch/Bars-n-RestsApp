using System.Collections.Generic;

namespace RecsApp
{
    public class SortByVisits : IComparer<Establishment>
    {
        public int Compare(Establishment a, Establishment b)
        {
            return b.CountVisits.CompareTo(a.CountVisits);
        }
    }
}
