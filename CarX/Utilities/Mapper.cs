using CarX.Data.Dto;
using CarX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Utilities
{
    public class Mapper
    {
        public static AppUser MapUserToUpdate(AppUser user, UpdateDetailsVM vM)
        {
            user.FirstName = vM.FirstName;
            user.LastName = vM.LastName;
            user.PhoneNumber = vM.PhoneNumber;
            return user;
        }

        public static UpdateDetailsVM MapUserToUpdate(AppUser user)
        {
            var userToUpdate = new UpdateDetailsVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };
            return userToUpdate;
        }

        public static AppUser MapUser(RegisterDto dto, string imgUrl)
        {
            var user = new AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.Phone,
                ImageUrl = imgUrl,
                UserName = dto.Email
            };
            return user;
        }

        public static UpdatePhotoDto MapUpdatePhoto(AppUser user)
        {
            var update = new UpdatePhotoDto
            {
                Id = user.Id,
            };
            return update;
        }

        public static PasswordUpdateDto MapUserPassword(AppUser user)
        {
            var result = new PasswordUpdateDto
            {
                Id = user.Id,
            };
            return result;
        }

        public static UserToDeleteMV MapUserToDelete(AppUser user)
        {
            return new UserToDeleteMV
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl,
                SignUpDate = user.SignUpDate
            };
        }
    }
}
