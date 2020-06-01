using Microsoft.AspNetCore.Mvc;

namespace SaadiaInventorySystem.Controllers
{
    public class PartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}