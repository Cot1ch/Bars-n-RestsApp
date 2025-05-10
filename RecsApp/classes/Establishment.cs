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
        public decimal Check { get; set; }
        public Guid CheckId { get; set; }
        public EstAverageCheck Average { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
        public string Link { get; set; }
        public string PathsToPhoto { get; set; }
        public string Similar { get; set; }
        public long CountVisits { get; set; } = 0;
        
        public ICollection<User> UsersF {  get; set; }
        public ICollection<User> UsersH {  get; set; }
        public Establishment()
        {
            Id = Guid.NewGuid();
            Categories = new List<EstCategory>();
            Foods = new List<EstFood>();
            UsersF = new List<User>();
            UsersH = new List<User>();
        }

    }
}
