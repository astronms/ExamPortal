﻿// <auto-generated />
using System;
using ExamPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamPortal.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220309201648_ImprovmentsInResult3")]
    partial class ImprovmentsInResult3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamPortal.Data.ActivetedExams.ActivatedExam", b =>
                {
                    b.Property<Guid>("ActivatedExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ExamAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFinish")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ActivatedExamId");

                    b.HasIndex("ExamAnswersId")
                        .IsUnique()
                        .HasFilter("[ExamAnswersId] IS NOT NULL");

                    b.HasIndex("ExamId");

                    b.HasIndex("UserId");

                    b.ToTable("ActivatedExams");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.AnswersValue", b =>
                {
                    b.Property<Guid>("AnswersValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SortId")
                        .HasColumnType("int");

                    b.Property<Guid>("TaskAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnswersValueId");

                    b.HasIndex("TaskAnswersId");

                    b.ToTable("AnswersValue");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.ExamAnswers", b =>
                {
                    b.Property<Guid>("ExamAnswersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExamAnswersId");

                    b.ToTable("ExamAnswers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.TaskAnswers", b =>
                {
                    b.Property<Guid>("TaskAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ExamAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TaskAnswerId");

                    b.HasIndex("ExamAnswersId");

                    b.HasIndex("ExamTaskId");

                    b.ToTable("TaskAnswers");
                });

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

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExamId");

                    b.HasIndex("SessionId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.ExamTask", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortId")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamTask");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Question", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("QuestionId");

                    b.HasIndex("TaskId")
                        .IsUnique();

                    b.ToTable("Question");
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

                    b.ToTable("Value");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.ExamResult", b =>
                {
                    b.Property<Guid>("ExamResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("FinalScore")
                        .HasColumnType("float");

                    b.Property<double>("MaxScore")
                        .HasColumnType("float");

                    b.Property<Guid>("SessionResultId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ExamResultId");

                    b.HasIndex("SessionResultId");

                    b.HasIndex("UserId");

                    b.ToTable("ExamResult");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.ResultValue", b =>
                {
                    b.Property<Guid>("ResultValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Actual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MaxScore")
                        .HasColumnType("float");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<Guid>("TaskResultId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ResultValueId");

                    b.HasIndex("TaskResultId");

                    b.ToTable("ResultValue");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.SessionResult", b =>
                {
                    b.Property<Guid>("SessionResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionResultId");

                    b.HasIndex("SessionId")
                        .IsUnique();

                    b.ToTable("SessionsResult");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.TaskResult", b =>
                {
                    b.Property<Guid>("TaskResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamResultId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("SortId")
                        .HasColumnType("int");

                    b.Property<double>("TaskMaxScore")
                        .HasColumnType("float");

                    b.Property<double>("TaskScore")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskResultId");

                    b.HasIndex("ExamResultId");

                    b.ToTable("TaskResult");
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

                    b.ToTable("StudentInfo");
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

                    b.HasData(
                        new
                        {
                            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "54c15d06-6ef2-4685-b26a-a39cfa0a0b35",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Super",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEO2SKGzldNVczomTdUyT6HsIg/K5qcF6pGGsWhd9CN+S3pKd83deMm1ipeKj/vQcjg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d08c9192-0621-4afb-9d25-5fb5036416d0",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        });
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
                            Id = "9a48d905-08ad-4548-8da3-b168be98b43a",
                            ConcurrencyStamp = "c5f92353-7fc5-4ef7-b1bb-9a0d633aab13",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "d98f3528-5b3b-429c-b82d-a30df84f17da",
                            ConcurrencyStamp = "9e07a0f9-1404-4146-b7b4-dee5fb74f7a9",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd",
                            ConcurrencyStamp = "3a066e77-645b-491f-bff8-704c97d2956e",
                            Name = "SuperAdministrator",
                            NormalizedName = "SUPERADMINISTRATOR"
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

                    b.HasData(
                        new
                        {
                            UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                            RoleId = "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd"
                        });
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

            modelBuilder.Entity("ExamPortal.Data.ActivetedExams.ActivatedExam", b =>
                {
                    b.HasOne("ExamPortal.Data.Answers.ExamAnswers", "ExamAnswers")
                        .WithOne("ActivatedExams")
                        .HasForeignKey("ExamPortal.Data.ActivetedExams.ActivatedExam", "ExamAnswersId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ExamPortal.Data.ExamData.Exam", "Exam")
                        .WithMany("ActivatedExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ExamPortal.Data.Users.User", "User")
                        .WithMany("ActivatedExams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Exam");

                    b.Navigation("ExamAnswers");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.AnswersValue", b =>
                {
                    b.HasOne("ExamPortal.Data.Answers.TaskAnswers", "TaskAnswers")
                        .WithMany("AnswersValue")
                        .HasForeignKey("TaskAnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskAnswers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.TaskAnswers", b =>
                {
                    b.HasOne("ExamPortal.Data.Answers.ExamAnswers", "ExamAnswers")
                        .WithMany("TaskAnswers")
                        .HasForeignKey("ExamAnswersId");

                    b.HasOne("ExamPortal.Data.ExamData.ExamTask", "ExamTask")
                        .WithMany()
                        .HasForeignKey("ExamTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExamAnswers");

                    b.Navigation("ExamTask");
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

            modelBuilder.Entity("ExamPortal.Data.ExamData.ExamTask", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamData.Exam", "Exam")
                        .WithMany("Task")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Question", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamData.ExamTask", "Task")
                        .WithOne("Questions")
                        .HasForeignKey("ExamPortal.Data.ExamData.Question", "TaskId")
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

            modelBuilder.Entity("ExamPortal.Data.ExamData.Value", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamData.Question", "Question")
                        .WithMany("Value")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.ExamResult", b =>
                {
                    b.HasOne("ExamPortal.Data.Result.SessionResult", "SessionResult")
                        .WithMany("Exams")
                        .HasForeignKey("SessionResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamPortal.Data.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("SessionResult");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.ResultValue", b =>
                {
                    b.HasOne("ExamPortal.Data.Result.TaskResult", "TaskResult")
                        .WithMany("ResultValues")
                        .HasForeignKey("TaskResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskResult");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.SessionResult", b =>
                {
                    b.HasOne("ExamPortal.Data.ExamData.Session", "Session")
                        .WithOne("SessionResult")
                        .HasForeignKey("ExamPortal.Data.Result.SessionResult", "SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.TaskResult", b =>
                {
                    b.HasOne("ExamPortal.Data.Result.ExamResult", "ExamResult")
                        .WithMany("Task")
                        .HasForeignKey("ExamResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExamResult");
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

            modelBuilder.Entity("ExamPortal.Data.Answers.ExamAnswers", b =>
                {
                    b.Navigation("ActivatedExams");

                    b.Navigation("TaskAnswers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.TaskAnswers", b =>
                {
                    b.Navigation("AnswersValue");
                });

            modelBuilder.Entity("ExamPortal.Data.Course", b =>
                {
                    b.Navigation("CourseUsers");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Exam", b =>
                {
                    b.Navigation("ActivatedExams");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.ExamTask", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Question", b =>
                {
                    b.Navigation("Value");
                });

            modelBuilder.Entity("ExamPortal.Data.ExamData.Session", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("SessionResult");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.ExamResult", b =>
                {
                    b.Navigation("Task");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.SessionResult", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("ExamPortal.Data.Result.TaskResult", b =>
                {
                    b.Navigation("ResultValues");
                });

            modelBuilder.Entity("ExamPortal.Data.Users.User", b =>
                {
                    b.Navigation("ActivatedExams");

                    b.Navigation("CourseUsers");

                    b.Navigation("StudentInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
