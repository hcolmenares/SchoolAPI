using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolAPI.Configuration;
using SchoolAPI.Shared.Auth;
using SchoolAPI.Shared.Dto.AccountManagerDto;
using SchoolAPI.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<JwtConfig> jwtConfig, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtConfig = jwtConfig.Value;
            _emailSender = emailSender;
        }

        private const string VisitanteRoleId = "dd20c5e0-3999-4ff6-bcf7-8425331c1dfc";

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var emailExist = await _userManager.FindByEmailAsync(request.Email);

            if (emailExist != null)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
            {
                "Ya existe este correo"
            }
                });
            }

            var user = new User()
            {
                Email = request.Email,
                UserName = request.Name,
                EmailConfirmed = false
            };

            var isCreated = await _userManager.CreateAsync(user, request.Password);

            if (isCreated.Succeeded)
            {
                // Asignar el rol "Visitante" al usuario recién creado por ID
                var role = await _roleManager.FindByIdAsync(VisitanteRoleId);
                if (role != null)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }

                await SendVerificationEmail(user);

                return Ok(new AuthResult()
                {
                    Result = true,
                });
            }
            else
            {
                var errors = new List<string>();
                foreach (var err in isCreated.Errors) errors.Add(err.Description);
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = errors
                });
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForggotPasswordRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "No existe ninguna cuenta asociada a este correo electrónico."
                    }
                });
            }

            // Generar token de restablecimiento de contraseña
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return Ok(new AuthResult()
            {
                Result = true,
                Token = token,
                Message = "Se ha verificado el correo, puede continuar con el proceso de restablecer la contraseña."
            });
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // El correo electrónico proporcionado no está asociado a ninguna cuenta
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
            {
                "No existe ninguna cuenta asociada a este correo electrónico."
            }
                });
            }

            // Restablecer la contraseña del usuario
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return Ok(new AuthResult()
                {
                    Result = true,
                    Message = "La contraseña se ha restablecido correctamente."
                });
            }
            else
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.Description);
                }
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = errors
                });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser == null)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Credenciales invalidas."
                    }
                });
            }

            if (!existingUser.EmailConfirmed)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Se necesita confirmar el correo electrónico."
                    }
                });
            }

            var checkUserAndPassword = await _userManager.CheckPasswordAsync(existingUser, dto.Password);
            if (!checkUserAndPassword)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Credenciales invalidas."
                    }
                });
            }

            var token = await GenerateTokenAsync(existingUser);

            return Ok(new AuthResult()
            {
                Result = true,
                Token = token
            });
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Url de confirmación de email invalido."
                    }
                });
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound($"No se encontró el usuario");

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await _userManager.ConfirmEmailAsync(user, code);

            var status = result.Succeeded ? "Gracias por confirmar su correo electrónico." :
                        "Ocurrio un error al momento de confirmar el correo electrónico.";

            return Ok(status);
        }

        private async Task<string> GenerateTokenAsync(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaim = roles.Count > 0 ? roles.First() : "NoRole";

            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
                new Claim("Role", roleClaim)
            };

            // Agrega las propiedades del usuario como claims solo si no son null
            if (!string.IsNullOrEmpty(user.FirstName))
                claims.Add(new Claim("FirstName", user.FirstName));
            if (!string.IsNullOrEmpty(user.LastName))
                claims.Add(new Claim("LastName", user.LastName));
            if (!string.IsNullOrEmpty(user.Gender))
                claims.Add(new Claim("Gender", user.Gender));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }

        private async Task SendVerificationEmail(User user)
        {
            var verificationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            verificationCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(verificationCode));

            var callBackUrl = $@"{Request.Scheme}://{Request.Host}{Url.Action("ConfirmEmail", controller: "Authentication",
                                    new { userId = user.Id, code = verificationCode })}";

            var emailBody = $@"Please confirm your email by <a href='{HtmlEncoder.Default.Encode(callBackUrl)}'>clicking here</a>";

            await _emailSender.SendEmailAsync(user.Email, "Confirm your email", emailBody);
        }

    }
}
