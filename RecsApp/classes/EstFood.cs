using System;
using System.ComponentModel.DataAnnotations;


namespace RecsApp
{
    public class EstFood
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }

        public EstFood()
        { 
        }
    }
}
