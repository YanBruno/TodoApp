﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApp.Infra.Contexts;

namespace TodoApp.Infra.Migrations
{
    [DbContext(typeof(TodoAppContext))]
    partial class TodoAppcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TodoApp.Core.Entities.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("CreateAt");

                    b.Property<byte>("Done")
                        .HasColumnType("tinyint")
                        .HasColumnName("Done");

                    b.HasKey("Id");

                    b.ToTable("tbTodo");
                });

            modelBuilder.Entity("TodoApp.Core.Entities.Todo", b =>
                {
                    b.OwnsOne("TodoApp.Core.ValueObjects.Title", "Title", b1 =>
                        {
                            b1.Property<Guid>("TodoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)")
                                .HasColumnName("Title");

                            b1.HasKey("TodoId");

                            b1.ToTable("tbTodo");

                            b1.WithOwner()
                                .HasForeignKey("TodoId");
                        });

                    b.Navigation("Title");
                });
#pragma warning restore 612, 618
        }
    }
}
