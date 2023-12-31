using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiEmpresa3d.model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ApiEmpresa3d.Context
{
    public class ApiEmpresa3dContext : IdentityDbContext
    {
        public ApiEmpresa3dContext(DbContextOptions options) : base(options){}
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Compra> Compra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}