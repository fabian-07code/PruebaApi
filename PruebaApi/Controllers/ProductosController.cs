using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Modelos;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public static readonly List<Producto> Productos = new List<Producto>
        {

            new Producto { Id = 1, Nombre = "Producto 1", Precio = 10.99m, Existencia = 100, Disponible = true },
            new Producto { Id = 2, Nombre = "Producto 2", Precio = 20.99m, Existencia = 50, Disponible = true },
            new Producto { Id = 3, Nombre = "Producto 3", Precio = 15.99m, Existencia = 0, Disponible = false },
        };
        
    

    [HttpGet("Respuesta")]
        public IActionResult GetRespuesta()
        {
            return Ok(Productos);
        }

      [HttpGet("RespuestaOkObjeto")]

      public IActionResult GetRespuestaOkObjeto()
        {
            Producto objproducto = new Producto();

            objproducto.Nombre = "Producto nuevo";

            return Ok(objproducto);

        }

        [HttpGet("RespuestaOkMensaje")]
        public IActionResult GetRespuestaOkMensaje()
        {
            return Ok("Mensaje Ok desde APi");
        }

        [HttpGet("ObtenerPorId/{id}")]
        public IActionResult GetProductoPorId(int id)
        {
            Producto consulta = Productos.FirstOrDefault(x => x.Id.Equals(id));

            if (consulta != null)
            {
                return NotFound();
            }

            return Ok(consulta);



        }

        [HttpGet("RegresarTodalalista")]

        public ActionResult<List<Producto>> RegresarTodalalista()
        {
            return Productos;
        }

        [HttpPost("RespuestaCreate")]
        public IActionResult PostRespuestaCreate(Producto producto)
        {
            Productos.Add(producto);
            return Created();
        }


        [HttpPost("RespuestaCreaateAction")]
        public IActionResult PostRespuestaCreateAction(Producto producto)
        {
            Productos.Add(producto);
            return CreatedAtAction(nameof(RegresarTodalalista),producto);
        }

        [HttpDelete("EliminarProducto/{id}")]
        public IActionResult eliminarporId(int id)
        {
            Producto consulta = Productos.FirstOrDefault(x => x.Id.Equals(id));
            if (consulta != null)
            {
                return NotFound(new
                { mensaje = "No se encontro el producto con el id proporcionado" }
                     
                );
            }
            Productos.Remove(consulta);
            return Ok();
        }
    }

}
