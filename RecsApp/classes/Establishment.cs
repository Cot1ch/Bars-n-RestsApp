using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    /// <summary>
    /// Класс, описывающий заведение
    /// </summary>
    public class Establishment
    {
        /// <summary>
        /// Уникальный идентификатор заведения
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Название заведения
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание заведения
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Тип заведения
        /// </summary>
        public EstType Type { get; set; }
        /// <summary>
        /// Категории заведения
        /// </summary>
        public ICollection<EstCategory> Categories { get; set; }
        /// <summary>
        /// Кухни заведения
        /// </summary>
        public ICollection<EstFood> Foods { get; set; }
        /// <summary>
        /// Значение среднего чека заведения
        /// </summary>
        public decimal Check { get; set; }
        /// <summary>
        /// Средний чек заведения
        /// </summary>
        public EstAverageCheck Average { get; set; }
        /// <summary>
        /// Рейтинг заведения
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// Адрес заведения
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ссылка на сайт заведения
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Названия изображений заведения
        /// </summary>
        public string PathsToPhoto { get; set; }
        /// <summary>
        /// Список похожих заведений
        /// </summary>
        public string Similar { get; set; }
        /// <summary>
        /// Счетчик посещений заведения
        /// </summary>
        public long CountVisits { get; set; } = 0;
        /// <summary>
        /// Навигационное свойство на пользователей, поместивших заведение в избранные
        /// </summary>
        public ICollection<User> UsersF {  get; set; }
        /// <summary>
        /// Навигационное свойство на пользователей, поместивших заведение в скрытые
        /// </summary>
        public ICollection<User> UsersH {  get; set; }
        public Establishment()
        {
            Id = Guid.NewGuid();
            Categories = new List<EstCategory>();
            Foods = new List<EstFood>();
            UsersF = new List<User>();
            UsersH = new List<User>();
        }
    }
}
