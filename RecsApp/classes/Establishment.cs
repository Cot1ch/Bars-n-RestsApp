using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    public class Establishment
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> Category { get; set; }
        public Guid Type { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
        public string Link { get; set; }
        public List<string> PathsToPhoto { get; set; } = new List<string>();
        public Establishment()
        {
            Id = Guid.NewGuid();
        }
        public Establishment(string name, string description, List<Guid> category, Guid type, double rating, string address, string link, List<string> pathsToPhoto)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Category = category;
            Type = type;
            Rating = rating;
            Address = address;
            Link = link;
            PathsToPhoto = pathsToPhoto;
        }
    }
}
