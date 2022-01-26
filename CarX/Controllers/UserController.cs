using CarX.Data;
using CarX.Data.Dto;
using CarX.Models;
using CarX.Services.Interfaces;
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
    public class UserController : Controller
    {
        private readonly AppDbcontext ctx;
        private readonly UserManager<AppUser> userMgr;
        private readonly SignInManager<AppUser> signInMgr;
        private readonly IJwtService jwt;
        private readonly Cloudinary cloud;

        public UserController(AppDbcontext ctx, UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr, IOptions<CloudinarySettings> config, IJwtService jwt)
        {
            this.ctx = ctx;
            this.userMgr = userMgr;
            this.signInMgr = signInMgr;
            this.jwt = jwt;
            var account = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
            cloud = new Cloudinary(account);
        }
        public IActionResult Index()
        {
            var userId = userMgr.GetUserId(HttpContext.User);
            var user = userMgr.FindByIdAsync(userId).Result;
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.HasErrors = true;
                ViewBag.Error = "Something went wrong. Try again";
                return View(dto);
            }

            var user = await userMgr.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                ViewBag.HasErrors = true;
                ViewBag.Error = "User not found";
                return View(dto);
            }

            var pass = await signInMgr.PasswordSignInAsync(user, dto.Password, dto.RememberMe, false);
            if (!pass.Succeeded)
            {
                return View(dto);
            }

            var roles = await userMgr.GetRolesAsync(user);
            //return to home view
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await signInMgr.SignOutAsync();

            return RedirectToAction("Login");
        }

        //edit user details
        public IActionResult EditProfile()
        {
            var userId = userMgr.GetUserId(HttpContext.User);
            var user = userMgr.FindByIdAsync(userId).Result;
            var userToUpdate = Mapper.MapUserToUpdate(user);
            return View(userToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UpdateDetailsVM model)
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

        public IActionResult ChangeImage()
        {
            var userId = userMgr.GetUserId(HttpContext.User);
            var user = userMgr.FindByIdAsync(userId).Result;
            var userToUpdate = Mapper.MapUpdatePhoto(user);
            return View(userToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeImage(UpdatePhotoDto dto)
        {
            var user = await userMgr.FindByIdAsync(dto.Id);
            if (user == null)
            {
                ViewBag.HasErrors = true;
                ViewBag.Error = "User does not exist.";
                return View(dto);
            }
            
            string imgUrl = "https://ssl.gstatic.com/s2/profiles/images/silhouette200.png";
            if (dto.Photo.Length > 0)
            {
                var uploadResult = UploadPhoto(dto.Photo);
                var status = uploadResult.StatusCode.ToString();
                if (status.Equals("OK"))
                {
                    imgUrl = uploadResult.Url.ToString();
                }
            }

            user.ImageUrl = imgUrl;
            var update = await userMgr.UpdateAsync(user);
            if (update.Succeeded)
            {
                ViewBag.HasErrors = false;
                ViewBag.Success = "Photo updated successfully";
                return RedirectToAction("Index");
            }

            ViewBag.HasErrors = true;
            ViewBag.Error = "Photo update failed. Try again.";
            return View(dto);
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }

            var user = await userMgr.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(PasswordUpdateDto dto)
        {
            return View();
        }

        public IActionResult Deactivate()
        {
            var userId = userMgr.GetUserId(HttpContext.User);
            var user = userMgr.FindByIdAsync(userId).Result;
            var confirmPw = Mapper.MapUserPassword(user);
            return View(confirmPw);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(PasswordUpdateDto model)
        {
            var user = await userMgr.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.HasErrors = true;
                ViewBag.Error = "User not found";
                return View(model);
            }
            var pass = await signInMgr.PasswordSignInAsync(user, model.NewPassword, false, false);
            if (pass.Succeeded)
            {
                await signInMgr.SignOutAsync();
                var remove = await userMgr.DeleteAsync(user);
                if (remove.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.HasErrors = true;
            ViewBag.Error = "Deactivation failed";
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.HasErrors = true;
                ViewBag.Error = "Invalid input. Try again!";
                return View(dto);
            }

            string imgUrl = "https://ssl.gstatic.com/s2/profiles/images/silhouette200.png";
            if (dto.Photo.Length > 0)
            {
                var uploadResult = UploadPhoto(dto.Photo);
                var status = uploadResult.StatusCode.ToString();
                if (status.Equals("OK"))
                {
                    imgUrl = uploadResult.Url.ToString();
                }
            }

            var existingUser = await userMgr.FindByEmailAsync(dto.Email);
            if (existingUser == null)
            {
                var user = Mapper.MapUser(dto, imgUrl);
                var response = await userMgr.CreateAsync(user, dto.Password);
                if (response.Succeeded)
                {
                    var res = await userMgr.AddToRoleAsync(user, userMgr.Users.Any() ? "regular" : "admin");
                    if (res.Succeeded)
                    {
                        //return to login view
                        return RedirectToAction("Login");
                    }
                    return View(dto);
                }
                return View(dto);
            }
            ViewBag.HasErrors = true;
            ViewBag.Error = "User with email already exists";
            return View(dto);
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
