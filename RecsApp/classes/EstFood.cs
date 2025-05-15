using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RecsApp
{
    /// <summary>
    /// Класс, описывающий кухню заведения
    /// </summary>
    public class EstFood
    {
        /// <summary>
        /// Уникальный идентификатор типа
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Название кухни заведения
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Заведения с этой кухней
        /// </summary>
        public ICollection<Establishment> Ests { get; set; }
        /// <summary>
        /// Анкеты с этой кухней
        /// </summary>
        public ICollection<Questionnaire> Questionnaires { get; set; }


        public EstFood()
        { 
            Ests = new List<Establishment>();
            Questionnaires = new List<Questionnaire>();
        }
    }
}
