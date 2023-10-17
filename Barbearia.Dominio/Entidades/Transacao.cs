using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Entidades
{
    public class Transacao
    {
        public decimal? Id { get; set; }
        public decimal? IdAgendamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string? FormaPagamento { get; set; }
        public string? Status { get; set; }
    }
}
