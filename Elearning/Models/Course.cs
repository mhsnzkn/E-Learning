using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class Course : ICrtModel
    {
        public int Id { get; set; }
        public int? NetworkId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Publisher { get; set; }
        public string Description { get; set; }
        [MaxLength(1000)]
        public string WhatWillLearn { get; set; }
        [MaxLength(1000)]
        public string Requirements { get; set; }
        [MaxLength(1000)]
        public string WhosFor { get; set; }
        public string CertificatePath { get; set; }
        public string Certificate2Path { get; set; }
        public string PreviewPath { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public int? CompletionDay { get; set; }
        public int SuccessRate { get; set; }
        public bool Active { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public int? UptUsr { get; set; }
        public DateTime? UptDate { get; set; }
        [MaxLength(30)]
        public string UptHost { get; set; }
        public virtual Network Network { get; set; }
        public virtual ICollection<LectureGroup> LectureGroups { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
