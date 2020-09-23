﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using onlineexam.Persistence;

namespace onlineexam.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200814144504_akjdsdsssdsdzxas")]
    partial class akjdsdsssdsdzxas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("onlineexam.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("onlineexam.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Identity");

                    b.Property<string>("Image");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RoleId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("onlineexam.Models.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("onlineexam.Models.Batch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("onlineexam.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseDetails");

                    b.Property<string>("Name");

                    b.Property<int?>("SemesterId")
                        .IsRequired();

                    b.Property<string>("TeacherId");

                    b.Property<string>("TeachersId");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("TeachersId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("onlineexam.Models.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<string>("FileName");

                    b.Property<string>("Title");

                    b.Property<DateTime>("dateTime");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("FileModels");
                });

            modelBuilder.Entity("onlineexam.Models.Identity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Identities");
                });

            modelBuilder.Entity("onlineexam.Models.InfoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<string>("Details");

                    b.Property<string>("Title");

                    b.Property<DateTime>("dateTime");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("InfoModels");
                });

            modelBuilder.Entity("onlineexam.Models.Quiz.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("Starttime");

                    b.Property<string>("TestTitle");

                    b.Property<int>("TotalMarks");

                    b.Property<int>("TotalQuestion");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("onlineexam.Models.Quiz.TestQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrectAnswer");

                    b.Property<string>("Option1");

                    b.Property<string>("Option2");

                    b.Property<string>("Option3");

                    b.Property<string>("Option4");

                    b.Property<int>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("TestQuestions");
                });

            modelBuilder.Entity("onlineexam.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BatchId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("onlineexam.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("onlineexam.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("onlineexam.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("onlineexam.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("onlineexam.Models.ApplicationUser", b =>
                {
                    b.HasOne("onlineexam.Models.ApplicationRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("onlineexam.Models.ApplicationUserRole", b =>
                {
                    b.HasOne("onlineexam.Models.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("onlineexam.Models.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("onlineexam.Models.Course", b =>
                {
                    b.HasOne("onlineexam.Models.Semester", "Semesters")
                        .WithMany("Courses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("onlineexam.Models.ApplicationUser", "Teachers")
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("onlineexam.Models.FileModel", b =>
                {
                    b.HasOne("onlineexam.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("onlineexam.Models.InfoModel", b =>
                {
                    b.HasOne("onlineexam.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("onlineexam.Models.Quiz.Test", b =>
                {
                    b.HasOne("onlineexam.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("onlineexam.Models.Quiz.TestQuestion", b =>
                {
                    b.HasOne("onlineexam.Models.Quiz.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("onlineexam.Models.Semester", b =>
                {
                    b.HasOne("onlineexam.Models.Batch", "Batches")
                        .WithMany()
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
