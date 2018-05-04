using Microsoft.AspNetCore.Mvc;

namespace Weather.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Json("Welcome in Weather API");
        }
    }
}