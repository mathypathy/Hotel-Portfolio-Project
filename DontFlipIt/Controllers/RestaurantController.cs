using Microsoft.AspNetCore.Mvc;

namespace DontFlipIt.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
