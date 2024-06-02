using ETicaretApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int customerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Order> orders { get; set; }
        public Customer customer { get; set; }
    }
}
