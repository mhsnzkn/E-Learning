using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class UserExamResult : ICrtModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserCourseId { get; set; }
        public float Score { get; set; }
        public int TotalQuestion { get; set; }
        public int TotalCorrect { get; set; }
        public bool Success { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public virtual User User { get; set; }
        public virtual UserCourse UserCourse { get; set; }
    }
}
