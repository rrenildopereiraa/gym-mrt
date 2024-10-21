using Microsoft.AspNetCore.Mvc;

namespace GymManagementMRT.Controllers
{
    public class ServicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
