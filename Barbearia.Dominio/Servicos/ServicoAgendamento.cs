using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Servicos
{
    public class ServicoAgendamento : IServicoAgendamento
    {
        private readonly IRepositorioAgendamento _repositorioAgendamento;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ServicoAgendamento(IRepositorioAgendamento repositorioAgendamento, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioAgendamento = repositorioAgendamento;
            _repositorioUsuario = repositorioUsuario;
        }

        public List<Agendamento> ObterLista()
        {
            return _repositorioAgendamento.BuscarLista();
        }

        public List<Agendamento> ObterListaPorUsuario(string cpf)
        {
            Usuario? usuario = _repositorioUsuario.BuscarPorCpf(cpf);

            return _repositorioAgendamento.BuscarListaPorUsuario(usuario?.Id ?? 0);
        }

        public void Registrar(string cpf, Agendamento agendamento)
        {
            var usuario = _repositorioUsuario.BuscarPorCpf(cpf);
            if (usuario != null)
            {
                agendamento.DataCriacao = DateTime.Now;
                agendamento.IdUsuario = usuario.Id;
                _repositorioAgendamento.Adicionar(agendamento);
            }
        }
    }
}
