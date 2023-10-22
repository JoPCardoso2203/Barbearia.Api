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

        [HttpPost("ApagarBarbeiro")]
        public ActionResult ApagarBarbeiro(Funcionario funcionario)
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

        [HttpGet("Barbearia")]
        public ActionResult ObterBarbearia() 
        {
            try
            {
                return Ok(_servicoBarbearia.ObterBarbearia());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Barbearia")]
        public ActionResult AlterarBarbearia(Dominio.Entidades.Barbearia barbearia) 
        {
            try
            {
                _servicoBarbearia.AtualizarBarbearia(barbearia);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
