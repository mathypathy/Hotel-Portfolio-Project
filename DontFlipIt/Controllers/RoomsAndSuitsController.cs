using Microsoft.AspNetCore.Mvc;

namespace DontFlipIt.Controllers
{
    public class RoomsAndSuitsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
