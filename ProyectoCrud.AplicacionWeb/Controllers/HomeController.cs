using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.AplicacionWeb.Models;
using ProyectoCrud.AplicacionWeb.Models.viewModels;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models;
using System.Diagnostics;
using System.Globalization;

namespace ProyectoCrud.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IContactoService _contactoService;

        public HomeController(IContactoService contactoService)
        {
            _contactoService = contactoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            IQueryable<Contacto> queryContactoSQL = await _contactoService.ObtenerTodos();
            List<VMContacto> lista = queryContactoSQL.Select(c => new VMContacto()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Nacimiento = c.Nacimiento.Value.ToString("dd/MM/yyyy")
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> insertar([FromBody]VMContacto modelo)
        {
            Contacto nuevoModelo = new Contacto()
            {
                Nombre = modelo.Nombre,
                Telefono = modelo.Telefono,
                Nacimiento = DateTime.ParseExact(modelo.Nacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"))
            };

            bool respuesta = await _contactoService.Insertar(nuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> actualizar([FromBody] VMContacto modelo)
        {
            Contacto nuevoModelo = new Contacto()
            {
                Nombre = modelo.Nombre,
                Telefono = modelo.Telefono,
                Nacimiento = DateTime.ParseExact(modelo.Nacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-pe"))
            };

            bool respuesta = await _contactoService.Actualizar(nuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> eliminar(int id)
        {
            bool respuesta = await _contactoService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}