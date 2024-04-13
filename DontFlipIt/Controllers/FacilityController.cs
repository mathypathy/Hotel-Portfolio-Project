using Microsoft.AspNetCore.Mvc;

namespace DontFlipIt.Controllers
{
    public class FacilityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
