using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.Dto
{
    public class LectureDetailDto
    {
        public int Id { get; set; }
        public int UserCourseId { get; set; }
        public int? Row { get; set; }
        public string Type { get; set; }
        public int? TypeId { get; set; }
        public bool Done { get; set; }
    }
}
