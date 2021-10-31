using ClothingStore.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingStore.WebAdmin.Controllers
{
    public class ClientesController : Controller
    {
        ClientesBL _clientesBL;

        public ClientesController()
        {
            _clientesBL = new ClientesBL();

        }
        // GET: Clientes
        public ActionResult Index()
        {
            var listadeClientes = _clientesBL.ObtenerClientes();

            return View(listadeClientes);
        }

        public ActionResult Crear()
        {
            var nuevoCliente = new Clientes();
            return View(nuevoCliente);
        }

        [HttpPost]
        public ActionResult Crear(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Nombre != cliente.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "El nombre no debe contener espacios al inicio o al final");

                    return View(cliente);
                }
                _clientesBL.GuardarCliente(cliente);

                return RedirectToAction("Index");
            }
            return View(cliente);

        }


        public ActionResult Editar(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Nombre != cliente.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "El nombre no debe contener espacios al inicio o al final");

                    return View(cliente);
                }
                _clientesBL.GuardarCliente(cliente);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Detalle(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);
            return View(cliente);
        }
        public ActionResult Eliminar(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Clientes cliente)
        {
            _clientesBL.EliminarCliente(cliente.Id);

            return RedirectToAction("Index");
        }
    }
}