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

        public static CarToUpdateVM MapCarToUpdate(Car car)
        {
            return new CarToUpdateVM
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Make,
                DriveTrain = car.DriveTrain,
                Trim = car.Trim,
                Odometer = car.Odometer,
                Color = car.Color,
                Interior = car.Interior,
                Engine = car.Engine,
                Year = car.Year,
                Price = car.Price,
                Transmission = car.Transmission,
                Vin = car.Vin
            };
        }

        public static Car MapCar(CarToUpdateVM model, Car car, string imageUrl)
        {
            car.Make = model.Make;
            car.Model = model.Make;
            car.DriveTrain = model.DriveTrain;
            car.Trim = model.Trim;
            car.Odometer = model.Odometer;
            car.Color = model.Color;
            car.Interior = model.Interior;
            car.Engine = model.Engine;
            car.Year = model.Year;
            car.Price = model.Price;
            car.Transmission = model.Transmission;
            car.Vin = model.Vin;
            car.Image = imageUrl;

            return car;
        }

        public static Car MapCarToAdd(AddCarDto vm, string imgUrl)
        {
            return new Car
            {
                Make = vm.Make,
                Model = vm.CarModel,
                Trim = vm.Trim,
                Year = vm.Year,
                DriveTrain = vm.DriveTrain,
                Color = vm.Color,
                Interior = vm.Interior,
                Engine = vm.Engine,
                Price = vm.Price,
                Transmission = vm.Transmission,
                Vin = vm.Vin,
                Odometer = vm.Mileage,
                Image = imgUrl
            };
        }
    }
}
