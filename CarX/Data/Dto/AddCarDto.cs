using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Data.Dto
{
    public class AddCarDto
    {
        public string Make { get; set; }
        public string CarModel { get; set; }
        public int Year { get; set; }
        public float Mileage { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public string DriveTrain { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Vin { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
