using System.Collections.Generic;

namespace RecsApp
{
    internal class SortByType : IComparer<Establishment>
    {
        /// <summary>
        /// Сортировка по типу (название типа в алфавитном порядке)
        /// </summary>
        /// <param name="a">Первое заведение</param>
        /// <param name="b">Второе заведение</param>
        /// <returns>Итог сравнения</returns>
        public int Compare(Establishment a, Establishment b)
        {
            return a.Type.Title.CompareTo(b.Type.Title);
        }
    }
}
