using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F = ETicaretApi.Domain.Entities;

namespace ETicaretApi.Application.Repositories
{
    public interface IFileReadRepository:IReadRepository<F::File>
    {
    }
}
