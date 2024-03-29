﻿// <auto-generated />
using System;
using Elearning.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Elearning.Migrations
{
    [DbContext(typeof(AppDbContex))]
    [Migration("20191216125656_log added, dateend nullable, usquchoice type")]
    partial class logaddeddateendnullableusquchoicetype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Elearning.Models.CommonFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Extension")
                        .HasMaxLength(5);

                    b.Property<string>("FileName")
                        .HasMaxLength(30);

                    b.Property<string>("Path")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("CommonFiles");
                });

            modelBuilder.Entity("Elearning.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Certificate2Path");

                    b.Property<string>("CertificatePath");

                    b.Property<int?>("CompletionDay");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Description");

                    b.Property<int?>("NetworkId");

                    b.Property<string>("PreviewPath");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Publisher")
                        .HasMaxLength(100);

                    b.Property<string>("Requirements")
                        .HasMaxLength(1000);

                    b.Property<int>("SuccessRate");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UptDate");

                    b.Property<string>("UptHost")
                        .HasMaxLength(30);

                    b.Property<int?>("UptUsr");

                    b.Property<string>("WhatWillLearn")
                        .HasMaxLength(1000);

                    b.Property<string>("WhosFor")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("NetworkId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Elearning.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Description");

                    b.Property<string>("Institution")
                        .HasMaxLength(60);

                    b.Property<string>("Name");

                    b.Property<string>("PreviewPath");

                    b.Property<DateTime?>("UptDate");

                    b.Property<string>("UptHost")
                        .HasMaxLength(30);

                    b.Property<int?>("UptUsr");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Elearning.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Aim")
                        .HasMaxLength(1500);

                    b.Property<string>("Content")
                        .HasMaxLength(1500);

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Description")
                        .HasMaxLength(1500);

                    b.Property<int?>("InstructorId");

                    b.Property<bool>("IsRequired");

                    b.Property<int>("LectureGroupId");

                    b.Property<string>("PreviewPath");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("Row");

                    b.Property<bool>("Status");

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("LectureGroupId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("Elearning.Models.LectureDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<int>("LectureId");

                    b.Property<int>("Row");

                    b.Property<string>("Type")
                        .HasMaxLength(10);

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("LectureDetails");
                });

            modelBuilder.Entity("Elearning.Models.LectureGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<int>("Row");

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("LectureGroups");
                });

            modelBuilder.Entity("Elearning.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionType")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(100);

                    b.Property<int>("NetworkId");

                    b.Property<bool>("SessionActive");

                    b.Property<string>("SessionKey")
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Elearning.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Department")
                        .HasMaxLength(300);

                    b.Property<string>("FatherName")
                        .HasMaxLength(30);

                    b.Property<string>("IdNo")
                        .HasMaxLength(11);

                    b.Property<string>("Institude")
                        .HasMaxLength(300);

                    b.Property<string>("Job")
                        .HasMaxLength(30);

                    b.Property<string>("MotherName")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("UptDate");

                    b.Property<string>("UptHost")
                        .HasMaxLength(30);

                    b.Property<int?>("UptUsr");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Elearning.Models.Network", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Name")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("Elearning.Models.Presentation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<int>("SlideCount");

                    b.Property<string>("Speaker")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Presentations");
                });

            modelBuilder.Entity("Elearning.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Text")
                        .HasMaxLength(3000);

                    b.Property<string>("Type")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Elearning.Models.QuestionChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsCorrect");

                    b.Property<int>("QuestionId");

                    b.Property<int>("Row");

                    b.Property<string>("Text")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionChoices");
                });

            modelBuilder.Entity("Elearning.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Institute")
                        .HasMaxLength(200);

                    b.Property<string>("Job")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("LastLogin");

                    b.Property<int>("MemberId");

                    b.Property<string>("Name")
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("PasswordChanged");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("Surname")
                        .HasMaxLength(60);

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Title")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("UptDate");

                    b.Property<string>("UptHost")
                        .HasMaxLength(30);

                    b.Property<int?>("UptUsr");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("UserStatus");

                    b.Property<int>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Elearning.Models.UserCertificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Path");

                    b.Property<int>("UserCourseId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserCourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCertificates");
                });

            modelBuilder.Entity("Elearning.Models.UserCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<DateTime>("DateBegin");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<bool>("IsAll");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("Elearning.Models.UserCourseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<DateTime>("DateBegin");

                    b.Property<DateTime?>("DateEnd");

                    b.Property<bool>("Done");

                    b.Property<int>("LectureGroupId");

                    b.Property<int>("LectureId");

                    b.Property<int>("Row");

                    b.Property<int>("UserCourseId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("LectureGroupId");

                    b.HasIndex("LectureId");

                    b.HasIndex("UserCourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourseDetails");
                });

            modelBuilder.Entity("Elearning.Models.UserExamResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<float>("Score");

                    b.Property<int>("UserCourseId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserCourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserExamResults");
                });

            modelBuilder.Entity("Elearning.Models.UserNetwork", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("NetworkId");

                    b.HasKey("UserId", "NetworkId");

                    b.HasIndex("NetworkId");

                    b.ToTable("UserNetworks");
                });

            modelBuilder.Entity("Elearning.Models.UserQuestionChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<int>("QuestionChoiceId");

                    b.Property<int>("QuestionId");

                    b.Property<string>("Type")
                        .HasMaxLength(10);

                    b.Property<int>("UserCourseDetailId");

                    b.Property<int>("UserCourseId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionChoiceId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserCourseDetailId");

                    b.HasIndex("UserCourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserQuestionChoices");
                });

            modelBuilder.Entity("Elearning.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("TypeName")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("Elearning.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CrtDate");

                    b.Property<string>("CrtHost")
                        .HasMaxLength(30);

                    b.Property<int>("CrtUsr");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<string>("Path")
                        .HasMaxLength(500);

                    b.Property<string>("Speaker")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Elearning.Models.Course", b =>
                {
                    b.HasOne("Elearning.Models.Network", "Network")
                        .WithMany()
                        .HasForeignKey("NetworkId");
                });

            modelBuilder.Entity("Elearning.Models.Lecture", b =>
                {
                    b.HasOne("Elearning.Models.Course", "Course")
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId");

                    b.HasOne("Elearning.Models.LectureGroup", "LectureGroup")
                        .WithMany("Lectures")
                        .HasForeignKey("LectureGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.LectureDetail", b =>
                {
                    b.HasOne("Elearning.Models.Lecture", "Lecture")
                        .WithMany("LectureDetails")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.LectureGroup", b =>
                {
                    b.HasOne("Elearning.Models.Course", "Course")
                        .WithMany("LectureGroups")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.QuestionChoice", b =>
                {
                    b.HasOne("Elearning.Models.Question", "Question")
                        .WithMany("QuestionChoices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.User", b =>
                {
                    b.HasOne("Elearning.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.UserCertificate", b =>
                {
                    b.HasOne("Elearning.Models.UserCourse", "UserCourse")
                        .WithMany()
                        .HasForeignKey("UserCourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.UserCourse", b =>
                {
                    b.HasOne("Elearning.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.UserCourseDetail", b =>
                {
                    b.HasOne("Elearning.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.LectureGroup", "LectureGroup")
                        .WithMany("UserCourseDetail")
                        .HasForeignKey("LectureGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.Lecture", "Lecture")
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.UserCourse", "UserCourse")
                        .WithMany("UserCoursesDetail")
                        .HasForeignKey("UserCourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.UserExamResult", b =>
                {
                    b.HasOne("Elearning.Models.UserCourse", "UserCourse")
                        .WithMany()
                        .HasForeignKey("UserCourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.UserNetwork", b =>
                {
                    b.HasOne("Elearning.Models.Network", "Network")
                        .WithMany()
                        .HasForeignKey("NetworkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elearning.Models.UserQuestionChoice", b =>
                {
                    b.HasOne("Elearning.Models.QuestionChoice", "QuestionChoice")
                        .WithMany()
                        .HasForeignKey("QuestionChoiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.UserCourseDetail", "UserCourseDetail")
                        .WithMany()
                        .HasForeignKey("UserCourseDetailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.UserCourse", "UserCourse")
                        .WithMany()
                        .HasForeignKey("UserCourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elearning.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
