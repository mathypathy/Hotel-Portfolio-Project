using Microsoft.AspNetCore.Mvc;

namespace DontFlipIt.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
