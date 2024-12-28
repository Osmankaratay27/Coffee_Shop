﻿// <auto-generated />
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241222124013_Order_Status_Added")]
    partial class Order_Status_Added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Concrete.CoffeeMenu", b =>
                {
                    b.Property<int>("CoffeeMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoffeeMenuId"));

                    b.Property<int>("CoffeeMenuCount")
                        .HasColumnType("int");

                    b.Property<string>("CoffeeMenuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoffeeMenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CoffeeMenuPrice")
                        .HasColumnType("float");

                    b.Property<string>("CoffeeMenuUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoffeeMenuId");

                    b.ToTable("CoffeeMenus");
                });

            modelBuilder.Entity("EntityLayer.Concrete.CreditCart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartID"));

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("CartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CartNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegisterID")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CartID");

                    b.HasIndex("RegisterID");

                    b.ToTable("CreditCarts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("OrderCount")
                        .HasColumnType("int");

                    b.Property<string>("OrderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OrderPrice")
                        .HasColumnType("float");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("OrderUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegisterID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("RegisterID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Register", b =>
                {
                    b.Property<int>("RegisterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegisterID"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("UserStatus")
                        .HasColumnType("bit");

                    b.HasKey("RegisterID");

                    b.HasIndex("RoleId");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EntityLayer.Concrete.CreditCart", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Register", "Register")
                        .WithMany("CreditCarts")
                        .HasForeignKey("RegisterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Register");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Order", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Register", "Register")
                        .WithMany("Orders")
                        .HasForeignKey("RegisterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Register");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Register", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Register", b =>
                {
                    b.Navigation("CreditCarts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
