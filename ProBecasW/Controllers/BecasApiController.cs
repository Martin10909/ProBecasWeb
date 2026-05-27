
using Microsoft.AspNetCore.Mvc;
using ProBecasW.Models;
using ProBecasW.Services;
using ProBecasW.Models;
using ProBecasW.Services;

namespace ProBecasW.Controllers
{
    [Route("api/becas")]
    [ApiController]
    public class BecasApiController : ControllerBase
    {
        private readonly IBecaService _becaService;

        public BecasApiController(IBecaService becaService)
            => _becaService = becaService;

        // POST api/becas/evaluar
        [HttpPost("evaluar")]
        public IActionResult Evaluar([FromBody] EvaluacionRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var resultado = _becaService.Evaluar(request);
            return Ok(resultado);
        }
    }
}
