using HahnEmployeesAPI.Domain.Base;
using HahnEmployeesAPI.Domain.Repository;
using HahnEmployeesAPI.Services.Interfaces;
using System.Linq.Expressions;

namespace HahnEmployeesAPI.Services.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public ServiceBase(IRepository<T> repository)
        {
            this._repository = repository;
        }

        public virtual async Task Add(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public virtual async Task Delete(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _repository.ListAsync();
        }

        public virtual async Task<T?> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetAsync(expression);
        }

        public virtual async Task Update(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
