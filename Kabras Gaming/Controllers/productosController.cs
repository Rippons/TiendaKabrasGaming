using Kabras_Gaming.Controllers.Data.Models;
using Kabras_Gaming.Controllers.Data.Repositories.Interfaces;
using Kabras_Gaming.DTOS;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kabras_Gaming.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class productosController : ControllerBase
    {
        private readonly IProductoRepository _producRepository;

        public productosController(IProductoRepository ProducRepository)
        {
            _producRepository = ProducRepository;
        }

        //        // GET: api/<productosController>
        //        [HttpGet]
        //        public IEnumerable<string> Get()
        //        {
        //            return new string[] { "value1", "value2" };
        //        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _producRepository.GetAllProductosAsync().Result;
            return Ok(response);
        }


        //        // GET api/<productosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _producRepository.GetProductoByIdAsync(id).Result;
            return Ok(response);
        }

        // /// /// //


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var data = _producRepository.GetProductoByIdAsync(id).Result;

            if (data is null)
            {
             
                return BadRequest("El producto no existe");

            }

            var response = _producRepository.DeleteproductoAsync(id).Result;

            return Ok(response);
        }


        // POST api/<productosController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateproductoDTO request)
        {
            var newproducto = new producto
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Precio = request.Precio,
                CantidadEnStock = request.CantidadEnStock
            };
            _producRepository.CreateproductoAsync(newproducto);

            return Ok();

         }

        [HttpPut("{id}")]
        public IActionResult Put(string id,[FromBody] UpdateProductosDTO request)
        {
            var data = _producRepository.GetProductoByIdAsync(id).Result;

            if (data is null)
            {

                return BadRequest("El producto no existe");

            }
            data.Nombre = request.Nombre;
            data.Descripcion = request.Descripcion;
            data.Precio = request.Precio;
            data.CantidadEnStock = request.CantidadEnStock;


            var response = _producRepository.UpdateproductoAsync(id, data).Result;

            return Ok(Response);

        }
        public string Nombre { get; set; }


        public string Descripcion { get; set; }


        public decimal Precio { get; set; }

        public int CantidadEnStock { get; set; }
    }
}




//        // PUT api/<productosController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<productosController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
