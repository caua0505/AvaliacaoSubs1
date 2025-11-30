using Microsoft.EntityFrameworkCore;
using ApiProjeto.Models;    

namespace ApiProjeto.Data
{
    public class AppDnContext : DbContext
    {
        public AppDnContext(DbContextOptions<AppDnContext> options) : base(options)
        {}

        public DbSet<Produto> Produtos { get; set; }
    }
}