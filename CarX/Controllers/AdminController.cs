using CarX.Data;
using CarX.Data.Dto;
using CarX.Models;
using CarX.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public AdminController(AppDbcontext ctx, UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr)
        {
            this.ctx = ctx;
            this.userMgr = userMgr;
            this.signInMgr = signInMgr;
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
    }
}
