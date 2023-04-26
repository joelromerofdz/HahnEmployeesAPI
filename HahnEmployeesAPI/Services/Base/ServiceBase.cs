using HahnEmployeesAPI.Domain.Base;
using HahnEmployeesAPI.Domain.Repository;
using HahnEmployeesAPI.Infrastructure.Data;
using HahnEmployeesAPI.Services.Interfaces;
using System.Linq.Expressions;

namespace HahnEmployeesAPI.Services.Base
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public ServiceBase(IRepository<T> repository)
        {
            this._repository = repository;
        }

        public async Task Add(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _repository.ListAsync();
        }

        public async Task<T?> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetAsync(expression);
        }

        public async Task Update(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
