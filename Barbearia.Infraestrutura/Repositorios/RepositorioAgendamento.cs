using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Infraestrutura.Repositorios
{
    public class RepositorioAgendamento : RepositorioBase, IRepositorioAgendamento
    {
        public RepositorioAgendamento(IConfiguration configuration) : base(configuration)
        {

        }

        public void Adicionar(Agendamento agendamento)
        {
            string script = $@"INSERT INTO agendamento (agen_func_id, agen_usua_id, agen_dt_inicio, agen_dt_criacao) 
                       VALUES(@IdFuncionario, @IdUsuario, @DataInicio,  @DataCriacao)";
            Executar<Agendamento>(script, agendamento);
        }

        public void Atualizar(Agendamento agendamento)
        {
            string script = $@"UPDATE agendamento SET 
                       agen_func_id = @IdFuncionario,
                       agen_usua_id = @IdUsuario,
                       agen_dt_inicio = @DataInicio
                       agen_dt_criacao = @DataCriacao
                       WHERE moto_id = @Id";

            Executar<Agendamento>(script, agendamento);
        }

        public List<Agendamento> BuscarListaPorUsuario(decimal idUsuario)
        {
            string script = $@"SELECT AGEN_ID Id,
                                      AGEN_FUNC_ID IdFuncionario,
                                      AGEN_USUA_ID IdUsuario,
                                      AGEN_DT_INICIO DataInicio,
                                      AGEN_DT_CRIACAO DataCriacao
                               FROM agendamento WHERE AGEN_USUA_ID = @Id";

            return ObterLista<Agendamento>(script, new { Id = idUsuario });
        }

        public List<Agendamento> BuscarLista()
        {
            string script = $@"SELECT AGEN_ID Id,
                                      AGEN_FUNC_ID IdFuncionario,
                                      AGEN_USUA_ID IdUsuario,
                                      AGEN_DT_INICIO DataInicio,
                                      AGEN_DT_CRIACAO DataCriacao
                               FROM agendamento";

            return ObterLista<Agendamento>(script);
        }
    }
}
