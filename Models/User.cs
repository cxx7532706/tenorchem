using System;

namespace tenorchem.Models
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public Boolean isAdmin { get; set; }
    }

}