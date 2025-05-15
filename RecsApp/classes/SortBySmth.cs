using System.Collections.Generic;

namespace RecsApp
{
    public class SortBySmth : IComparer<Establishment>
    {
        /// <summary>
        /// Значение, задающее тип сортировки
        /// </summary>
        public string SortMode { get; set; }
        /// <summary>
        /// Сортировка по популярности (количество входов на форму с информацией о заведении)
        /// </summary>
        /// <param name="a">Первое заведение</param>
        /// <param name="b">Второе заведение</param>
        /// <returns>Итог сравнения</returns>
        public int Compare(Establishment a, Establishment b)
        {
            switch (this.SortMode.ToLower())
            {
                case "name":
                    return a.Name.CompareTo(b.Name);
                case "type":
                    return a.Type.Title.CompareTo(b.Type.Title);
                case "rating":
                    return b.Rating.CompareTo(a.Rating);
                case "visits":
                    return b.CountVisits.CompareTo(a.CountVisits);
                default:
                    return b.CountVisits.CompareTo(a.CountVisits);
            }
        }
    }
}
