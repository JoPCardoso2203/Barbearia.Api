using Barbearia.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IRepositorioAgendamento
    {
        void Adicionar(Agendamento agendamento);
        void Atualizar(Agendamento agendamento);
        List<Agendamento> BuscarListaPorUsuario(decimal idUsuario);
        List<Agendamento> BuscarLista();
    }
}
