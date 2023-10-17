using Barbearia.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IServicoUsuario
    {
        void RegistrarUsuario(Usuario usuario);
        void AtualizarSenhaUsuario(string? cpf, string? senha);
        Usuario? Login(string? cpf, string? senha);
        Usuario? ObterUsuario(string cpf);
    }
}
