﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211020171948_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Core.Models.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("DisplayDiagonal")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsEsim")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PresentationDay")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("DataLayer.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });
#pragma warning restore 612, 618
        }
    }
}