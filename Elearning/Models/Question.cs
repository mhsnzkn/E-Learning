using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class Question : ICrtModel
    {
        public int Id { get; set; }
        [MaxLength(3000)]
        public string Text { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [MaxLength(10)]
        public string Type { get; set; }
        public bool Active { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }

        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; }
    }
}
