using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Entidades
{
    public class Barbearia
    {
        public decimal? Id { get; set; }
        public decimal? IdUsuario { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Endereco { get; set; }
        public string? Whatsapp { get; set; }
        public string? Telefone { get; set; }
    }
}
