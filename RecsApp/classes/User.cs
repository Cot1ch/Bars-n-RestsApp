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
        //public List<Guid> type_id { get; set; }
        //public List<Guid> categoty_id { get; set; }
        //public List<Guid> food_id { get; set; }
        //public List<Guid> average_check {  get; set; }
        public ICollection<EstType> est_types { get; set; }
        public ICollection<EstCategory> est_categories { get; set; }
        public ICollection<EstFood> est_foods { get; set; }
        public ICollection<EstAverageCheck> est_averages { get; set; }

        public User()
        {
            //type_id = new List<Guid>();
            //categoty_id = new List<Guid>();
            //food_id = new List<Guid>();
            //average_check = new List<Guid>();
            est_types = new List<EstType>();
            est_categories = new List<EstCategory>();
            est_foods = new List<EstFood>();
            est_averages = new List<EstAverageCheck>();
        }
    }
}
