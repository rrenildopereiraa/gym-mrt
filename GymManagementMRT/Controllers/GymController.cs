using Microsoft.AspNetCore.Mvc;
using GymManagementAPI.Data;
using GymManagementAPI.Models;

namespace GymManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymController : Controller
    {
        private readonly AppDBContext _context;

        public GymController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddGym(Gym gym)
        {
            _context.Gyms.Add(gym);
            _context.SaveChanges();
            return Ok(gym);
        }

        [HttpGet]
        public IActionResult GetGyms()
        {
            var gyms = _context.Gyms.ToList();
            return Ok(gyms);
        }
    }
}
