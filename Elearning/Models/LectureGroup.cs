using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class LectureGroup : ICrtModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int Row { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        public bool Active { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<UserCourseDetail> UserCourseDetail { get; set; }

    }
}
