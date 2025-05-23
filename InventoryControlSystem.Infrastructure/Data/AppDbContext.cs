﻿using InventoryControlSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Categoria> TB_Categorias { get; set; }
        public DbSet<Endereco> TB_Enderecos { get; set; }
        public DbSet<Fornecedor> TB_Fornecedores { get; set; }
        public DbSet<Produto> TB_Produtos { get; set; }
        public DbSet<Usuario> TB_Usuarios { get; set; }
        public DbSet<RefreshTokens> TB_RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>()
                .HasOne(f => f.Endereco)
                .WithOne() // ou .WithMany() 
                .HasForeignKey<Fornecedor>(f => f.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade); // delete em cascata

            base.OnModelCreating(modelBuilder);
        }
    }
}
