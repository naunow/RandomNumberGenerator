using System;
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
            var initialModel = InitializeRandomNumber();

            return View(initialModel);
        }

        /// <summary>
        /// Addボタン押下時
        /// </summary>
        /// <param name="addend"></param>
        /// <param name="result"></param>
        /// <returns></returns>
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

        /// <summary>
        /// NEW ROUNDボタン押下時
        /// </summary>
        /// <returns></returns>
        public string Reset()
        {
            var initialModel = InitializeRandomNumber();

            return JsonConvert.SerializeObject(initialModel);
        }

        /// <summary>
        /// ランダムナンバーの初期化
        /// </summary>
        /// <returns></returns>
        private RandomNumber InitializeRandomNumber()
        {
            var random = new Random();
            var initialModel = new RandomNumber
            {
                Number1 = random.Next(1, 10),
                Number2 = random.Next(1, 10),
                Number3 = random.Next(1, 10),
                Number4 = random.Next(1, 10),
                Target  = random.Next(10, 50),
                Result = 0,
            };

            return initialModel;
        }
    }
}
