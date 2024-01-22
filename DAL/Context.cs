using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> Opcions) : base(Opcions) { }
        public DbSet <Prioridades> Prioridades { get; set; }      
    }