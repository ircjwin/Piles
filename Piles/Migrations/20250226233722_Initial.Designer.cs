﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Piles.Data;

#nullable disable

namespace Piles.Migrations
{
    [DbContext(typeof(PilesDbContext))]
    [Migration("20250226233722_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("Piles.Data.PileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Justification")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Piles");
                });

            modelBuilder.Entity("Piles.Data.RuminationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("PileId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PileId");

                    b.ToTable("Ruminations");
                });

            modelBuilder.Entity("Piles.Data.RuminationEntity", b =>
                {
                    b.HasOne("Piles.Data.PileEntity", "Pile")
                        .WithMany("Ruminations")
                        .HasForeignKey("PileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pile");
                });

            modelBuilder.Entity("Piles.Data.PileEntity", b =>
                {
                    b.Navigation("Ruminations");
                });
#pragma warning restore 612, 618
        }
    }
}
