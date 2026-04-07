using Microsoft.AspNetCore.Mvc;

namespace EcommerceMvcApp.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
