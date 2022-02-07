using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Models
{
    public class Contact : BaseClass
    {
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
    }
}
