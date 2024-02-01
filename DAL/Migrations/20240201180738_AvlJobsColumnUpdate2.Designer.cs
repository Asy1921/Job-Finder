﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(JobFinderDataContext))]
    [Migration("20240201180738_AvlJobsColumnUpdate2")]
    partial class AvlJobsColumnUpdate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAL.tbl_Avl_Jobs", b =>
                {
                    b.Property<int>("Job_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Job_ID"));

                    b.Property<int>("AvailablePositions")
                        .HasColumnType("integer");

                    b.Property<int>("FilledPositions")
                        .HasColumnType("integer");

                    b.Property<bool>("JobOpen")
                        .HasColumnType("boolean");

                    b.Property<string>("Job_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Job_ID");

                    b.ToTable("tbl_Avl_Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
