using System.Collections.Generic;

namespace RecsApp
{
    public class SortByName : IComparer<Establishment>
    {
        public int Compare(Establishment a, Establishment b)
        {
            return b.Name.CompareTo(a.Name);
        }
    }
}
