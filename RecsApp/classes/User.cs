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
        public Questionnaire Questionnaire { get; set; }
        public ICollection<Establishment> Favourite { get; set; }
        public ICollection<Establishment> Hidden { get; set; }
        public User()
        {
            Favourite = new List<Establishment>();
            Hidden = new List<Establishment>();
        }
    }
}
