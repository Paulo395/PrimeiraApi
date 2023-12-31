﻿using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Models;
using MinhaAPI.Data.Map;

namespace MinhaAPI.Data
{
    public class MinhaApiDBContex : DbContext
    {
        public MinhaApiDBContex(DbContextOptions<MinhaApiDBContex> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
