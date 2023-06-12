using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _course_service;
        public HomeController(ILogger<HomeController> logger, ProductService _svc)
        {
            _logger = logger;
            _course_service = _svc;
        }

        public IActionResult Index()
        {
            List<Product> listuser = new List<Product>();
            IEnumerable<Product> _course_list = _course_service.GetProdcut();
            return View(_course_list);
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