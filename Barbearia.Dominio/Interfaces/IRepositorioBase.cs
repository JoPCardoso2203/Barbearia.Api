﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Dominio.Interfaces
{
    public interface IRepositorioBase
    {
        void Executar<T>(string query, object? parametros);

        T? Obter<T>(string consulta, object? parametros = null);

        List<T> ObterLista<T>(string consulta, object? parametros = null);
    }
}
