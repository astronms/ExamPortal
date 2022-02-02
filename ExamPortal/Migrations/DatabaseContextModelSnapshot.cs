﻿// <auto-generated />
using System;
using ExamPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamPortal.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamPortal.Data.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ExamPortal.Data.CourseUser", b =>
                {
                    b.Property<Guid>("CourseUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CourseUserId");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("CourseUsers");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Exam", b =>
                {
                    b.Property<Guid>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExamId");

                    b.HasIndex("SessionId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Question", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("QuestionId");

                    b.HasIndex("TaskId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Session", b =>
                {
                    b.Property<Guid>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SessionId");

                    b.HasIndex("CourseId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortId")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("ExamId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Value", b =>
                {
                    b.Property<Guid>("ValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Regex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ValueId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.Answer", b =>
                {
                    b.Property<Guid>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskToCheckId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnswerId");

                    b.HasIndex("TaskToCheckId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.ExamToCheck", b =>
                {
                    b.Property<Guid>("ExamToCheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionToCheckId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExamToCheckId");

                    b.HasIndex("SessionToCheckId");

                    b.ToTable("ExamsToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.SessionToCheck", b =>
                {
                    b.Property<Guid>("SessionToCheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionToCheckId");

                    b.ToTable("SessionsToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.TaskToCheck", b =>
                {
                    b.Property<Guid>("TaskToCheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamToCheckId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SortId")
                        .HasColumnType("int");

                    b.HasKey("TaskToCheckId");

                    b.HasIndex("ExamToCheckId");

                    b.ToTable("TasksToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.ValueToCheck", b =>
                {
                    b.Property<Guid>("ValueToCheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SortId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ValueToCheckId");

                    b.HasIndex("AnswerId");

                    b.ToTable("ValuesToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.Users.StudentInfo", b =>
                {
                    b.Property<Guid>("StudentInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentInfoId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("StudentsInfos");
                });

            modelBuilder.Entity("ExamPortal.Data.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "ccdc46e3-7d5b-4514-8494-3f73dd8edcf6",
                            ConcurrencyStamp = "875e9c17-6ba5-42ab-acb0-e484b9d22062",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "64b28e24-49d0-4074-8792-f8aa825b469e",
                            ConcurrencyStamp = "4c8bcbd8-6ad9-4f50-b502-13fa1d3bacff",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ExamPortal.Data.CourseUser", b =>
                {
                    b.HasOne("ExamPortal.Data.Course", "Course")
                        .WithMany("CourseUsers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamPortal.Data.Users.User", "User")
                        .WithMany("CourseUsers")
                        .HasForeignKey("UserId");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Exam", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamData.Session", "Session")
                        .WithMany("Exams")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Question", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamData.Task", "Task")
                        .WithMany("Questions")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Session", b =>
                {
                    b.HasOne("ExamPortal.Data.Course", "Course")
                        .WithMany("Sessions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Task", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamData.Exam", "Exam")
                        .WithMany("Task")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Value", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamData.Question", "Question")
                        .WithMany("Value")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.Answer", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamToSendModel.TaskToCheck", "TaskToCheck")
                        .WithMany("Answers")
                        .HasForeignKey("TaskToCheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.ExamToCheck", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamToSendModel.SessionToCheck", "SessionToCheck")
                        .WithMany("ExamsToCheck")
                        .HasForeignKey("SessionToCheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SessionToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.TaskToCheck", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamToSendModel.ExamToCheck", "ExamToCheck")
                        .WithMany("TaskToCheck")
                        .HasForeignKey("ExamToCheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExamToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.ValueToCheck", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamToSendModel.Answer", "Answer")
                        .WithMany("ValueToCheck")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("ExamPortal.Data.Users.StudentInfo", b =>
                {
                    b.HasOne("ExamPortal.Data.Users.User", null)
                        .WithOne("StudentInfo")
                        .HasForeignKey("ExamPortal.Data.Users.StudentInfo", "UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ExamPortal.Data.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ExamPortal.Data.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamPortal.Data.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ExamPortal.Data.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExamPortal.Data.Course", b =>
                {
                    b.Navigation("CourseUsers");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Exam", b =>
                {
                    b.Navigation("Task");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Question", b =>
                {
                    b.Navigation("Value");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Session", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Task", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.Answer", b =>
                {
                    b.Navigation("ValueToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.ExamToCheck", b =>
                {
                    b.Navigation("TaskToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.SessionToCheck", b =>
                {
                    b.Navigation("ExamsToCheck");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamToSendModel.TaskToCheck", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("ExamPortal.Data.Users.User", b =>
                {
                    b.Navigation("CourseUsers");

                    b.Navigation("StudentInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
