using Microsoft.AspNetCore.Mvc;

namespace SaadiaInventorySystem.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}