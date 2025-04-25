using System;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    public class EstCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }

        public EstCategory()
        {
        }
    }
}
