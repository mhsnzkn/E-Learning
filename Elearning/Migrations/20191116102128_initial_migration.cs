using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elearning.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommonFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 30, nullable: true),
                    Path = table.Column<string>(maxLength: 300, nullable: true),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true),
                    UptUsr = table.Column<int>(nullable: true),
                    UptDate = table.Column<DateTime>(nullable: true),
                    UptHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Job = table.Column<string>(maxLength: 30, nullable: true),
                    FatherName = table.Column<string>(maxLength: 30, nullable: true),
                    MotherName = table.Column<string>(maxLength: 30, nullable: true),
                    IdNo = table.Column<string>(maxLength: 11, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Institude = table.Column<string>(maxLength: 300, nullable: true),
                    Department = table.Column<string>(maxLength: 300, nullable: true),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true),
                    UptUsr = table.Column<int>(nullable: true),
                    UptDate = table.Column<DateTime>(nullable: true),
                    UptHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 3000, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Type = table.Column<string>(maxLength: 10, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(maxLength: 30, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Speaker = table.Column<string>(maxLength: 100, nullable: true),
                    Path = table.Column<string>(maxLength: 500, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NetworkId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Publisher = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WhatWillLearn = table.Column<string>(maxLength: 1000, nullable: true),
                    Requirements = table.Column<string>(maxLength: 1000, nullable: true),
                    WhosFor = table.Column<string>(maxLength: 1000, nullable: true),
                    CertificateId = table.Column<int>(nullable: false),
                    PreviewId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true),
                    UptUsr = table.Column<int>(nullable: true),
                    UptDate = table.Column<DateTime>(nullable: true),
                    UptHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CommonFiles_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "CommonFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Courses_Networks_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Networks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_CommonFiles_PreviewId",
                        column: x => x.PreviewId,
                        principalTable: "CommonFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuestionChoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 1000, nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionChoices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 200, nullable: true),
                    Password = table.Column<string>(maxLength: 30, nullable: true),
                    Title = table.Column<string>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Surname = table.Column<string>(maxLength: 60, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    Phone = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 300, nullable: true),
                    UserTypeId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    UserStatus = table.Column<bool>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PasswordChanged = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true),
                    UptUsr = table.Column<int>(nullable: true),
                    UptDate = table.Column<DateTime>(nullable: true),
                    UptHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LectureGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LectureGroups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    DateBegin = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    IsAll = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNetworks",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    NetworkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNetworks", x => new { x.UserId, x.NetworkId });
                    table.ForeignKey(
                        name: "FK_UserNetworks_Networks_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Networks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserNetworks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    LectureGroupId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Row = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lectures_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lectures_LectureGroups_LectureGroupId",
                        column: x => x.LectureGroupId,
                        principalTable: "LectureGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UserCourseId = table.Column<int>(nullable: false),
                    CommonfileId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCertificates_CommonFiles_CommonfileId",
                        column: x => x.CommonfileId,
                        principalTable: "CommonFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserCertificates_UserCourses_UserCourseId",
                        column: x => x.UserCourseId,
                        principalTable: "UserCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserCertificates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExamResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UserCourseId = table.Column<int>(nullable: false),
                    Score = table.Column<float>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExamResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExamResults_UserCourses_UserCourseId",
                        column: x => x.UserCourseId,
                        principalTable: "UserCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserExamResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestionChoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionChoiceId = table.Column<int>(nullable: false),
                    UserCourseId = table.Column<int>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestionChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuestionChoices_QuestionChoices_QuestionChoiceId",
                        column: x => x.QuestionChoiceId,
                        principalTable: "QuestionChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserQuestionChoices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserQuestionChoices_UserCourses_UserCourseId",
                        column: x => x.UserCourseId,
                        principalTable: "UserCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserQuestionChoices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LectureId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 10, nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LectureDetails_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    UserCourseId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LectureId = table.Column<int>(nullable: false),
                    Done = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourseDetails_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserCourseDetails_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserCourseDetails_UserCourses_UserCourseId",
                        column: x => x.UserCourseId,
                        principalTable: "UserCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourseDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CertificateId",
                table: "Courses",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_NetworkId",
                table: "Courses",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PreviewId",
                table: "Courses",
                column: "PreviewId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureDetails_LectureId",
                table: "LectureDetails",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureGroups_CourseId",
                table: "LectureGroups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_InstructorId",
                table: "Lectures",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_LectureGroupId",
                table: "Lectures",
                column: "LectureGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoices_QuestionId",
                table: "QuestionChoices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificates_CommonfileId",
                table: "UserCertificates",
                column: "CommonfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificates_UserCourseId",
                table: "UserCertificates",
                column: "UserCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificates_UserId",
                table: "UserCertificates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseDetails_CourseId",
                table: "UserCourseDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseDetails_LectureId",
                table: "UserCourseDetails",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseDetails_UserCourseId",
                table: "UserCourseDetails",
                column: "UserCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseDetails_UserId",
                table: "UserCourseDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExamResults_UserCourseId",
                table: "UserExamResults",
                column: "UserCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExamResults_UserId",
                table: "UserExamResults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNetworks_NetworkId",
                table: "UserNetworks",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionChoices_QuestionChoiceId",
                table: "UserQuestionChoices",
                column: "QuestionChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionChoices_QuestionId",
                table: "UserQuestionChoices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionChoices_UserCourseId",
                table: "UserQuestionChoices",
                column: "UserCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionChoices_UserId",
                table: "UserQuestionChoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MemberId",
                table: "Users",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureDetails");

            migrationBuilder.DropTable(
                name: "UserCertificates");

            migrationBuilder.DropTable(
                name: "UserCourseDetails");

            migrationBuilder.DropTable(
                name: "UserExamResults");

            migrationBuilder.DropTable(
                name: "UserNetworks");

            migrationBuilder.DropTable(
                name: "UserQuestionChoices");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "QuestionChoices");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "LectureGroups");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "CommonFiles");

            migrationBuilder.DropTable(
                name: "Networks");
        }
    }
}
