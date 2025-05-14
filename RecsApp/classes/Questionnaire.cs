using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecsApp
{
    /// <summary>
    /// Класс анкеты
    /// </summary>
    public class Questionnaire
    {
        /// <summary>
        /// Идентификатор анкеты и пользователя-хозяина
        /// </summary>
        [Key]
        [ForeignKey("User")]        
        public Guid user_Id { get; set; }
        /// <summary>
        /// Типы заведений, выбранные в анкете
        /// </summary>
        public ICollection<EstType> Est_Types { get; set; }
        /// <summary>
        /// Категории заведений, выбранные в анкете
        /// </summary>
        public ICollection<EstCategory> Est_Categories { get; set; }
        /// <summary>
        /// Кухни заведений, выбранные в анкете
        /// </summary>
        public ICollection<EstFood> Est_Foods { get; set; }
        /// <summary>
        /// Чеки заведений, выбранные в анкете
        /// </summary>
        public ICollection<EstAverageCheck> Est_Average { get; set; }
        /// <summary>
        /// Навигационное свойство на пользователя
        /// </summary>
        public User User { get; set; }

        public Questionnaire()
        {
            Est_Types = new List<EstType>();
            Est_Categories = new List<EstCategory>();
            Est_Foods = new List<EstFood>();
            Est_Average = new List<EstAverageCheck>();
        }
    }
}
