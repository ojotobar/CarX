using CarX.Data;
using CarX.Data.Dto;
using CarX.Models;
using CarX.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CarX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbcontext ctx;

        public HomeController(ILogger<HomeController> logger, AppDbcontext ctx)
        {
            _logger = logger;
            this.ctx = ctx;
        }

        public IActionResult Index(int pg=1)
        {
            IEnumerable<Car> carList = ctx.Car;

            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = carList.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = carList.Skip(recSkip).Take(pager.PageSize);
            this.ViewBag.Pager = pager;

            return View(data);
        }

        public IActionResult CheckOut(string id)
        {
            var car = ctx.Car.FirstOrDefault(x => x.Id == id);
            var carToSell = Mapper.MapCarToSell(car);
            return View(carToSell);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOut(CarToSellVM vm)
        {
            if (!ModelState.IsValid)
            {
                
                return BadRequest("Invalid entry! Try again.");
            }
            var car = ctx.Car.FirstOrDefault(x => x.Id == vm.Id);
            if (car == null)
            {
                return NotFound();
            }
            return View("Index");
        }

        public IActionResult About()
        {
            List<About> about = ctx.About.ToList();
            return View(about);
        }

        public IActionResult Services()
        {
            IEnumerable<Service> services = ctx.Services;
            return View(services);
        }

        public IActionResult Contact()
        {
            var contact = ctx.Contacts;
            return View(contact);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
