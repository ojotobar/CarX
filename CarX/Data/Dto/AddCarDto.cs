using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Data.Dto
{
    public class AddCarDto
    {
        [Required]
        public string Make { get; set; }
        [Required]
        [DisplayName("Model")]
        public string CarModel { get; set; }
        [Required]
        public int Year { get; set; }
        public string Trim { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public string Color { get; set; }
        public string Interior { get; set; }
        [Required]
        [DisplayName("Drive Train")]
        public string DriveTrain { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        public string Transmission { get; set; }
        public string Vin { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
