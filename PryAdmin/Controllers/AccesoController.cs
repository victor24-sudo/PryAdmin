using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PryAdmin.Controllers;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using PryAdmin.Models;

namespace PryAdmin.Controllers
{
    public class AccesoController : Controller
    {

        private readonly WebContext _context;

        public AccesoController(WebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            var usuario = _context.ValidarUsuario(_usuario.Email, _usuario.Clave);
            _context.ValidarRol(_usuario.Email, _usuario.Clave, _usuario.Rol); 

            if (usuario != null)

            {
                //Creacion de la cookie de autorizacion 

                var claims = new List<Claim> {

                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("Correo", usuario.Email),
                };


                //foreach (string rol in Char.Parse(usuario.Rol))
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, rol));

                //}

                claims.Add(new Claim(ClaimTypes.Role, usuario.Rol));

                claims.Add(new Claim(ClaimTypes.Role, usuario.Rol));

                if (usuario.Rol == "adm")
                {
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    

                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    

                    return RedirectToAction("Index", "Ejercicios");
                }

                
            }
            else
            {
                return View();
            }
        }

        [Route("logout")]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Acceso");
        }

        public IActionResult Error()
        {
            return RedirectToAction("Error", "Acceso");
        }

    }
}
