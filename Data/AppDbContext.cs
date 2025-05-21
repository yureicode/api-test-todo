using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
     public DbSet<ToDo> ToDos { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=meubanco.db");
}   
