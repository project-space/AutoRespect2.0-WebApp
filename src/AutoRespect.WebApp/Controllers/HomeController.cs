using Microsoft.AspNetCore.Mvc;

namespace AutoRespect.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
