using CarX.Data;
using CarX.Data.Dto;
using CarX.Models;
using CarX.Utilities;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbcontext ctx;
        private readonly UserManager<AppUser> userMgr;
        private readonly SignInManager<AppUser> signInMgr;
        private readonly Cloudinary cloud;

        public AdminController(AppDbcontext ctx, UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr, IOptions<CloudinarySettings> config)
        {
            this.ctx = ctx;
            this.userMgr = userMgr;
            this.signInMgr = signInMgr;
            var account = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
            cloud = new Cloudinary(account);
        }
        public IActionResult Index()
        {
            IEnumerable<AppUser> users = ctx.Users;
            return View(users);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userMgr.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userToUpdate = Mapper.MapUserToUpdate(user);
            return View(userToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UpdateDetailsVM model)
        {
            var user = await userMgr.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.HasErrors = true;
                ViewBag.Error = "User not found";
                return View(model);
            }

            var newUser = Mapper.MapUserToUpdate(user, model);
            var update = await userMgr.UpdateAsync(newUser);

            if (!update.Succeeded)
            {
                ViewBag.HasErrors = true;
                ViewBag.Error = "User details update failed";
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userMgr.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userToDelete = Mapper.MapUserToDelete(user);
            return View(userToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(UserToDeleteMV model)
        {
            var user = await userMgr.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.HasErrors = true;
                ViewBag.Error = "User not found";
                return View(model);
            }
            //await signInMgr.SignOutAsync();
            var remove = await userMgr.DeleteAsync(user);
            if (remove.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ViewBag.HasErrors = true;
            ViewBag.Error = "User removal failed";
            return View(model);
        }

        public IActionResult Cars()
        {
            IEnumerable<Car> carList = ctx.Car;
            return View(carList);
        }

        public IActionResult EditCar(string id)
        {
            var car = ctx.Car.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            var carToUpdate = Mapper.MapCarToUpdate(car);
            return View(carToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCar(CarToUpdateVM vm)
        {
            var car = await ctx.Car.FirstOrDefaultAsync(x => x.Id == vm.Id);
            if (car == null)
            {
                ViewBag.HasErrors = true;
                ViewBag.Error = "No such car exists";
                return View(vm);
            }

            var result = UploadPhoto(vm.Image);
            var status = result.StatusCode.ToString();
            if (status.Equals("OK"))
            {
                var newCar = Mapper.MapCar(vm, car, result.Url.ToString());
                ctx.Update(newCar);
                var res = await ctx.SaveChangesAsync();
                if (res > 0)
                {
                    return RedirectToAction("Cars");
                }
                ViewBag.HasErrors = true;
                ViewBag.Error = "Update failed. Try again!";
                return View(vm);
            }
            ViewBag.HasErrors = true;
            ViewBag.Error = "Something went wrong. Try again";
            return View(vm);
        }

        public IActionResult DeleteCar(string id)
        {
            var car = ctx.Car.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCar(Car car)
        {
            var carToDelete = await ctx.Car.FirstOrDefaultAsync(x => x.Id == car.Id);
            if (carToDelete == null)
            {
                return NotFound();
            }
            ctx.Car.Remove(carToDelete);
            var res = await ctx.SaveChangesAsync();
            if (res > 0)
            {
                return RedirectToAction("Cars");
            }
            ViewBag.HasErrors = true;
            ViewBag.Error = "Removal operation failed. Try again";
            return View(car);
        }

        public ImageUploadResult UploadPhoto(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            using (var stream = file.OpenReadStream())
            {
                var imageUploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation()
                };
                uploadResult = cloud.Upload(imageUploadParams);
            }

            return uploadResult;
        }
    }
}
