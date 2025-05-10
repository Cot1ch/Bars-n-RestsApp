using System.Collections.Generic;

namespace RecsApp
{
    internal class SortByName : IComparer<Establishment>
    {
        /// <summary>
        /// Сортировка по названию заведения
        /// </summary>
        /// <param name="a">Первое заведение</param>
        /// <param name="b">Второе заведение</param>
        /// <returns>Итог сравнения</returns>
        public int Compare(Establishment a, Establishment b)
        {
            return a.Name.CompareTo(b.Name);
        }
    }
}
