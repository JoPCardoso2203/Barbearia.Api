using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Entidades
{
    public class Agendamento
    {
        public decimal? Id { get; set; }
        public decimal? IdFuncionario { get; set; }
        public decimal? IdUsuario { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
