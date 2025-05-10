using System.Collections.Generic;

namespace RecsApp
{
    internal class SortByVisits : IComparer<Establishment>
    {
        /// <summary>
        /// Сортировка по популярности (количество входов на форму с информацией о заведении)
        /// </summary>
        /// <param name="a">Первое заведение</param>
        /// <param name="b">Второе заведение</param>
        /// <returns>Итог сравнения</returns>
        public int Compare(Establishment a, Establishment b)
        {
            return b.CountVisits.CompareTo(a.CountVisits);
        }
    }
}
