﻿using ETicaretApi.Domain.Entities;
using ETicaretApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> productImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: It is the property that enables the capture of changes made on entities or newly added data. It allows us to capture and obtain the data tracked in Update operations.
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas) {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified=>data.Entity.UpdatedDate= DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
