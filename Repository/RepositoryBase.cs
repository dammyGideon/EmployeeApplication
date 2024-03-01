using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) {
            RepositoryContext = repositoryContext;
        }
        public async Task Create(T entity) =>
           await RepositoryContext.Set<T>().AddAsync(entity);


        public async Task Delete(T entity) =>
             RepositoryContext.Set<T>().Remove(entity);


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().
            Where(condition).AsNoTracking() :
            RepositoryContext.Set<T>().Where(condition);


        public IQueryable<T> GetAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking()
            : RepositoryContext.Set<T>();
        

        public async Task Update(T entity)=>
            RepositoryContext.Set<T>().Update(entity);
        
    }
}
