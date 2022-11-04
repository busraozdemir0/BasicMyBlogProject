using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projem.Models
{
    public class Work
    {
        [Key]
        public int workId { get; set; }
        public string workText { get; set; }

    }
}
