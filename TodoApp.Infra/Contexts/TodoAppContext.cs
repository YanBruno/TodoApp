using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;
using TodoApp.Infra.Contexts.Configurations;
using TodoApp.Shared;

namespace TodoApp.Infra.Contexts
{
    public class TodoAppContext : DbContext{

        public TodoAppContext(){}

        public TodoAppContext(DbContextOptions<TodoAppContext> options):base(options){}

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new TodoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            // optionsBuilder.UseSqlServer(Settings.StringConnection);
            optionsBuilder.UseInMemoryDatabase("todoapp");

        } 
        
    }
}