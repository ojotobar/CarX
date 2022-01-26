using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Models
{
    public class Car
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Make { get; set; }//make
        [Required]
        public string Model { get; set; }//model
        [Required]
        public int Year { get; set; }//year
        public string Trim { get; set; }//trim
        [Required]
        public string Engine { get; set; }//engine
        [Required]
        public int Odometer { get; set; }//odometer
        [Required]
        public string Color { get; set; }//color
        public string Interior { get; set; }//interior
        [Required]
        public string Transmission { get; set; }//transmission
        [DisplayName("Drive Train")]
        public string DriveTrain { get; set; }//drivetrain
        [Required]
        public float Price { get; set; }//price
        public string Vin { get; set; }//vin
        [Required]
        public string Image { get; set; }//img
    }
}
