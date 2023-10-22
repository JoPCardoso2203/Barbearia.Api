using Barbearia.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IRepositorioBarbearia
    {
        void Adicionar(Funcionario funcionario);
        void Apagar(decimal? idFuncionario);
        void Atualizar(Funcionario funcionario);
        List<Funcionario> BuscarLista();
        void AtualizarBarbearia(Dominio.Entidades.Barbearia barbearia);
        Entidades.Barbearia? BuscarBarbearia();
    }
}
