using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    public class Establishment
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EstType Type { get; set; }
        public ICollection<EstCategory> Categories { get; set; }
        public ICollection<EstFood> Foods { get; set; }
        public ICollection<EstAverageCheck> Averages { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
        public string Link { get; set; }
        public List<string> PathsToPhoto { get; set; } = new List<string>();
        public Establishment()
        {
            Id = Guid.NewGuid();
            Categories = new List<EstCategory>();
            Foods = new List<EstFood>();
            Averages = new List<EstAverageCheck>();
        }

    }
}
