using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Common.DateTimeControl;
using Data;
using Data.UnitOfWork;
using Entities.HomeEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.HomeViewModels;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _Uw;
        private readonly IConvertDates _Cdate;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork Uw, IConvertDates Cdate)
        {
            _logger = logger;
            _Uw = Uw;
            _Cdate = Cdate;
        }

        public async Task<IActionResult> Index()
        {

            var model = new HomePageIndexViewModels();
            //model.strTest = "StrTest";
            //model.LocalApplications 
            model.LocalApps =  _Uw.BaseRepository<LocalApplications>().FindAllAsync().Result.ToList();

            ViewBag.IP = Request.HttpContext.Connection.RemoteIpAddress;
            //ViewBag.LIP = Request.HttpContext.Connection.LocalIpAddress;


            return View(model);
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
