﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Testovik_Data.Context;

#nullable disable

namespace Testovik_Data.Migrations
{
    [DbContext(typeof(TestovikContext))]
    partial class TestovikContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Testovik_Data.Entities.BrendEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brends");
                });

            modelBuilder.Entity("Testovik_Data.Entities.CoinEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Coins");
                });

            modelBuilder.Entity("Testovik_Data.Entities.OrderEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Testovik_Data.Entities.OrderWithUserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("IdOrder")
                        .HasColumnType("bigint");

                    b.Property<long>("IdTovar")
                        .HasColumnType("bigint");

                    b.Property<string>("NameTovar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrdersWithUsers");
                });

            modelBuilder.Entity("Testovik_Data.Entities.TovarEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("BrendId")
                        .HasColumnType("bigint");

                    b.Property<long>("IdBrend")
                        .HasColumnType("bigint");

                    b.Property<string>("LogoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrendId");

                    b.ToTable("Tovars");
                });

            modelBuilder.Entity("Testovik_Data.Entities.OrderWithUserEntity", b =>
                {
                    b.HasOne("Testovik_Data.Entities.OrderEntity", "Order")
                        .WithMany("OrdersWithUsersEntities")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Testovik_Data.Entities.TovarEntity", b =>
                {
                    b.HasOne("Testovik_Data.Entities.BrendEntity", "Brend")
                        .WithMany("Tovars")
                        .HasForeignKey("BrendId");

                    b.Navigation("Brend");
                });

            modelBuilder.Entity("Testovik_Data.Entities.BrendEntity", b =>
                {
                    b.Navigation("Tovars");
                });

            modelBuilder.Entity("Testovik_Data.Entities.OrderEntity", b =>
                {
                    b.Navigation("OrdersWithUsersEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
