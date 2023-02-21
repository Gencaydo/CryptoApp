using Microsoft.AspNetCore.Mvc;

namespace CryptoWeb.Controllers
{
    public class CryptoController : Controller
    {
        public IActionResult CryptoValues()
        {
            return View();
        }
    }
}
