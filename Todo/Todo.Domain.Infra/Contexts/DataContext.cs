using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("Todo");
            modelBuilder.Entity<Tarefa>().Property(x => x.Id);
            modelBuilder.Entity<Tarefa>().Property(x => x.Usuario).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Tarefa>().Property(x => x.Titulo).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<Tarefa>().Property(x => x.Concluido).HasColumnType("bit");
            modelBuilder.Entity<Tarefa>().Property(x => x.Concluido);
            modelBuilder.Entity<Tarefa>().HasIndex(b => b.Concluido);
        }
    }
}
