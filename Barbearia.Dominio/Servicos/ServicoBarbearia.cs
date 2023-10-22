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

        public void Apagar(decimal? idFuncionario)
        {
            if (idFuncionario != null)
            {
                _repositorioBarbearia.Apagar(idFuncionario);
            }
        }

        public List<Funcionario> BuscarListaFuncionario()
        {
            return _repositorioBarbearia.BuscarLista();
        }

        public void AtualizarBarbearia(Entidades.Barbearia barbearia)
        {
            var barbeariaAntiga = _repositorioBarbearia.BuscarBarbearia();

            if (barbeariaAntiga != null)
            {
                barbeariaAntiga.Latitude = barbearia.Latitude ?? barbeariaAntiga.Latitude;
                barbeariaAntiga.Longitude = barbearia.Longitude ?? barbeariaAntiga.Longitude;
                barbeariaAntiga.Endereco = barbeariaAntiga.Endereco ?? barbeariaAntiga.Endereco;
                barbeariaAntiga.Telefone = barbeariaAntiga.Telefone ??  barbeariaAntiga.Telefone;
                barbeariaAntiga.Whatsapp = barbeariaAntiga.Whatsapp ?? barbeariaAntiga.Whatsapp;

                _repositorioBarbearia.AtualizarBarbearia(barbeariaAntiga);
            }
        }

        public Entidades.Barbearia? ObterBarbearia()
        {
            return _repositorioBarbearia.BuscarBarbearia();
        }
    }
}
