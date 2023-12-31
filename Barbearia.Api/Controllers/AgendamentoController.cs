﻿using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IServicoAgendamento _servicoAgendamento;
        public AgendamentoController(IServicoAgendamento servicoAgendamento)
        {
            _servicoAgendamento = servicoAgendamento;
        }

        [HttpPost("Registrar")]
        public ActionResult Registrar(Agendamento agendamento)
        {
            try
            {
                _servicoAgendamento.Registrar(agendamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarPorUsuario")]
        public ActionResult ListarPorUsuario([FromQuery] string cpf)
        {
            try
            {
                var lista = _servicoAgendamento.ObterListaPorUsuario(cpf ?? "");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public ActionResult Listar()
        {
            try
            {
                var lista = _servicoAgendamento.ObterLista();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
