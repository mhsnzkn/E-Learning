using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class Lecture : ICrtModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int LectureGroupId { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        [MaxLength(1500)]
        public string Aim { get; set; }
        [MaxLength(1500)]
        public string Content { get; set; }
        public string PreviewPath { get; set; }
        public int Row { get; set; }
        public bool Active { get; set; } = true;
        public bool Status { get; set; } = true;
        public bool IsRequired { get; set; } = false;
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public int? InstructorId { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public virtual Course Course { get; set; }
        public virtual LectureGroup LectureGroup { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<LectureDetail> LectureDetails { get; set; }
    }
}
