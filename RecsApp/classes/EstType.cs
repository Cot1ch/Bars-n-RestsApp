using System;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    public class EstType
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }

        public EstType()
        {
            Id = Guid.NewGuid();
        }
    }
}
