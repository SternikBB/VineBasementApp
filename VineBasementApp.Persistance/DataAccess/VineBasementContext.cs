using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VineBasementApp.Shared.Services;
using VineBasementHelpers.Audit;
using VineBasementHelpers.Extensions;
using VineBasementHelpers.Interfaces;

namespace VineBasementApp.Persistance.DataAccess
{
    public class VineBasementContext : DbContext, IVineBasementContext
    {
        public DbSet<Vine> Vines { get; set; }
        public DbSet<Vineyard> Vineyards { get; set; }

        public VineBasementContext(DbContextOptions<VineBasementContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTimeProvider.Now;
                        entry.Entity.CreatedBy = "winUser";
                        break;

                    case EntityState.Modified:
                        entry.Property(x => x.Created).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        entry.Entity.LastModified = DateTimeProvider.Now;
                        entry.Entity.LastModifiedBy = "winUser";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddPrefixToColumnAndTableName("Vb_");
            base.OnModelCreating(modelBuilder);
        }
    }

}
