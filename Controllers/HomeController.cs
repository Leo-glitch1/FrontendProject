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
    // Acción para mostrar el formulario de creación de turno
    public IActionResult CrearTurno()
    {
        return View();
    }

    // Acción para manejar el envío del formulario de creación de turno
    [HttpPost]
    public async Task<IActionResult> CrearTurno(Turno turno)
    {
        if (!ModelState.IsValid)
        {
            // Si la validación falla, muestra el formulario con los errores
            return View(turno);
        }

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8080/");
            var response = await client.PostAsJsonAsync("api/turnos/create", turno);

            if (response.IsSuccessStatusCode)
            {
                // Mostrar un mensaje de éxito
                TempData["SuccessMessage"] = "Turno creado exitosamente.";
                return RedirectToAction("CrearTurno");
            }
            else
            {
                // Mostrar un mensaje de error
                ModelState.AddModelError(string.Empty, "Hubo un error al crear el turno.");
                return View(turno);
            }
        }
    }


}