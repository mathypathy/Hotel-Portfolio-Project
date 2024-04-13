using Microsoft.AspNetCore.Mvc;

namespace DontFlipIt.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
