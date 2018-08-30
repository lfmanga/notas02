using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Notas02.Application.UserManager.Configurations;
using Notas02.Application.UserManager.Identity.Models;
using Notas02.Application.UserManager.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Notas02.WebApi.Controllers
{
    [EnableCors("AllowAllOrigin")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
                    [FromBody]UserViewModel usuario,
                    [FromServices]UserManager<Notas02User> userManager,
                    [FromServices]SignInManager<Notas02User> signInManager,
                    [FromServices]SigningConfiguration signingConfigurations,
                    [FromServices]TokenConfiguration tokenConfigurations)
        {
            bool credenciaisValidas = false;
            if (usuario != null && !string.IsNullOrWhiteSpace(usuario.UserName))
            {
                var userIdentity = userManager
                    .FindByNameAsync(usuario.UserName).Result;
                if (userIdentity != null)
                {
                    var resultadoLogin = signInManager
                        .CheckPasswordSignInAsync(userIdentity, usuario.Password, false)
                        .Result;
                    if (resultadoLogin.Succeeded)
                    {
                        credenciaisValidas = true;
                    }
                }
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.UserName, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/signin-google")]
        public async Task<IActionResult> SignInGoogle(object p, [FromServices]SignInManager<Notas02User> signInManager)
        {
            //var info = await signInManager.GetExternalLoginInfoAsync();
            //var result = await signInManager.ExternalLoginSignInAsync(
            //        info.LoginProvider
            //        , info.ProviderKey
            //        , isPersistent: false
            //        , bypassTwoFactor: true);
            //return Ok(result);  
            return await Task.FromResult(Ok());
        }
    }
}