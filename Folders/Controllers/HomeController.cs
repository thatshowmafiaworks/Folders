using Folders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Folders.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(FoldersContext context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
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