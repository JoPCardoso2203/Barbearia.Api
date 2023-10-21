using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Infraestrutura.Servicos
{
    public class ServicoConexao
    {
        public static MySqlConnection ObterConexao(IConfiguration configuracao)
        {
            var connectionString = "server=185.187.235.161;port=3306;uid=barbearia;pwd=barbearia;database=barbearia;";//configuracao.GetConnectionString("ConnectionDB");
            MySqlConnection conexao = new MySqlConnection(connectionString);
            return conexao;
        }
    }
}
