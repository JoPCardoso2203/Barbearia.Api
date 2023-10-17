using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Entidades
{
    public class Usuario
    {
        public decimal? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Cpf { get; set; }
        public string? TipoAcesso { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
