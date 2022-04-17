using ECommerce.Products.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Products.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IConfiguration _configuration;

        ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // GET: ProductoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            var cn = _configuration["ConnectionStrings:DefaultConnection"];
            ViewBag.Mensaje = cn;
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
                    //return new BadRequestResult();
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
            return View();
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
