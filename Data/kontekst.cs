using projekt.Models;
using Microsoft.EntityFrameworkCore;

namespace projekt.Data
{
    public class kontekst : DbContext
    {
        public kontekst(DbContextOptions<kontekst> options) : base(options)
        {
        }

        public DbSet<Avtor> Avtorji { get; set; }
        public DbSet<Dokument> Dokumenti { get; set; }
        public DbSet<Tip> Tipi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avtor>().ToTable("Avtor");
            modelBuilder.Entity<Dokument>().ToTable("Dokument");
            modelBuilder.Entity<Tip>().ToTable("Tip");
        }
    }
}