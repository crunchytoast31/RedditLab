using Microsoft.AspNetCore.Mvc;
using RedditLab.Models;
using System.Diagnostics;

namespace RedditLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        RedditDAL api = new RedditDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Rootobject r = api.GetPost();
            //acts as a file path
            Data1 d = r.data.children[1].data;
            return View(d);
        }

        public IActionResult Posts()
        {
            Rootobject r = api.GetPost();
            Child[] posts = r.data.children;
            return View(posts);
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