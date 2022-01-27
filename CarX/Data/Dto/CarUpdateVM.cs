using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Data.Dto
{
    public class CarUpdateVM
    {
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
        public string ImageUrl { get; set; }//img
    }
}
