using System.Collections.Generic;

namespace RecsApp
{
    internal class SortByType : IComparer<Establishment>
    {
        public int Compare(Establishment a, Establishment b)
        {
            return a.Type.Title.CompareTo(b.Type.Title);
        }
    }
}
