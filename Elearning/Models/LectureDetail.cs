using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class LectureDetail : ICrtModel
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        [MaxLength(10)]
        public string Type { get; set; }
        public int TypeId { get; set; }
        public int Row { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}
