using Microsoft.AspNetCore.Mvc;

namespace gym_mrt.Controllers
{
    public class Dummy : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
