using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texting.Models;

namespace Texting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var strList = new List<string>();
            var envVars = Environment.GetEnvironmentVariables();

            foreach (string envVar in envVars.Keys)
            {
                strList.Add(envVar);
            }

            strList.Sort();
            return View(strList);
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
