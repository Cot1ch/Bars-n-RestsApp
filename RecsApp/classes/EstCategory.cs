using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    /// <summary>
    /// Класс, лписывающий категорию заведения
    /// </summary>
    public class EstCategory
    {
        /// <summary>
        /// Уникальный идентификатор категории заведения
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Название категории заведения
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Навигационное свойство на заведения с этой категорией
        /// </summary>
        public ICollection<Establishment> Ests { get; set; }

        public EstCategory()
        {
            Ests = new List<Establishment>();
        }
    }
}
