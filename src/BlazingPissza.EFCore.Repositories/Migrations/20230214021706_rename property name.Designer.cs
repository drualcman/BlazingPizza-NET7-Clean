﻿// <auto-generated />
using System;
using BlazingPizza.EFCore.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazingPizza.EFCore.Repositories.Migrations
{
    [DbContext(typeof(BlazingPizzaContext))]
    [Migration("20230214021706_rename property name")]
    partial class renamepropertyname
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeliveryAddressId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaSpecialId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaSpecialId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.PizzaSpecial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BasePrice = 189.99m,
                            Description = "Es de queso y delicioso. ¿Por qué no querrías una?",
                            ImageUrl = "cheese.jpg",
                            Name = "Pizza clásica de queso"
                        },
                        new
                        {
                            Id = 2,
                            BasePrice = 227.99m,
                            Description = "Tiene TODO tipo de tocino",
                            ImageUrl = "bacon.jpg",
                            Name = "Tocinator"
                        },
                        new
                        {
                            Id = 3,
                            BasePrice = 199.50m,
                            Description = "Es la pizza con la que creciste, ¡pero ardientemente deliciosa!",
                            ImageUrl = "pepperoni.jpg",
                            Name = "Clásica de pepperoni"
                        },
                        new
                        {
                            Id = 4,
                            BasePrice = 228.75m,
                            Description = "Pollo picante, salsa picante y queso azul, garantizado que entrarás en calor",
                            ImageUrl = "meaty.jpg",
                            Name = "Pollo búfalo"
                        },
                        new
                        {
                            Id = 5,
                            BasePrice = 209.00m,
                            Description = "Tiene champiñones. ¿No es obvio?",
                            ImageUrl = "mushroom.jpg",
                            Name = "Amantes del champiñón"
                        },
                        new
                        {
                            Id = 6,
                            BasePrice = 190.25m,
                            Description = "De piña, jamón y queso...",
                            ImageUrl = "hawaiian.jpg",
                            Name = "Hawaiana"
                        },
                        new
                        {
                            Id = 7,
                            BasePrice = 218.50m,
                            Description = "Es como una ensalada, pero en una pizza",
                            ImageUrl = "salad.jpg",
                            Name = "Delicia vegetariana"
                        },
                        new
                        {
                            Id = 8,
                            BasePrice = 189.99m,
                            Description = "Pizza italiana tradicional con tomates y albahaca",
                            ImageUrl = "margherita.jpg",
                            Name = "Margarita"
                        });
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.PizzaTopping", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingId")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "ToppingId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaTopping");
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Queso extra",
                            Price = 47.50m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tocino de pavo",
                            Price = 56.80m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tocino de jabalÃ­",
                            Price = 56.80m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tocino de ternera",
                            Price = 56.80m
                        },
                        new
                        {
                            Id = 5,
                            Name = "TÃ© y bollos",
                            Price = 95.00m
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bollos reciÃ©n horneados",
                            Price = 85.50m
                        },
                        new
                        {
                            Id = 7,
                            Name = "Pimiento",
                            Price = 19.00m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Cebolla",
                            Price = 19.00m
                        },
                        new
                        {
                            Id = 9,
                            Name = "ChampiÃ±ones",
                            Price = 19.00m
                        },
                        new
                        {
                            Id = 10,
                            Name = "Pepperoni",
                            Price = 19.00m
                        },
                        new
                        {
                            Id = 11,
                            Name = "Salchicha de pato",
                            Price = 60.80m
                        },
                        new
                        {
                            Id = 12,
                            Name = "AlbÃ³ndigas de venado",
                            Price = 47.50m
                        },
                        new
                        {
                            Id = 13,
                            Name = "Cubierta de langosta",
                            Price = 1225.50m
                        },
                        new
                        {
                            Id = 14,
                            Name = "Caviar de esturiÃ³n",
                            Price = 1933.25m
                        },
                        new
                        {
                            Id = 15,
                            Name = "Corazones de alcachofa",
                            Price = 64.60m
                        },
                        new
                        {
                            Id = 16,
                            Name = "Tomates frescos",
                            Price = 39.00m
                        },
                        new
                        {
                            Id = 17,
                            Name = "Albahaca",
                            Price = 39.00m
                        },
                        new
                        {
                            Id = 18,
                            Name = "Filete",
                            Price = 161.50m
                        },
                        new
                        {
                            Id = 19,
                            Name = "Pimientos picantes",
                            Price = 79.80m
                        },
                        new
                        {
                            Id = 20,
                            Name = "Pollo bÃºfalo",
                            Price = 95.00m
                        },
                        new
                        {
                            Id = 21,
                            Name = "Queso azul",
                            Price = 47.50m
                        });
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.Order", b =>
                {
                    b.HasOne("BlazingPizza.EFCore.Repositories.Entities.Address", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId");

                    b.OwnsOne("BlazingPizza.EFCore.Repositories.Entities.LatLong", "DeliveryLocation", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("DeliveryAddress");

                    b.Navigation("DeliveryLocation");
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.Pizza", b =>
                {
                    b.HasOne("BlazingPizza.EFCore.Repositories.Entities.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazingPizza.EFCore.Repositories.Entities.PizzaSpecial", "PizzaSpecial")
                        .WithMany()
                        .HasForeignKey("PizzaSpecialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PizzaSpecial");
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.PizzaTopping", b =>
                {
                    b.HasOne("BlazingPizza.EFCore.Repositories.Entities.Pizza", null)
                        .WithMany("Toppings")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazingPizza.EFCore.Repositories.Entities.Topping", "Topping")
                        .WithMany()
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.Order", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("BlazingPizza.EFCore.Repositories.Entities.Pizza", b =>
                {
                    b.Navigation("Toppings");
                });
#pragma warning restore 612, 618
        }
    }
}
