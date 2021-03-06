﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repositorio
{
   public interface IRepositorio<T> where T : class
    {
        Task<T> Criar(T entidade);
        Task<T> ListarPeloId(Expression<Func<T, bool>> query);
        Task<List<T>> ListarTodos();
        Task<T> Atualizar(T entidade);
        Task<bool> Remover(Expression<Func<T, bool>> query);
    }
}
