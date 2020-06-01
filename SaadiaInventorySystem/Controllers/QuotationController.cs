using Microsoft.AspNetCore.Mvc;

namespace SaadiaInventorySystem.Controllers
{
    public class QuotationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}