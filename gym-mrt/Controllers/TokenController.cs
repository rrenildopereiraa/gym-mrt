using GymManagementAPI.Models;
using GymManagementMRT.Data;
using GymManagementMRT.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementMRT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public TokenController(TokenService tokenService, UserManager<User> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken(RefreshTokenRequest request)
        {
            var user = _userManager.Users.SingleOrDefault(userManager => userManager.RefreshToken == request.RefreshToken);

            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return Unauthorized(new { message = "Invalid or expired refresh token." });
            }

            var newJwtToken = _tokenService.GenerateJwtToken(user);
            var newRefreshToken = _tokenService.CreateRefreshToken();

            user.RefreshToken = newRefreshToken.Token;
            user.RefreshTokenExpiryTime = newRefreshToken.Expires;

            _userManager.UpdateAsync(user);
            return Ok(new
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken.Token
            });
        }
    }
}
