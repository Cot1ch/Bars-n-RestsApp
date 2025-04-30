using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecsApp
{
    public class User
    {
        [Key]
        public Guid user_Id { get; set; } = Guid.NewGuid();
        public string name { get; set; }
        public string username { get; set; }
        public string password_hash { get; set; }
        public List<Guid> type_id { get; set; }
        public List<Guid> categoty_id { get; set; }
        public List<Guid> food_id { get; set; }
        public List<Guid> average_check {  get; set; }
    }
}
