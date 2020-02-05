using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomNumberGenerator.Models;

namespace RandomNumberGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region 規定のメソッド
        //public IActionResult Index()
        //{

        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        public IActionResult Index(RandomNumber model, string buttonName = "left")
        {
            if (buttonName == "left")
            {
                model.Result = model.LeftNumber + model.Result;
                model.LeftNumber = new Random().Next(0, 10);
            }
            else if (buttonName == "right")
            {
                model.Result = model.RightNumber + model.Result;
                model.RightNumber = new Random().Next(0, 10);

            }
            else
            {
                // 初期値を設定
                model.LeftNumber = 1;
                model.RightNumber = 2;

                model.Result = 0;

            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Cal(RandomNumber model)
        {

            return View("Index", model);
        }
    }
}
