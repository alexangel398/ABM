using Microsoft.AspNetCore.Mvc;

namespace ABMProveedores.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
