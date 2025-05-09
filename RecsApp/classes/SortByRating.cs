using System.Collections.Generic;

namespace RecsApp
{
    internal class SortByRating : IComparer<Establishment>
    {
        public int Compare(Establishment a, Establishment b)
        {
            return b.Rating.CompareTo(a.Rating);
        }
    }
}
