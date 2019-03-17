using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repositorio
{
   public interface IEntidade<T> where T : class
    {
        Task<T> Criar(T entidade);
        Task<T> ListarPeloId(Expression<Func<T, bool>> query);
        Task<List<T>> ListarTodos();
        Task<T> Atualizar(T entidade, Expression<Func<T, bool>> query, string mensagemNaoExisteEntidade);
        Task<bool> Remover(Expression<Func<T, bool>> query);
    }
}
