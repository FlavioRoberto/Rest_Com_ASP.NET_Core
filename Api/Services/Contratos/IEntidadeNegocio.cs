using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocio.Contratos
{
    public interface IEntidadeNegocio<T> where T : class
    {

        T Criar(T entidade);
        T ListarPeloId(long id);
        List<T> ListarTodos();
        T Atualizar(T entidade);
        bool Remover(long id);

    }
}
