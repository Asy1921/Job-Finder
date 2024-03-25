﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(JobFinderDataContext))]
    partial class JobFinderDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAL.tbl_Avl_Job", b =>
                {
                    b.Property<string>("Job_ID")
                        .HasColumnType("text");

                    b.Property<int>("AvailablePositions")
                        .HasColumnType("integer");

                    b.Property<string>("Coy_ID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FilledPositions")
                        .HasColumnType("integer");

                    b.Property<bool>("JobOpen")
                        .HasColumnType("boolean");

                    b.Property<string>("Job_Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Job_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("YearsOfExperienceRequired")
                        .HasColumnType("integer");

                    b.HasKey("Job_ID");

                    b.HasIndex("Coy_ID");

                    b.ToTable("tbl_Avl_Jobs");
                });

            modelBuilder.Entity("DAL.tbl_Company", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Estd_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HQ_Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("tbl_Companies");
                });

            modelBuilder.Entity("DAL.tbl_Job_Applicant", b =>
                {
                    b.Property<string>("Applicant_ID")
                        .HasColumnType("text");

                    b.Property<string>("Job_ID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SubmittedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Applicant_ID");

                    b.HasIndex("Job_ID");

                    b.ToTable("tbl_Job_Applicants");
                });

            modelBuilder.Entity("DAL.tbl_Job_Qualification", b =>
                {
                    b.Property<string>("QualificationRequired")
                        .HasColumnType("text");

                    b.Property<string>("Job_ID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Required")
                        .HasColumnType("boolean");

                    b.HasKey("QualificationRequired");

                    b.HasIndex("Job_ID");

                    b.ToTable("tbl_Job_Qualifications");
                });

            modelBuilder.Entity("DAL.tbl_Job_Skill", b =>
                {
                    b.Property<string>("Skill_Name")
                        .HasColumnType("text");

                    b.Property<string>("Job_ID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Required")
                        .HasColumnType("boolean");

                    b.HasKey("Skill_Name");

                    b.HasIndex("Job_ID");

                    b.ToTable("tbl_Job_Skills");
                });

            modelBuilder.Entity("DAL.tbl_User", b =>
                {
                    b.Property<string>("User_ID")
                        .HasColumnType("text");

                    b.Property<string>("CompanyID")
                        .HasColumnType("text");

                    b.Property<string>("CurrentLocation")
                        .HasColumnType("text");

                    b.Property<string>("Domain")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("HighestQualification")
                        .HasColumnType("text");

                    b.Property<bool?>("IsHiring")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Joined_On")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("YearsOfExperience")
                        .HasColumnType("integer");

                    b.HasKey("User_ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("tbl_Users");
                });

            modelBuilder.Entity("DAL.tbl_User_Qualification", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Institute")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("User_ID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("User_ID");

                    b.ToTable("tbl_User_Qualifications");
                });

            modelBuilder.Entity("DAL.tbl_User_Secrets", b =>
                {
                    b.Property<string>("User_ID")
                        .HasColumnType("text");

                    b.Property<string>("pw")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("User_ID");

                    b.ToTable("tbl_User_Secrets");
                });

            modelBuilder.Entity("DAL.tbl_User_Skill", b =>
                {
                    b.Property<string>("Skill_Name")
                        .HasColumnType("text");

                    b.Property<string>("User_ID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Skill_Name");

                    b.HasIndex("User_ID");

                    b.ToTable("tbl_User_Skills");
                });

            modelBuilder.Entity("DAL.tbl_Avl_Job", b =>
                {
                    b.HasOne("DAL.tbl_Company", "Company")
                        .WithMany()
                        .HasForeignKey("Coy_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DAL.tbl_Job_Applicant", b =>
                {
                    b.HasOne("DAL.tbl_User", "Users")
                        .WithMany()
                        .HasForeignKey("Applicant_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.tbl_Avl_Job", "AvailableJobs")
                        .WithMany()
                        .HasForeignKey("Job_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AvailableJobs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DAL.tbl_Job_Qualification", b =>
                {
                    b.HasOne("DAL.tbl_Avl_Job", "Job")
                        .WithMany()
                        .HasForeignKey("Job_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("DAL.tbl_Job_Skill", b =>
                {
                    b.HasOne("DAL.tbl_Avl_Job", "Job")
                        .WithMany()
                        .HasForeignKey("Job_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("DAL.tbl_User", b =>
                {
                    b.HasOne("DAL.tbl_Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DAL.tbl_User_Qualification", b =>
                {
                    b.HasOne("DAL.tbl_User", "Users")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DAL.tbl_User_Secrets", b =>
                {
                    b.HasOne("DAL.tbl_User", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.tbl_User_Skill", b =>
                {
                    b.HasOne("DAL.tbl_User", "Users")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
