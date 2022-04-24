using ECommerce.Products.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ECommerce.Products.Controllers
{
    public class ProductosController : Controller
    {
        //private readonly IConfiguration _configuration;

        //ProductoController() //IConfiguration configuration
        //{
        //    // _configuration = configuration;
        //}

        // GET: ProductoController
        public ActionResult Index()
        {
            List<Producto> lista = ProductoDAO.Instancia.Listar();
            return View(lista);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            Producto modelo = ProductoDAO.Instancia.Devolver(id);
            return View(modelo);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            //var cn = _configuration["ConnectionStrings:DefaultConnection"];
            //ViewBag.Mensaje = cn;
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            try
            {
                if (producto == null)
                    ViewBag.Mensaje = "Producto no puede ser nulo";
                //return new BadRequestResult();
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                    ViewBag.Mensaje = "Nombre de Producto no puede ser nulo o vacío";
                if (producto.Precio < 0)
                    ViewBag.Mensaje = "Precio de Producto no puede ser menor a cero";
                //return new BadRequestResult();

                bool creado = ProductoDAO.Instancia.Insertar(producto);
                if (creado)
                    return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            Producto modelo = ProductoDAO.Instancia.Devolver(id);
            return View(modelo);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producto producto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                    ViewBag.Mensaje = "Nombre de Producto no puede ser nulo o vacío";
                if (producto.Precio < 0)
                    ViewBag.Mensaje = "Precio de Producto no puede ser menor a cero";
                bool editado = ProductoDAO.Instancia.Actualizar(producto);
                if (editado)
                    return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction(nameof(Edit), new {id = id});
            }
            catch
            {
                return View(id);
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            Producto modelo = ProductoDAO.Instancia.Devolver(id);
            return View(modelo);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool eliminado = ProductoDAO.Instancia.Eliminar(id);
                if (eliminado)
                    return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction(nameof(Delete), new { id = id });
            }
            catch
            {
                return View(id);
            }
        }
    }
}
