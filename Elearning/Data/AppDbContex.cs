using Elearning.Models;
using Elearning.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Data
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) :base (options) 
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CommonFile> CommonFiles { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureDetail> LectureDetails { get; set; }
        public DbSet<LectureGroup> LectureGroups { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionChoice> QuestionChoices { get; set; }
        public DbSet<UserCertificate> UserCertificates { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<UserCourseDetail> UserCourseDetails { get; set; }
        public DbSet<UserExamResult> UserExamResults { get; set; }
        public DbSet<UserNetwork> UserNetworks { get; set; }
        public DbSet<UserQuestionChoice> UserQuestionChoices { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Log> Logs { get; set; }
        //public DbSet<Article> Articles { get; set; }



        public DbQuery<LectureDetailDto> LectureDetailDtos { get; set; }
        public DbQuery<MyCourseIndexDto> MyCourseIndexDtos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserNetwork>()
                .HasKey(a => new { a.UserId, a.NetworkId });


        }
    }
}
