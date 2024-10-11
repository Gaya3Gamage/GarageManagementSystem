using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GarageManagement.Api.Contexts;

public partial class GarageManagementSystemContext : DbContext
{
    public GarageManagementSystemContext()
    {
    }

    public GarageManagementSystemContext(DbContextOptions<GarageManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var connectionString = configuration.GetConnectionString("GarageManagementMySQL");
            optionsBuilder.UseLazyLoadingProxies().UseMySQL(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.Nid }).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Nid)
                .HasMaxLength(45)
                .HasColumnName("NID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(10)
                .HasColumnName("PhoneNO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
