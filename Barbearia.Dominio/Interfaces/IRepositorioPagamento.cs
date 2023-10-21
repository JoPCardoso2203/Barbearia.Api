using Barbearia.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IRepositorioPagamento
    {
        Task<string> CriarCobrancaAsync(string idCliente, decimal valor);
        Task<string> ObterClienteAsync(Usuario cliente);
        Task<string> ObterPixPagamentoAsync(string idCobranca);
        Task<string> CriarClienteAsync(Usuario cliente);
    }
}
