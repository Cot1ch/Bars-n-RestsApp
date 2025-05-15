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
        /// Заведения с этой категорией
        /// </summary>
        public ICollection<Establishment> Ests { get; set; }
        /// <summary>
        /// Анкеты с этой категорией
        /// </summary>
        public ICollection<Questionnaire> Questionnaires { get; set; }


        public EstCategory()
        {
            Ests = new List<Establishment>();
            Questionnaires = new List<Questionnaire>();
        }
    }
}
