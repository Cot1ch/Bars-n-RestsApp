using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RecsApp
{
    public class EstFood
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Establishment> ests { get; set; }

        public EstFood()
        { 
            ests = new List<Establishment>();
        }
    }
}
