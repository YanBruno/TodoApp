using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;
using TodoApp.Infra.Contexts.Configurations;

namespace TodoApp.Infra.Contexts
{
    public class TodoAppcontext : DbContext{

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new TodoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"server=RIMTDTINB128179; Database=todoapp;Integrated Security=SSPI;");

            base.OnConfiguring(optionsBuilder);
        } 
        
    }
}