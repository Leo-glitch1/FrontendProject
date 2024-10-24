using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FrontendProject.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontendProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // Acción para mostrar el formulario de creación de turno
    public IActionResult CrearTurno()
    {
        return View();
    }

    // Acción para manejar el envío del formulario de creación de turno
    [HttpPost]
    public async Task<IActionResult> CrearTurno(Turno turno)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8080/"); // Asegúrate de que sea la dirección correcta

            // Realiza la solicitud POST a /api/turnos/create
            var response = await client.PostAsJsonAsync("api/turnos/create", turno);

            if (response.IsSuccessStatusCode)
            {
                // Redirigir a la página de inicio o mostrar un mensaje de éxito
                return RedirectToAction("Index");
            }
            else
            {
                // Manejar el error en caso de fallo en la creación del turno
                ModelState.AddModelError(string.Empty, "Hubo un error al crear el turno.");
                return View(turno);
            }
        }
    }

}