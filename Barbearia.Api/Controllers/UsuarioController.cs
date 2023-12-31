﻿using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicoUsuario _servicoUsuario;
        private readonly IServicoPagamento _servicoPagamento;
        public UsuarioController(IServicoUsuario servicoUsuario, IServicoPagamento servicoPagamento)
        {
            _servicoUsuario = servicoUsuario;
            _servicoPagamento = servicoPagamento;
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
        public ActionResult Login([FromQuery]Usuario usuario) 
        {
            try
            {
                Usuario? usuarioLogin = _servicoUsuario.Login(usuario.Cpf, usuario.Senha);
                object? retorno = new
                {
                    usuarioLogin?.Id,
                    usuarioLogin?.Nome,
                    usuarioLogin?.TipoAcesso,
                    usuarioLogin?.Cpf
                };
                if(usuarioLogin == null) { retorno = null; }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Perfil")]
        public ActionResult Perfil([FromQuery] Usuario usuario) 
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

        [HttpPost("PagamentoPix")]
        public ActionResult PagamentoPix(string cpf, decimal valor)
        {
            try
            {
                return Ok(_servicoPagamento.ObterPagamentoPix(cpf, valor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
