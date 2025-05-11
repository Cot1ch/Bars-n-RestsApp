using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    /// <summary>
    /// Класс, описывающий тип заведения
    /// </summary>
    public class EstType
    {
        /// <summary>
        /// Уникальный идентификатор типа
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Название типа
        /// </summary>
        public string Title { get; set; }
        public ICollection<Establishment> Establishments { get; set; }

        public EstType()
        { 
            Establishments = new List<Establishment>();
        }
    }
}
