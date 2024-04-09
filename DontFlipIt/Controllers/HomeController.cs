using Microsoft.AspNetCore.Mvc;

namespace DontFlipIt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
