using ETicaretApi.Application.Repositories;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F= ETicaretApi.Domain.Entities; 
namespace ETicaretApi.Persistence.Repositories
{
    public class FileReadRepository : ReadRepository<F.File>, IFileReadRepository
    {
        public FileReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
