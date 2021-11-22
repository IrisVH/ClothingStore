using ClothingStore.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ClothingStore.WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        seguridadBL _seguridadBL;
        public LoginController()
        {
            _seguridadBL = new seguridadBL();
        }
        // GET: Login
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            var nombreUsuario = data["username"];
            var contrasena = data["password"];

            var usuarioValido = _seguridadBL.
                Autorizar(nombreUsuario, contrasena);
            if (usuarioValido)
            {
                FormsAuthentication.SetAuthCookie(nombreUsuario, true);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Usuario o Contraseña invalido ");

            return View();

            
        }
    }
}