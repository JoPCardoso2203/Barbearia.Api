using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Servicos
{
    public class ServicoPagamento : IServicoPagamento
    {
        private readonly IRepositorioPagamento _repositorioPagamento;
        private readonly IServicoUsuario _servicoUsuario;
        
        public ServicoPagamento(IRepositorioPagamento repositorioPagamento, IServicoUsuario servicoUsuario)
        {
            _repositorioPagamento = repositorioPagamento;
            _servicoUsuario = servicoUsuario;
        }

        public string ObterPagamentoPix(string cpf, decimal valor)
        {
            Usuario? usuario = _servicoUsuario.ObterUsuario(cpf);

            if(usuario == null) 
            {
                throw new Exception("Usuario não encontrado");
            }

            string idUsuarioCobranca = _repositorioPagamento.ObterClienteAsync(usuario).Result;

            if(idUsuarioCobranca == null)
                idUsuarioCobranca = _repositorioPagamento.CriarClienteAsync(usuario).Result;

            string idCobranca = _repositorioPagamento.CriarCobrancaAsync(idUsuarioCobranca, valor).Result;

            string codigoPix = _repositorioPagamento.ObterPixPagamentoAsync(idCobranca).Result;

            return codigoPix;
        }
    }
}
