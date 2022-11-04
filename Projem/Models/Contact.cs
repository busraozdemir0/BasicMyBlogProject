using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projem.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public string userName { get; set; }
        public string eMail { get; set; }
        public string phoneNumber { get; set; }
    }
}
