using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Negocio

{
    public interface IPessoaNegocio
    {
        Task<Pessoa> Criar(Pessoa pessoa);
        Task<Pessoa> ListarPeloId(Expression<Func<Pessoa, bool>> query);
        Task<List<Pessoa>> ListarTodos();
        Task<Pessoa> Atualizar(Pessoa pessoa);
        Task<bool> Remover(Expression<Func<Pessoa, bool>> query);
    }
}
