﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

        public IActionResult Index(RandomNumber model)
        {
            // 初期値を設定
            model.LeftNumber = new Random().Next(1, 10);
            model.RightNumber = new Random().Next(1, 10);

            model.Result = 0;

            return View(model);
        }

        [HttpGet]
        public string Cal(int addend, int result)
        {
            result = addend + result;

            var stringResult = new 
            {
                Number = new Random().Next(1, 10),
                Result = result, 
            };

            var json = JsonConvert.SerializeObject(stringResult);

            return json;
        }
    }
}
