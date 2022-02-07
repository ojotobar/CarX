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

            var imgUrl = car.Image;
            if (vm.Image.Length > 0)
            {
                var result = UploadPhoto(vm.Image);
                var status = result.StatusCode.ToString();
                if (status.Equals("OK"))
                {
                    imgUrl = result.Url.ToString();
                }
            }
            var newCar = Mapper.MapCar(vm, car, imgUrl);
            ctx.Update(newCar);
            var res = await ctx.SaveChangesAsync();
            if (res > 0)
            {
                return RedirectToAction("Cars");
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

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCar(AddCarDto model)
        {
            if (model.Image.Length > 0)
            {
                var uploadResult = UploadPhoto(model.Image);
                var status = uploadResult.StatusCode.ToString();
                if (status.Equals("OK"))
                {
                    var car = Mapper.MapCarToAdd(model, uploadResult.Url.ToString());
                    ctx.Add(car);
                    ctx.SaveChanges();
                    return RedirectToAction("Cars");
                }

                return View(model);
            }

            return View(model);
        }

        public IActionResult About()
        {
            List<About> about = ctx.About.ToList();
            return View(about);
        }

        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAbout(AboutDto model)
        {
            if (model.Image.Length > 0)
            {
                var uploadResult = UploadPhoto(model.Image);
                var status = uploadResult.StatusCode.ToString();
                if (status.Equals("OK"))
                {
                    var about = new About
                    {
                        Title = model.Title,
                        Details = model.Description,
                        ImgUrl = uploadResult.Url.ToString()
                    };

                    ctx.Add(about);
                    ctx.SaveChanges();
                    return RedirectToAction("About");
                }
            }
            return View(model);
        }

        public IActionResult EditAbout(string id)
        {
            var about = ctx.About.First(x => x.Id == id);
            var aboutToUpdate = new AboutToUpdateVM { Id = about.Id, Title = about.Title, Details = about.Details };
            return View(aboutToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAbout(AboutToUpdateVM vm)
        {
            var about = await ctx.About.FirstOrDefaultAsync(x => x.Id == vm.Id);
            if (about == null)
            {
                return View(vm);
            }

            //var imgUrl = about.ImgUrl;
            if (vm.Image.Length > 0)
            {
                var result = UploadPhoto(vm.Image);
                var status = result.StatusCode.ToString();
                if (status.Equals("OK"))
                {
                    about.ImgUrl = result.Url.ToString();
                }
            }
            about.Title = vm.Title;
            about.Details = vm.Details;
            
            ctx.Update(about);
            var res = await ctx.SaveChangesAsync();
            if (res > 0)
            {
                return RedirectToAction("About");
            }
            return View(vm);
        }

        public IActionResult Services()
        {
            IEnumerable<Service> services = ctx.Services;
            return View(services);
        }

        public IActionResult DeleteService(string id)
        {
            var service = ctx.Services.First(x => x.Id == id);
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteService(Service model)
        {
            var service = ctx.Services.First(x => x.Id == model.Id);
            if (service == null)
            {
                return NotFound();
            }

            ctx.Remove(service);
            var res = await ctx.SaveChangesAsync();
            if (res > 0)
            {
                return RedirectToAction("Services");
            }

            return View(model);
        }

        public IActionResult EditService(string id)
        {
            var service = ctx.Services.First(x => x.Id == id);
            var serviceToUpdate = new ServiceToUpdateVM { Id = service.Id, Title = service.Title, Details = service.Details };
            return View(serviceToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditService(ServiceToUpdateVM model)
        {
            var service = ctx.Services.First(x => x.Id == model.Id);
            if (service == null)
            {
                return NotFound();
            }

            service.Title = model.Title;
            service.Details = model.Details;
            ctx.Update(service);
            var res = await ctx.SaveChangesAsync();

            if (res > 0)
            {
                return RedirectToAction("Services");
            }
            return View(model);
        }

        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(ServicesDto model)
        {
            var service = new Service
            {
                Title = model.Title,
                Details = model.Details
            };

            ctx.Services.Add(service);
            var res = await ctx.SaveChangesAsync();
            if (res > 0)
            {
                return RedirectToAction("Services");
            }
            return View(model);
        }

        public IActionResult Contact()
        {
           IEnumerable<Contact> contacts = ctx.Contacts;
            return View(contacts);
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddContact(ContactVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var contact = new Contact { Address = vm.Address, Email = vm.Email, Phone = vm.PhoneNumber };
            await ctx.AddAsync(contact);
            var res = await ctx.SaveChangesAsync() > 0;
            if (!res)
            {
                return View(vm);
            }
            return RedirectToAction("Contact");
        }

        public IActionResult DeleteContact(string id)
        {
            var contact = ctx.Contacts.FirstOrDefault(x => x.Id == id);
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContact(Contact model)
        {
            var contact = ctx.Contacts.FirstOrDefault(x => x.Id == model.Id);
            if (contact == null)
            {
                return NotFound();
            }

            ctx.Remove(contact);
            var res = await ctx.SaveChangesAsync();
            if (res > 0)
            {
                return RedirectToAction("Contact");
            }

            return View(model);
        }

        public IActionResult EditContact(string id)
        {
            var contact = ctx.Contacts.FirstOrDefault(x => x.Id == id);
            var update = new ContactToEditVM { Id = contact.Id, Address = contact.Address, Email = contact.Email, Phone = contact.Phone };
            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContact(ContactToEditVM vm)
        {
            var contact = ctx.Contacts.FirstOrDefault(x => x.Id == vm.Id);
            if (contact == null)
            {
                return NotFound();
            }

            contact.Address = vm.Address;
            contact.Email = vm.Email;
            contact.Phone = vm.Phone;

            var res = await ctx.SaveChangesAsync() > 0;
            if (!res)
            {
                return View(vm);
            }

            return RedirectToAction("Contact");
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdmin(RegisterDto dto)
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
                    var res = await userMgr.AddToRoleAsync(user, "admin");
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
