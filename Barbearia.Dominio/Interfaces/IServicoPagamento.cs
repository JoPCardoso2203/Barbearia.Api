using Barbearia.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IServicoPagamento
    {
        string ObterPagamentoPix(string cpf, decimal valor);
    }
}
