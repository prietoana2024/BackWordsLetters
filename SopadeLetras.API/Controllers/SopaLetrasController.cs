using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SopadeLetras.DLL.Servicios.Contrato;
using SopadeLetras.DTO;


namespace SopadeLetras.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SopaLetrasController : ControllerBase
    {

        private readonly ISopaLetrasService _sopaLetrasService;

        public SopaLetrasController(ISopaLetrasService sopaLetrasService)
        {
            _sopaLetrasService = sopaLetrasService;
        }
        
        [HttpPost("buscar")]
        public ActionResult<SopaLetrasResponse> BuscarPalabras([FromBody] SopaLetrasRequest request)
        {
            try
            {
                var resultado = _sopaLetrasService.BuscarPalabras(request);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        /*
        [HttpPost("buscar")]
        public IActionResult BuscarPalabras([FromBody] SopaLetrasRequest request)
        {
            try
            {
                // Lógica de búsqueda
                var palabrasEncontradas = new List<string>();
                var palabrasNoEncontradas = new List<string>();

                // Ejemplo simple de búsqueda
                foreach (var palabra in request.Palabra)
                {
                    if (request.Caractere.Contains(palabra))
                    {
                        palabrasEncontradas.Add(palabra);
                    }
                    else
                    {
                        palabrasNoEncontradas.Add(palabra);
                    }
                }

                return Ok(new[] { palabrasEncontradas, palabrasNoEncontradas });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/
        [HttpPost("buscar-form")]
        public ActionResult<SopaLetrasResponse> BuscarPalabrasForm([FromForm] string palabras, [FromForm] string matriz)
        {
            try
            {
                var request = new SopaLetrasRequest
                {
                    Palabra = palabras.Split(',').Select(p => p.Trim()).ToList(),
                    Caractere = matriz
                };

                var resultado = _sopaLetrasService.BuscarPalabras(request);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
