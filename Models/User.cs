using System;
using System.ComponentModel.DataAnnotations;

namespace tenorchem.Models
{
    public class User
    {
        public int id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string passWord { get; set; }
        public Boolean isAdmin { get; set; }
    }

}