﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectRunner.Common.Entities;

namespace ProjectRunner.Infra.Data.Mapping
{
    public class ExecutableMapper : IEntityTypeConfiguration<Executable>
    {
        public void Configure(EntityTypeBuilder<Executable> builder)
        {
            builder.ToTable("Executable");
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("Varchar(100)");
            builder.Property(prop => prop.FileName)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("FileName")
               .HasColumnType("Varchar(255)");
        }
    }
}
