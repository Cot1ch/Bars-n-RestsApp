using System.Collections.Generic;

namespace RecsApp
{
    internal class SortByRating : IComparer<Establishment>
    {
        /// <summary>
        /// Сортировка по рейтингу заведения
        /// </summary>
        /// <param name="a">Первое заведение</param>
        /// <param name="b">Второе заведение</param>
        /// <returns>Итог сравнения</returns>
        public int Compare(Establishment a, Establishment b)
        {
            return b.Rating.CompareTo(a.Rating);
        }
    }
}
