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
    public class RepositorioBarbearia : RepositorioBase, IRepositorioBarbearia
    {
        public RepositorioBarbearia(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(Funcionario funcionario)
        {
            string script = $@"INSERT INTO funcionario (func_nome, func_telefone, func_dt_criacao) 
                       VALUES(@Nome, @Telefone, @DataCriacao)";
            Executar<Funcionario>(script, funcionario);
        }

        public void Atualizar(Funcionario funcionario)
        {
            string script = $@"UPDATE funcionario SET 
                       func_nome = @Nome,
                       func_telefone = @Telefone,
                       func_dt_criacao = @DataCriacao
                       WHERE func_id = @Id";

            Executar<Funcionario>(script, funcionario);
        }

        public List<Funcionario> BuscarLista()
        {
            string script = $@"SELECT 
                                    FUNC_ID Id,
                                    FUNC_NOME Nome,
                                    FUNC_TELEFONE Telefone,
                                    FUNC_DT_CRIACAO DataCriacao
                               FROM FUNCIONARIO";

            return ObterLista<Funcionario>(script);
        }
    }
}
