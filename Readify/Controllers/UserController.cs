using Microsoft.AspNetCore.Mvc;

namespace Readify.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
