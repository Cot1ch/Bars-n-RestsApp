using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecsApp
{
    public class Questionnaire
    {
        [Key]
        [ForeignKey("User")]
        public Guid user_Id { get; set; }
        public ICollection<EstType> Est_Types { get; set; }
        public ICollection<EstCategory> Est_Categories { get; set; }
        public ICollection<EstFood> Est_Foods { get; set; }
        public ICollection<EstAverageCheck> Est_Average { get; set; }
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
