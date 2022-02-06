using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementHelpers.Interfaces
{
   
    public interface IVineBasementContext
    {
        public DbSet<Vine> Vines { get; set; }
        public DbSet<Vineyard> Vineyards { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
