using CarX.Services.Implementations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<bool> DeletePhoto(string id);
        Task<PhotoUploadResult> UploadPhoto(IFormFile photo);
    }
}
