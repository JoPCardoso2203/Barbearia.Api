using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarbeariaController : ControllerBase
    {
        private readonly IServicoBarbearia _servicoBarbearia;
        public BarbeariaController(IServicoBarbearia servicoBarbearia)
        {
            _servicoBarbearia = servicoBarbearia;
        }

        [HttpPost("RegistrarBarbeiro")]
        public ActionResult RegistrarBarbeiro(Funcionario funcionario) 
        {
            try
            {
                _servicoBarbearia.Registrar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarBarbeiro")]
        public ActionResult ListarBarbeiro()
        {
            try
            {
                return Ok(_servicoBarbearia.BuscarListaFuncionario());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpGet("Localizacao")]
        public ActionResult ObterLocalizacao() 
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Localizacao")]
        public ActionResult AlterarLocalizacao() 
        {
            try
            {
                return Ok(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}
