﻿using Barbearia.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IRepositorioUsuario
    {
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario? Buscar(decimal id);
        Usuario? BuscarPorCpf(string cpf);
    }
}
