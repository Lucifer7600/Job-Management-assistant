using JobFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFlow.Infrastructure.Data;

public class JobFlowDbContext : DbContext
{
    public JobFlowDbContext(DbContextOptions<JobFlowDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs => Set<Job>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Job>(entity =>
        {
            entity.Property(j => j.CompanyName).HasMaxLength(200).IsRequired();
            entity.Property(j => j.Position).HasMaxLength(200).IsRequired();
            entity.Property(j => j.LinkedInUrl).HasMaxLength(500);
            entity.Property(j => j.Website).HasMaxLength(500);
            entity.Property(j => j.Type).HasMaxLength(100);
        });
    }
}
