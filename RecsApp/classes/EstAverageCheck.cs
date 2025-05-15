using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    /// <summary>
    /// Класс, описывающий средний чек заведения
    /// </summary>
    public class EstAverageCheck
    {
        /// <summary>
        /// Уникальный идентификатор заведения
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Значение среднего чека
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Заведения с этоим чеком
        /// </summary>
        public ICollection<Establishment> Ests { get; set; }
        /// <summary>
        /// Анкеты с этим чеком
        /// </summary>
        public ICollection<Questionnaire> Questionnaires { get; set; }
        public EstAverageCheck()
        {
            Ests = new List<Establishment>();
            Questionnaires = new List<Questionnaire>();
        }
    }
}
