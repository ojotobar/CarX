using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Data.Dto
{
    public class AboutDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
