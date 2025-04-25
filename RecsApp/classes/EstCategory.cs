using System;
using System.ComponentModel.DataAnnotations;

namespace RecsApp
{
    public class EstCategory
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public EstCategory()
        {
            //Id = Guid.NewGuid();
        }
    }
}
