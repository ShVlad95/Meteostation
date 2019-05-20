using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.DBManager;
using test.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private IDbManager _dataManager;

        public HomeController(IDbManager manager)
        {
            _dataManager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var allRecords = await _dataManager.GetAllResultsAsync();
            return View(allRecords);
        }

        [HttpGet]
        public JsonResult GetJson()
        {
            return Json("Hello from meteostation.");
        }

        public IActionResult ShowMeteData()
        {
            return View();
        }

        [HttpPost]
        public async Task AddDataAsync(Datas data)
        {
            await _dataManager.AddAsync(data);
        }

        public IActionResult AddData(Datas data)
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
