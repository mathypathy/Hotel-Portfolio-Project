using Microsoft.AspNetCore.Mvc;

namespace DontFlipIt.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
