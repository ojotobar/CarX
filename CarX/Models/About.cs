using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Models
{
    public class About : BaseClass
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public string PublicId { get; set; } = "Empty";
    }
}
