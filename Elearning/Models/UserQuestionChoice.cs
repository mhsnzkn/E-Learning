using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class UserQuestionChoice : ICrtModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionChoiceId { get; set; }
        public int UserCourseId { get; set; }
        public int UserCourseDetailId { get; set; }
        [MaxLength(10)]
        public string Type { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public virtual User User { get; set; }
        public virtual Question Question { get; set; }
        public virtual QuestionChoice QuestionChoice { get; set; }
        public virtual UserCourse UserCourse { get; set; }
        public virtual UserCourseDetail UserCourseDetail { get; set; }
    }
}
