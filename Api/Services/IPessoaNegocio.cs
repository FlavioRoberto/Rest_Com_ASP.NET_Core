using Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocio

{
    public interface IPessoaNegocio
    {
        Task<Pessoa> Criar(Pessoa pessoa);
        Task<Pessoa> ListarPeloId(long id);
        Task<List<Pessoa>> ListarTodos();
        Task<Pessoa> Atualizar(Pessoa pessoa);
        Task<bool> Remover(long id);
    }
}
