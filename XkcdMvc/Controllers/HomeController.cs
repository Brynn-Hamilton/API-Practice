using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XkcdMvc.Models;

namespace XkcdMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        async public Task<IActionResult> Index(string comicnum)
        {
            //create instance of an httpclient
            HttpClient web = new HttpClient();

            // connect to an API server
            web.BaseAddress = new Uri("https://xkcd.com/");
            var connection = await web.GetAsync($"{comicnum}/info.0.json");

            // Get back an instance of our class
            Comic com = await connection.Content.ReadAsAsync<Comic>();
            return View(com);
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

