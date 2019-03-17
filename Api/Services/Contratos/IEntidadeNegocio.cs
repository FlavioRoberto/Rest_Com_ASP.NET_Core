using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocio.Contratos
{
    public interface IEntidadeNegocio<T> where T : class
    {

        Task<T> Criar(T entidade);
        Task<T> ListarPeloId(long id);
        Task<List<T>> ListarTodos();
        Task<T> Atualizar(T entidade);
        Task<bool> Remover(long id);

    }
}
