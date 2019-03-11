using Data.Model;
using System.Collections.Generic;

namespace Services
{
    public interface IPessoaService
    {
        Pessoa Criar(Pessoa pessoa);
        Pessoa ListarPeloId(long id);
        List<Pessoa> ListarTodos();
        Pessoa Atualizar(Pessoa pessoa);
        bool Remover(long id);
    }
}
