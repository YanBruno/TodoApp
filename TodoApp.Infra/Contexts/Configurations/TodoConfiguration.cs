using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Core.Entities;

namespace TodoApp.Infra.Contexts.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(todo => todo.Id);

            builder.Property(todo => todo.CreateAt)
                .IsRequired()
                .HasColumnName("CreateAt")
                .HasColumnType("smalldatetime");

            builder.Property(todo => todo.Done)
                .IsRequired()
                .HasColumnName("Done")
                .HasColumnType("tinyint");

            builder.OwnsOne(
                todo => todo.Title, 
                title =>{
                    title.Property(t => t.Description)
                    .IsRequired()
                    .HasColumnName("Title")
                    .HasColumnType("varchar(150)");
            });
            
            builder.ToTable("tbTodo");
        }
    }
}