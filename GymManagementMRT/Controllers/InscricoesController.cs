using Microsoft.AspNetCore.Mvc;

namespace GymManagementMRT.Controllers
{
    public class InscricoesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inscrever(string nome, string email, string telefone)
        {
            ViewBag.SuccessMessage = "Inscrição realiazada com sucesso!";
            return View();
        }
    }
}
