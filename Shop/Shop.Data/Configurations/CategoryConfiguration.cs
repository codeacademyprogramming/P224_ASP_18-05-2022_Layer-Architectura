using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(b => b.Image).HasMaxLength(1000);
            builder.Property(b => b.Name).HasMaxLength(25).IsRequired();

            builder.HasOne(b => b.Parent).WithMany(b => b.Children).HasForeignKey(b => b.ParentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
