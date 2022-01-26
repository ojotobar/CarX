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

                var data = System.IO.File.ReadAllText(@"C:\Users\hp\source\repos\CarX\CarX\Data\carX.json");
                var serializedData = JsonConvert.DeserializeObject<List<Car>>(data);
                ctx.SaveChanges();

                if (!ctx.Car.Any())
                {
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
                        Password = "P@ssword123",
                        ConfirmPassword = "P@ssword123"
                    },
                    new RegisterDto
                    {
                        FirstName = "Temitope",
                        LastName = "Dada",
                        Email = "temidada@gmail.com",
                        Phone = "2348031234567",
                        Password = "P@ssword123",
                        ConfirmPassword = "P@ssword123"
                    },
                    new RegisterDto
                    {
                        FirstName = "Damola",
                        LastName = "Faleye",
                        Email = "damolafal@gmail.com",
                        Phone = "2348031234567",
                        Password = "P@ssword123",
                        ConfirmPassword = "P@ssword123"
                    },
                    new RegisterDto
                    {
                        FirstName = "Hannah",
                        LastName = "Eseyin",
                        Email = "hannahesy@gmail.com",
                        Phone = "2348031234567",
                        Password = "P@ssword123",
                        ConfirmPassword = "P@ssword123"
                    },
                    new RegisterDto
                    {
                        FirstName = "Suleman",
                        LastName = "Sanni",
                        Email = "sule.sani@gmail.com",
                        Phone = "2348031234567",
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
                    ImageUrl = "https://ssl.gstatic.com/s2/profiles/images/silhouette200.png",
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
