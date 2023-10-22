using Barbearia.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IServicoBarbearia
    {
        void Registrar(Funcionario funcionario);
        void Apagar(Funcionario funcionario);
        List<Funcionario> BuscarListaFuncionario();
        void AtualizarBarbearia(Entidades.Barbearia barbearia);
        Entidades.Barbearia? ObterBarbearia();
    }
}
