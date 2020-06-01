using Microsoft.AspNetCore.Mvc;

namespace SaadiaInventorySystem.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}