using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.Dto
{
    public class MyCourseDetailLectureGroupDto
    {
        public int LectureGroupId { get; set; }
        public string LectureGroupTitle { get; set; }
        public int LectureGroupRow { get; set; }
        public IEnumerable<MyCourseDetailLecturesDto> Lectures { get; set; }
        public int AllLect => Lectures.Where(a=>!a.IsRequired).Count();
        public int DoneLect => Lectures.Where(a => a.Done && !a.IsRequired).Count();
    }
}
