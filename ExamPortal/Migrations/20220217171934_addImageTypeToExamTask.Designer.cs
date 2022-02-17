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
    [Migration("20220217171934_addImageTypeToExamTask")]
    partial class addImageTypeToExamTask
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

                    b.Property<Guid>("ExamAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ActivatedExamId");

                    b.HasIndex("ExamAnswersId")
                        .IsUnique();

                    b.HasIndex("ExamId");

                    b.HasIndex("UserId");

                    b.ToTable("ActivatedExams");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.Answers", b =>
                {
                    b.Property<Guid>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnswerId");

                    b.HasIndex("TaskAnswersId")
                        .IsUnique();

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.AnswersValue", b =>
                {
                    b.Property<Guid>("AnswersValueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnswersValueId");

                    b.ToTable("AnswersValue");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.ExamAnswers", b =>
                {
                    b.Property<Guid>("ExamAnswersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActivatedExamsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SessionAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamAnswersId");

                    b.HasIndex("SessionAnswersId");

                    b.ToTable("ExamAnswers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.SessionAnswers", b =>
                {
                    b.Property<Guid>("SessionAnswersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionAnswersId");

                    b.ToTable("SessionAnswers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.TaskAnswers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TaskAnswers")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExamAnswersId");

                    b.HasIndex("TaskAnswers");

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

                    b.Property<Guid?>("SessionAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExamId");

                    b.HasIndex("SessionAnswersId");

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
                            Id = "ffc169df-6a8c-4b61-9657-ac22dcc56e21",
                            ConcurrencyStamp = "a300e95c-b115-4612-8c36-76d88e24d4e4",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "2995c053-638f-4355-afc2-0224116f6375",
                            ConcurrencyStamp = "c8ba0f72-b9f3-4321-8ebb-18c511db7902",
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

            modelBuilder.Entity("ExamPortal.Data.ActivetedExams.ActivatedExam", b =>
                {
                    b.HasOne("ExamPortal.Data.Answers.ExamAnswers", "ExamAnswers")
                        .WithOne("ActivatedExams")
                        .HasForeignKey("ExamPortal.Data.ActivetedExams.ActivatedExam", "ExamAnswersId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExamPortal.Data.ExamData.Exam", "Exam")
                        .WithMany("ActivatedExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExamPortal.Data.Users.User", "User")
                        .WithMany("ActivatedExams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("ExamAnswers");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.Answers", b =>
                {
                    b.HasOne("ExamPortal.Data.Answers.TaskAnswers", "TaskAnswers")
                        .WithOne("Answers")
                        .HasForeignKey("ExamPortal.Data.Answers.Answers", "TaskAnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskAnswers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.AnswersValue", b =>
                {
                    b.HasOne("ExamPortal.Data.Answers.Answers", "Answers")
                        .WithMany("AnswersValue")
                        .HasForeignKey("AnswersValueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Answers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.ExamAnswers", b =>
                {
                    b.HasOne("ExamPortal.Data.Answers.SessionAnswers", "SessionAnswers")
                        .WithMany("ExamAnswers")
                        .HasForeignKey("SessionAnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SessionAnswers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.TaskAnswers", b =>
                {
                    b.HasOne("ExamPortal.Data.Answers.ExamAnswers", "ExamAnswers")
                        .WithMany()
                        .HasForeignKey("ExamAnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamPortal.Data.Answers.ExamAnswers", null)
                        .WithMany("TaskAnswers")
                        .HasForeignKey("TaskAnswers");

                    b.Navigation("ExamAnswers");
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
                    b.HasOne("ExamPortal.Data.Answers.SessionAnswers", null)
                        .WithMany("Exam")
                        .HasForeignKey("SessionAnswersId");

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

            modelBuilder.Entity("ExamPortal.Data.Answers.Answers", b =>
                {
                    b.Navigation("AnswersValue");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.ExamAnswers", b =>
                {
                    b.Navigation("ActivatedExams");

                    b.Navigation("TaskAnswers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.SessionAnswers", b =>
                {
                    b.Navigation("Exam");

                    b.Navigation("ExamAnswers");
                });

            modelBuilder.Entity("ExamPortal.Data.Answers.TaskAnswers", b =>
                {
                    b.Navigation("Answers");
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
