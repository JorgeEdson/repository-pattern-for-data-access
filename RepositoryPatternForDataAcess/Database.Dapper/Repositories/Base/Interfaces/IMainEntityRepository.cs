using Database.Dapper.Repositories.Base.Interfaces.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Dapper.Repositories.Base.Interfaces
{
    public interface IMainEntityRepository : IBaseRepository<MainEntity>
    {
    }
}
