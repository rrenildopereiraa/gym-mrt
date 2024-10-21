using GymManagementAPI.Data;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using GymManagementAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography;

namespace GymManagementMRT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly AppDBContext _context;

        public LoginController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            //
            var cliente = await _context.Users
                .FirstOrDefaultAsync(c => c.Email == loginRequest.Email);

            if (cliente == null || cliente.Password != loginRequest.Password)
            {
                return Unauthorized("Credenciais inválidas.");
            }

            //
            //
            return Ok("Login bem sucedido.");

            return View();
        }

        [HttpPost]
        public IActionResult Autenticar(string email, string password)
        {
            if (email == "cliente@example.com" && password == "password123")
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = "Email ou password incorretos.";
            return View("Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
