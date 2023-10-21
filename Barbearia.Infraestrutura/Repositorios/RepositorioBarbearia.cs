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
            string script = $@"INSERT INTO funcionario (func_nome, func_telefone, func_valor, func_dt_criacao) 
                       VALUES(@Nome, @Telefone, @Valor, @DataCriacao)";
            Executar<Funcionario>(script, funcionario);
        }

        public void Atualizar(Funcionario funcionario)
        {
            string script = $@"UPDATE funcionario SET 
                       func_nome = @Nome,
                       func_telefone = @Telefone,
                       func_dt_criacao = @DataCriacao,
                       func_valor = @Valor
                       WHERE func_id = @Id";

            Executar<Funcionario>(script, funcionario);
        }

        public List<Funcionario> BuscarLista()
        {
            string script = $@"SELECT 
                                    FUNC_ID Id,
                                    FUNC_NOME Nome,
                                    FUNC_TELEFONE Telefone,
                                    FUNC_VALOR Valor,
                                    FUNC_DT_CRIACAO DataCriacao
                               FROM funcionario";

            return ObterLista<Funcionario>(script);
        }

        public void AtualizarBarbearia(Dominio.Entidades.Barbearia barbearia)
        {
            string script = $@"UPDATE barbearia SET 
                       barb_usua_id = @IdUsuario,
                       barb_longitude = @Longitude,
                       barb_latitude = @Latitude,
                       barb_whatsapp = @Whatsapp,
                       barb_telefone = @Telefone,
                       barb_endereco = @Endereco
                       WHERE barb_id = 1";

            Executar<Dominio.Entidades.Barbearia>(script, barbearia);
        }

        public Dominio.Entidades.Barbearia? BuscarBarbearia()
        {
            string script = $@"SELECT 
                                    BARB_ID Id,
                                    BARB_USUA_ID IdUsuario,
                                    BARB_LONGITUDE Longitude,
                                    BARB_LATITUDE Latitude,
                                    BARB_WHATSAPP Whatsapp,
                                    BARB_TELEFONE Telefone,
                                    BARB_ENDERECO Endereco
                               FROM barbearia WHERE BARB_ID = 1";

            return Obter<Dominio.Entidades.Barbearia>(script);
        }
    }
}
