using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Modelos;

namespace PruebaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlancoApiController : Controller
    {
        public static List<CatalogoColores> Colores = new List<CatalogoColores>();


        [HttpGet("ObtenSaludo/{nombre}/{edad}")]
        public string ObtenSaludo(string nombre, int edad)
        {
            return $"Hola {nombre}, tienes {edad} años, desde la API";
        }
        [HttpGet("ObtenColores")]
        public List<CatalogoColores> ObtenColores()
        {

            return Colores;
        }

        [HttpPost("AgregaColor")]
        public IActionResult AgregaColor(CatalogoColores color)
        {
            Colores.Add(color);
            return Ok();
        }

        [HttpDelete ("BorrarColor/{id}")]
        public IActionResult EliminarColor (int id)
        {
            var color = Colores.FirstOrDefault(c => c.Id == id);
            Colores.Remove(color);
            return Ok();
        }

        [HttpPut("ActualizarColor/{id}")]
        public IActionResult ActualizarColor(int id, CatalogoColores colorActualizado)
        {
            var color = Colores.FirstOrDefault(c => c.Id == id);
            if (color != null)
            {
                Colores.Remove(color);
                Colores.Add(colorActualizado);
                return Ok();
            }

            return NotFound();

        }

    }
}