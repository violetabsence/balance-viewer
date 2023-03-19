﻿// <auto-generated />
using System;
using BalanceViewer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BalanceViewer.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("BalanceViewer.Entities.Balance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Calculation")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("TEXT");

                    b.Property<double>("InBalance")
                        .HasColumnType("REAL");

                    b.Property<double>("OutBalance")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Balance");
                });

            modelBuilder.Entity("BalanceViewer.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PaymentGuid")
                        .HasColumnType("TEXT");

                    b.Property<double>("Sum")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
