﻿// <auto-generated />
using System;
using Infraestructure.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.AuthorEntity", b =>
                {
                    b.Property<int>("IdAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameAuthor")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdAuthor");

                    b.ToTable("Author","Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.BookEntity", b =>
                {
                    b.Property<int>("IdBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateRelease")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("IdAuthor")
                        .HasColumnType("int");

                    b.Property<int>("IdEditorial")
                        .HasColumnType("int");

                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeBook")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdBook");

                    b.HasIndex("IdAuthor");

                    b.HasIndex("IdEditorial");

                    b.HasIndex("IdState");

                    b.HasIndex("IdTypeBook");

                    b.ToTable("Book","Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.EditorialEntity", b =>
                {
                    b.Property<int>("IdEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Editorial")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdEditorial");

                    b.ToTable("Editorial","Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.TypeBookEntity", b =>
                {
                    b.Property<int>("IdTypeBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("TypeBook")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdTypeBook");

                    b.ToTable("TypeBook","Library");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Master.StateEntity", b =>
                {
                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeState")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdState");

                    b.HasIndex("IdTypeState");

                    b.ToTable("State","Master");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Master.TypeStateEntity", b =>
                {
                    b.Property<int>("IdTypeState")
                        .HasColumnType("int");

                    b.Property<string>("TypeState")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdTypeState");

                    b.ToTable("TypeState","Master");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionEntity", b =>
                {
                    b.Property<int>("IdPermission")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("IdTypePermission")
                        .HasColumnType("int");

                    b.Property<string>("Permission")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdPermission");

                    b.HasIndex("IdTypePermission");

                    b.ToTable("Permission","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RolEntity", b =>
                {
                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdRol");

                    b.ToTable("Rol","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RolPermissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPermission")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPermission");

                    b.HasIndex("IdRol");

                    b.ToTable("RolPermissions","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RolUserEntity", b =>
                {
                    b.Property<int>("IdRolUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("IdRolUser");

                    b.HasIndex("IdRol");

                    b.HasIndex("idUser");

                    b.ToTable("RolUser","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.TypePermissionEntity", b =>
                {
                    b.Property<int>("IdTypePermission")
                        .HasColumnType("int");

                    b.Property<string>("TypePermission")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdTypePermission");

                    b.ToTable("TypePermission","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.UserEntity", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("IdUser");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User","Security");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Library.BookEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.Library.AuthorEntity", "AuthorEntity")
                        .WithMany()
                        .HasForeignKey("IdAuthor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.Library.EditorialEntity", "EditorialEntity")
                        .WithMany()
                        .HasForeignKey("IdEditorial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.Master.StateEntity", "StateEntity")
                        .WithMany()
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.Library.TypeBookEntity", "TypeBookEntity")
                        .WithMany()
                        .HasForeignKey("IdTypeBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.Master.StateEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.Master.TypeStateEntity", "TypeStateEntity")
                        .WithMany()
                        .HasForeignKey("IdTypeState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.TypePermissionEntity", "TypePermissionEntity")
                        .WithMany("PermissionEntities")
                        .HasForeignKey("IdTypePermission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RolPermissionEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.PermissionEntity", "PermissionEntity")
                        .WithMany("RolPermissionEntities")
                        .HasForeignKey("IdPermission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.RolEntity", "RolEntity")
                        .WithMany("RolPermissionEntities")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RolUserEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.RolEntity", "RolEntity")
                        .WithMany("RolUserEntities")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.UserEntity", "UserEntity")
                        .WithMany("RolUserEntities")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
