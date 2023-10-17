using Barbearia.Dominio.Entidades;
using Barbearia.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            usuario.DataCriacao = DateTime.Now;
            usuario.TipoAcesso = "cliente";
            _repositorioUsuario.Adicionar(usuario);
        }

        public Usuario? ObterUsuario(decimal id)
        {
            return _repositorioUsuario.Buscar(id);
        }

        public Usuario? ObterUsuario(string cpf)
        {
            return _repositorioUsuario.BuscarPorCpf(cpf);
        }

        public void AtualizarSenhaUsuario(string? cpf, string? senha)
        {
            Usuario? usuarioAntigo = null;

            if (cpf != null)
                usuarioAntigo = ObterUsuario(cpf);

            if (usuarioAntigo != null)
            {
                usuarioAntigo.Senha = senha;
                _repositorioUsuario.Atualizar(usuarioAntigo);
            }
        }

        public Usuario? Login(string? cpf, string? senha)
        {
            Usuario? usuario = null;

            if (cpf != null)
            {
                usuario = ObterUsuario(cpf);

                if (usuario is { Senha: var senhaUsuario } && (senhaUsuario is null || !senhaUsuario.Equals(senha)))
                {
                    usuario = null;
                }
            }

            return usuario;
        }
    }
}
