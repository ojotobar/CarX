using CarX.Data.Dto;
using CarX.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Data
{
    public class Seeder
    {
        private readonly AppDbcontext ctx;
        private readonly UserManager<AppUser> userMgr;
        private readonly RoleManager<IdentityRole> roleMgr;

        public Seeder(AppDbcontext ctx, UserManager<AppUser> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            this.ctx = ctx;
            this.userMgr = userMgr;
            this.roleMgr = roleMgr;
        }

        public async Task Seed()
        {
            try
            {
                ctx.Database.EnsureCreated();
                if (!ctx.Car.Any())
                {
                    var data = System.IO.File.ReadAllText(@"data\\carX.json");
                    var serializedData = JsonConvert.DeserializeObject<List<Car>>(data);
                    foreach (var car in serializedData)
                    {
                        ctx.Add(car);
                    }
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SeedUser()
        {
            var userData = new List<RegisterDto>
                {
                    new RegisterDto
                    {
                        FirstName = "Toba",
                        LastName = "Ojo",
                        Email = "ojotobatr@gmail.com",
                        Phone = "2348031234567",
                        ImageUrl = "https://res.cloudinary.com/deotr/image/upload/v1644162715/og3r9bfjwrnj2mqpnam6.png",
                        Password = "P@ssword123",
                        ConfirmPassword = "P@ssword123"
                    },
                    new RegisterDto
                    {
                        FirstName = "Temitope",
                        LastName = "Dada",
                        Email = "temidada@gmail.com",
                        Phone = "2348031234567",
                        ImageUrl = "https://res.cloudinary.com/enigmatr/image/upload/v1643308429/xfxjrfug1e2j5k5uscha.jpg",
                        Password = "P@ssword123",
                        ConfirmPassword = "P@ssword123"
                    },
                    new RegisterDto
                    {
                        FirstName = "Damola",
                        LastName = "Faleye",
                        Email = "damolafal@gmail.com",
                        Phone = "2348031234567",
                        ImageUrl = "https://res.cloudinary.com/deotr/image/upload/v1644174824/swdmosv7u5r6kxtqrhix.jpg",
                        Password = "P@ssword123",
                        ConfirmPassword = "P@ssword123"
                    },
                    new RegisterDto
                    {
                        FirstName = "Amara",
                        LastName = "Patrick",
                        Email = "amarapat@gmail.com",
                        Phone = "2348031234567",
                        ImageUrl = "https://res.cloudinary.com/enigmatr/image/upload/v1643627050/l7jhxrqpmdc8o3hqs8lu.jpg",
                        Password = "P@ssword123",
                        ConfirmPassword = "P@ssword123"
                    },
                    new RegisterDto
                    {
                        FirstName = "Tobi",
                        LastName = "Akinola",
                        Email = "tobiak@gmail.com",
                        Phone = "2348031234567",
                        ImageUrl = "https://res.cloudinary.com/enigmatr/image/upload/v1644161637/arwbdqlhw1i0o2eqqdnq.jpg",
                        Password = "P@ssword123",
                        ConfirmPassword = "P@ssword123"
                    }

                };

            ctx.Database.EnsureCreated();

            var roles = new string[] { "admin", "regular" };
            if (!roleMgr.Roles.Any())
            {
                foreach (var role in roles)
                {
                    await roleMgr.CreateAsync(new IdentityRole(role));
                }
            }
            ctx.SaveChanges();

            var count = 0;
            foreach (var u in userData)
            {
                var user = new AppUser
                {
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.Phone,
                    ImageUrl = u.ImageUrl,
                    UserName = u.Email
                };
                var res = await userMgr.CreateAsync(user, u.Password);
                if (!res.Succeeded)
                {
                    break;
                }
                var resR = await userMgr.AddToRoleAsync(user, count < 1 ? roles[0] : roles[1]);
                if (!resR.Succeeded)
                {
                    break;
                }
                count++;
            }
            await ctx.SaveChangesAsync();

        }
    }
}
