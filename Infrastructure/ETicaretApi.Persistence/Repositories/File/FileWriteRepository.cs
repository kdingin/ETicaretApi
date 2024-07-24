using ETicaretApi.Application.Repositories;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F = ETicaretApi.Domain.Entities;
namespace ETicaretApi.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<F.File>, IFileWriteRepository
    {
        public FileWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
