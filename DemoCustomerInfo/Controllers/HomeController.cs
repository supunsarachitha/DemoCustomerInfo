using DemoCustomerInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoCustomerInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CustomerModel customer = new CustomerModel();

            List<RegionModel> Objregions = new List<RegionModel>();
            Objregions.Add(new RegionModel() { regionId = 1, RegionName = "Atlantic Region" });
            Objregions.Add(new RegionModel() { regionId = 2, RegionName = "Central Canada" });
            Objregions.Add(new RegionModel() { regionId = 3, RegionName = "The Prairie Provinces" });
            Objregions.Add(new RegionModel() { regionId = 4, RegionName = "The West Coast" });
            Objregions.Add(new RegionModel() { regionId = 5, RegionName = "The Northern Territories" });

            ViewBag.regionsList = Objregions.Select(d => new SelectListItem
            {
                Value = d.regionId.ToString(),
                Text = d.RegionName,
            }).ToList(); 

            if (ModelState.IsValid)
            {
                return View(customer);
            }
            return View(customer);
        }

   
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerModel custmObj)
        {

            if (ModelState.IsValid)
            {

                //using (var client = new HttpClient())
                //{
                //    var content = new StringContent(JsonConvert.SerializeObject(custmObj), System.Text.Encoding.UTF8, "application/json");
                   
                //    var postTask = client.PostAsync("URL", content);
                //    postTask.Wait();

                //    var result = postTask.Result;
                //    if (result.IsSuccessStatusCode)
                //    {
                //        return RedirectToAction("Index");
                //    }
                //}

                
                return RedirectToAction(nameof(Index));
            }


            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return RedirectToAction(nameof(Index));


        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
