using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    public class PreMadeKeychainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
