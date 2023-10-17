using Barbearia.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IServicoAgendamento
    {
        List<Agendamento> ObterLista();
        List<Agendamento> ObterListaPorUsuario(string cpf);
        void Registrar(string cpf, Agendamento agendamento);
    }
}
