﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class UserCourse : ICrtModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool IsAll { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<UserCourseDetail> UserCoursesDetail { get; set; }
    }
}
