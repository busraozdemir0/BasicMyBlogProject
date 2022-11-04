using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projem.Models
{
    public class About
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string about { get; set; }
        [NotMapped]
        public IFormFile imageUrl { get; set; }
        public string imagePath { get; set; }

    }
}
