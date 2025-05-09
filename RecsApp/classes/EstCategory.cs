using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    public class EstCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Establishment> ests { get; set; }

        public EstCategory()
        {
            ests = new List<Establishment>();
        }
    }
}
