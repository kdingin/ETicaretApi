using ETicaretApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Update(T model);
        bool Remove(T model);
        Task<bool> RemoveAsync(string id);
        bool RemoveRange(List<T> datas);
        Task<int> SaveAsync();
    }
}
