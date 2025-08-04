using MicroservicePHC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicePHC.Infrastructure.Data.Config
{
    public class EntityExampleConfiguration : IEntityTypeConfiguration<EntityExample>
    {
        public void Configure(EntityTypeBuilder<EntityExample> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
