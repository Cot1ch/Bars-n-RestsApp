using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RecsApp
{
    public class User
    {
        [Key]
        public Guid user_Id { get; set; } = Guid.NewGuid();
        public string name { get; set; }
        public string username { get; set; }
        public string password_hash { get; set; }
        public ICollection<EstType> est_types { get; set; }
        public ICollection<EstCategory> est_categories { get; set; }
        public ICollection<EstFood> est_foods { get; set; }
        public ICollection<EstAverageCheck> est_averages { get; set; }
        public ICollection<Establishment> Favourite { get; set; }
        public ICollection<Establishment> Hidden { get; set; }

        public User()
        {
            est_types = new List<EstType>();
            est_categories = new List<EstCategory>();
            est_foods = new List<EstFood>();
            est_averages = new List<EstAverageCheck>();
            Favourite = new List<Establishment>();
            Hidden = new List<Establishment>();
        }
    }
}
