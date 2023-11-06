using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myfinance_web_dotnet_infra
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase, new()
    {
        private readonly MyFinanceDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;    
            _dbSet = _dbContext.Set<T>();
        }

        public void Cadastar(T entidade)
        {
            if (entidade.Id == null)
                _dbSet.Add(entidade);
            else
                _dbSet.Update(entidade);
            _dbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var entidade = new T { Id = id };
            _dbSet.Remove(entidade);
            _dbContext.SaveChanges();
        }

        public virtual List<T> ListarRegistros()
        {
            return _dbSet.ToList();
        }

        public T RetornarRegistro(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
