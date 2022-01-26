using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string SignUpDate { get; set; } = DateTime.Now.ToLongTimeString();
    }
}
