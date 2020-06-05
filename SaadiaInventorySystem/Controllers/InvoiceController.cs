using Microsoft.AspNetCore.Mvc;

namespace SaadiaInventorySystem.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}