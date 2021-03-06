using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Models
{
    public class Service : BaseClass
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Details { get; set; }
    }
}
