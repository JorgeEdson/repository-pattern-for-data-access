using Dapper.Contrib.Extensions;
using Database.Dapper.Repositories.Base.Interfaces.Base;
using Domain.Entities.Base;
using Microsoft.Data.SqlClient;
namespace Database.Dapper.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SqlConnection _connection;

        public BaseRepository()
        => _connection = new SqlConnection(ConnectionStrings.SQL_CONNECTION);

        public void Dispose()
        => _connection?.Dispose();

        public void Add(T obj)
        => _connection.Insert<T>(obj);        
        
        public List<T> GetAll()
        => _connection.GetAll<T>().ToList();

        public T GetById(Guid paramId)
         => _connection.Get<T>(paramId);

        public void Update(T obj)
       => _connection.Update<T>(obj);

        public void Delete(T obj)
        => _connection.Delete<T>(obj);

        public void DeleteById(Guid id)
        {
            var obj = GetById(id);
            Delete(obj);
        }
    }
}
