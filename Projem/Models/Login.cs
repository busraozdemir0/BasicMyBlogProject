using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Login
    {
        [Key]
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string eMail { get; set; }

    }
}
