using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Entidades
{
    public class Funcionario
    {
        public decimal? Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
