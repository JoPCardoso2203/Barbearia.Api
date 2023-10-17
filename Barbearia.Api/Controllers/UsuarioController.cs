using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicoUsuario _servicoUsuario;
        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        [HttpPost("Registrar")]
        public ActionResult Registrar(Usuario usuario) 
        {
            try 
            {
                _servicoUsuario.RegistrarUsuario(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Login")]
        public ActionResult Login(Usuario usuario) 
        {
            try
            {
                Usuario? usuarioLogin = _servicoUsuario.Login(usuario.Cpf, usuario.Senha);
                object retorno = new
                {
                    usuarioLogin?.Nome,
                    usuarioLogin?.TipoAcesso,
                    usuarioLogin?.Cpf
                };

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Perfil")]
        public ActionResult Perfil(Usuario usuario) 
        {
            try
            {
                Usuario? usuarioPerfil = _servicoUsuario.ObterUsuario(usuario.Cpf ?? "");
                return Ok(usuarioPerfil);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("AlterarSenha")]
        public ActionResult AlterarSenha(Usuario usuario) 
        {
            try
            {
                _servicoUsuario.AtualizarSenhaUsuario(usuario.Cpf, usuario.Senha);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
