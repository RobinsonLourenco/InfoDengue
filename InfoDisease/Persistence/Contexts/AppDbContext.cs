﻿using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using InfoDisease.Domain.Models;

namespace InfoDisease.Persistence.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Requestor> Solicitante { get; set; }
        public DbSet<Report> Relatorio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requestor>().HasKey(p => p.SolicitanteId);
            modelBuilder.Entity<Requestor>().HasIndex(s => s.Cpf).IsUnique(); 
            modelBuilder.Entity<Requestor>().HasMany(s => s.reports).WithOne(r => r.Solicitante).HasForeignKey(r => r.SolicitanteId);
            modelBuilder.Entity<Report>().HasKey(p => p.RelatorioId);
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}