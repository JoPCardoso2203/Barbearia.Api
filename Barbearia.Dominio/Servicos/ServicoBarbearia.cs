using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Servicos
{
    public class ServicoBarbearia : IServicoBarbearia
    {
        private readonly IRepositorioBarbearia _repositorioBarbearia;
        public ServicoBarbearia(IRepositorioBarbearia repositorioBarbearia)
        {
            _repositorioBarbearia = repositorioBarbearia;
        }

        public void Registrar(Funcionario funcionario)
        {
            if (funcionario != null)
            {
                funcionario.DataCriacao = DateTime.Now;
                _repositorioBarbearia.Adicionar(funcionario);
            }
        }

        public List<Funcionario> BuscarListaFuncionario()
        {
            return _repositorioBarbearia.BuscarLista();
        }
    }
}
