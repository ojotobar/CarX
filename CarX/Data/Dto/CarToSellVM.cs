using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Data.Dto
{
    public class CarToSellVM
    {
        public string Id { get; set; }
        public string Make { get; set; }//make
        public string Model { get; set; }//model
        public int Year { get; set; }//year
        public string Trim { get; set; }//trim
        public string Engine { get; set; }//engine
        public int Odometer { get; set; }//odometer
        public string Color { get; set; }//color
        public string Interior { get; set; }//interior
        public string Transmission { get; set; }//transmission
        public string DriveTrain { get; set; }//drivetrain
        public float Price { get; set; }//price
        public string Vin { get; set; }//vin
        public string ImageUrl { get; set; }//image

        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.CreditCard)]
        [DisplayName("Card Number")]
        [Required]
        public string PayCardNumber { get; set; }
        
        [DisplayName("Month")]
        [Range(1, 12)]
        [Required]
        public int ExpiryMonth { get; set; }

        
        [DisplayName("Year")]
        [Required]
        [Range(22, 99)]
        public int ExpiryYear { get; set; }
        [Required]
        public int CVV { get; set; }
    }
}
