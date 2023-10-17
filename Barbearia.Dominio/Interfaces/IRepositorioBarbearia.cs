﻿using Barbearia.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IRepositorioBarbearia
    {
        void Adicionar(Funcionario funcionario);
        void Atualizar(Funcionario funcionario);
        List<Funcionario> BuscarLista();
    }
}
