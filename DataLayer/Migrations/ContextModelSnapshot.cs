﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Core.Models.AccountInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER")
                        .HasColumnName("RoleId");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Models.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Color")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ColorId");

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

            modelBuilder.Entity("Core.Models.AccountInfo", b =>
                {
                    b.OwnsOne("Core.Models.LoginInfo", "LoginInfo", b1 =>
                        {
                            b1.Property<Guid>("AccountInfoId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Login")
                                .HasColumnType("TEXT")
                                .HasColumnName("Login");

                            b1.Property<string>("Password")
                                .HasColumnType("TEXT")
                                .HasColumnName("Password");

                            b1.HasKey("AccountInfoId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("AccountInfoId");
                        });

                    b.Navigation("LoginInfo");
                });
#pragma warning restore 612, 618
        }
    }
}