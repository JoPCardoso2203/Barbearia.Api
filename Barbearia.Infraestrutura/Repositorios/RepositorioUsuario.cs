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
    public class RepositorioUsuario : RepositorioBase, IRepositorioUsuario
    {
        public RepositorioUsuario(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(Usuario usuario)
        {
            string script = $@"INSERT INTO usuario (usua_nome, usua_email, usua_senha, usua_cpf, usua_tipo_acesso, usua_dt_criacao) 
                       VALUES(@Nome, @Email, @Senha, @Cpf, @TipoAcesso, @DataCriacao)";
            Executar<Usuario>(script, usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            string script = $@"UPDATE usuario SET 
                       usua_nome = @Nome,
                       usua_email = @Email,
                       usua_senha = @Senha,
                       usua_cpf = @Cpf,
                       usua_tipo_acesso = @TipoAcesso,
                       usua_dt_criacao = @DataCriacao
                       WHERE usua_id = @Id";

            Executar<Usuario>(script, usuario);
        }

        public Usuario? Buscar(decimal id)
        {
            string script = $@"SELECT 
                                    USUA_ID Id,
                                    USUA_NOME Nome,
                                    USUA_EMAIL Email,
                                    USUA_SENHA Senha,
                                    USUA_CPF Cpf,
                                    USUA_TIPO_ACESSO TipoAcesso,
                                    USUA_DT_CRIACAO DataCriacao
                               FROM usuario WHERE USUA_ID = @Id";

            return Obter<Usuario>(script, new { Id = id });
        }

        public Usuario? BuscarPorCpf(string cpf)
        {
            string script = $@"SELECT 
                                    USUA_ID Id,
                                    USUA_NOME Nome,
                                    USUA_EMAIL Email,
                                    USUA_SENHA Senha,
                                    USUA_CPF Cpf,
                                    USUA_TIPO_ACESSO TipoAcesso,
                                    USUA_DT_CRIACAO DataCriacao
                               FROM usuario WHERE USUA_CPF = @Cpf";

            return Obter<Usuario>(script, new { Cpf = cpf });
        }
    }
}
