﻿// <auto-generated />
using System;
using AID.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AID_Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220331202535_001_change_data_time")]
    partial class _001_change_data_time
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AID.Entites.Announcement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("photoUrl")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("AID.Entites.Avatar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("avatarUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("Avatars");
                });

            modelBuilder.Entity("AID.Entites.DataSet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("photoUrl")
                        .HasColumnType("text");

                    b.Property<int>("tagId")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Datasets");
                });

            modelBuilder.Entity("AID.Entites.Tag", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("AID.Entites.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("avatarId")
                        .HasColumnType("integer");

                    b.Property<double>("balance")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<double>("totalGain")
                        .HasColumnType("double precision");

                    b.Property<double>("totalVideoEditetTime")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AID.Entites.Video", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("coverImageUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<double>("totalGain")
                        .HasColumnType("double precision");

                    b.Property<double>("videoLength")
                        .HasColumnType("double precision");

                    b.Property<string>("videoUrl")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("AID.Entites.WithdrawRequest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<double>("balance")
                        .HasColumnType("double precision");

                    b.Property<string>("cardHolder")
                        .HasColumnType("text");

                    b.Property<string>("cardNo")
                        .HasColumnType("text");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("cvv")
                        .HasColumnType("integer");

                    b.Property<string>("expDate")
                        .HasColumnType("text");

                    b.Property<bool>("isApproved")
                        .HasColumnType("boolean");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("WithdrawRequests");
                });
#pragma warning restore 612, 618
        }
    }
}