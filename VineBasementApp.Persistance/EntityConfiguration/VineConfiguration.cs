using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementApp.Persistance.EntityConfiguration
{
    public class VineConfiguration : IEntityTypeConfiguration<Vine>
    {
        public void Configure(EntityTypeBuilder<Vine> builder)
        {
            builder.HasOne<Vineyard>(c=>c.Vineyard)
                   .WithMany(c=>c.Vines)
                   .HasForeignKey(c=>c.VineyardId)
                   .OnDelete(DeleteBehavior.Cascade);   
        }
    }
}
