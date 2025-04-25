using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecsApp
{
    public class Establishment
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Starred { get; set; } = false;
        public int Category { get; set; }
        public int Type { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
        public string Link { get; set; }
        public List<string> PathsToPhoto { get; set; } = new List<string>();
        public Establishment()
        {
            Id = Guid.NewGuid();
        }
    }
}
