using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.Dto
{
    public class MyCourseDetailLecturesDto
    {
        public int LectureId { get; set; }
        public string LectureTitile { get; set; }
        public int LectureRow { get; set; }
        public bool Done { get; set; }
        public int UserCourseDetailId { get; set; }
        public bool IsRequired { get; set; }
    }
}
