using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Data.Dto
{
    public class UpdatePhotoDto
    {
        public string Id { get; set; }
        [DisplayName("Upload Photo")]
        public IFormFile Photo { get; set; }
    }
}
