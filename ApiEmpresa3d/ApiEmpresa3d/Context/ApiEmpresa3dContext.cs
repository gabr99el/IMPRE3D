using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiEmpresa3d.model;

namespace ApiEmpresa3d.Context
{
    public class ApiEmpresa3dContext : DbContext
    {
        public ApiEmpresa3dContext(DbContextOptions options) : base(options){}
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Projeto> Projeto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}