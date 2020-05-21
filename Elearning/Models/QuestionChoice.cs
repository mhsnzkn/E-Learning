using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class QuestionChoice : ICrtModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int Row { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public virtual Question Question { get; set; }
    }
}
