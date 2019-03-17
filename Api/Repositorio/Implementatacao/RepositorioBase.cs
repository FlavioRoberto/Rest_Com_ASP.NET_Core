using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repositorio.Implementatacao
{
    public abstract class RepositorioBase<T> : IEntidade<T> where T : class
    {
        private DbSet<T> _dbSet;
        protected MySqlContext _contexto { get; private set; }
        protected abstract DbSet<T> GetDbSet();

        public RepositorioBase(MySqlContext contexto)
        {
            _contexto = contexto;
            _dbSet = GetDbSet();
        }

        public async Task<T> Atualizar(T entidade, Expression<Func<T, bool>> query, string mensagemNaoExisteEntidade)
        {
            try
            {
                bool existeEntidade = await ExisteEntidadeNoBanco(query);
                if (!existeEntidade)
                    throw new Exception(mensagemNaoExisteEntidade);

                _dbSet.Update(entidade);
                await _contexto.SaveChangesAsync();
                return entidade;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected async Task<bool> ExisteEntidadeNoBanco(Expression<Func<T, bool>> query)
        {
            return await _dbSet.CountAsync(query) > 0;
        }

        public async Task<T> Criar(T entidade)
        {
            try
            {
                _dbSet.Add(entidade);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return entidade;
        }

        public async Task<T> ListarPeloId(Expression<Func<T, bool>> query)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(query);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public async Task<List<T>> ListarTodos()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Remover(Expression<Func<T, bool>> query)
        {
            try
            {
                var pessoa = await _dbSet.FirstOrDefaultAsync(query);
                if (pessoa != null)
                {
                   _dbSet.Remove(pessoa);
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
