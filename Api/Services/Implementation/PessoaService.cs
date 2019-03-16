using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Contexto;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Services.Implementation
{
    public class PessoaService : IPessoaService
    {
        private MySqlContext _contexto;

        public PessoaService(MySqlContext contexto)
        {
            this._contexto = contexto;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            try
            {
                _contexto.Pessoa.Update(pessoa);
                await _contexto.SaveChangesAsync();
                return pessoa;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Pessoa> Criar(Pessoa pessoa)
        {
            try
            {
                _contexto.Add(pessoa);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return pessoa;
        }

        public async Task<Pessoa> ListarPeloId(long id)
        {
            try
            {
                return await _contexto.Pessoa.FirstOrDefaultAsync(lnq => lnq.Id == id);
            }
            catch (Exception e)
            {
                throw e;

            }

        }

        public async Task<List<Pessoa>> ListarTodos()
        {
            try
            {
                return await _contexto.Pessoa.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Remover(long id)
        {
            try
            {
                var pessoa = await _contexto.Pessoa.FirstOrDefaultAsync(lnq => lnq.Id == id);
                if (pessoa != null)
                {
                    _contexto.Pessoa.Remove(pessoa);
                    return true;
                }
                else
                {
                    return false;
                    throw new Exception("Não foi encontrado uma pessoa com o código informado!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
