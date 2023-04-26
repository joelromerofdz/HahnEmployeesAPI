using System.Linq.Expressions;

namespace HahnEmployeesAPI.Services.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<T?> GetByExpression(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
