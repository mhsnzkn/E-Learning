using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class UserCourseDetail : ICrtModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int UserCourseId { get; set; }
        public int UserId { get; set; }
        public int LectureId { get; set; }
        public int LectureGroupId { get; set; }
        public int Row { get; set; }
        public bool Done { get; set; } = false;
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public virtual LectureGroup LectureGroup { get; set; }
        public virtual Course Course { get; set; }
        public virtual UserCourse UserCourse { get; set; }
        public virtual User User { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}
