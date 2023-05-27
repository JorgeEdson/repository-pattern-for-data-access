using Domain.Entities.Base;
namespace Database.Dapper.Repositories.Base.Interfaces.Base
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        void Add(T obj);
        T GetById(Guid id);
        List<T> GetAll();
        void Update(T obj);
        void Delete(T obj);
        void DeleteById(Guid id);
    }
}
