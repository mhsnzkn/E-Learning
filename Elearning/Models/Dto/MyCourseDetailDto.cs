using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.Dto
{
    public class MyCourseDetailDto
    {
        public int UserCourseId { get; set; }
        public string CourseTitle { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Whatwilllearn { get; set; }
        public string Requirements { get; set; }
        public string Whosfor { get; set; }
        public IEnumerable<MyCourseDetailLectureGroupDto> LectureGroups { get; set; }
        public int AllLectureCount => LectureGroups.Sum(s => s.AllLect);
        public int DoneLectureCount => LectureGroups.Sum(s => s.DoneLect);
        public string CompletionRate => ((decimal)DoneLectureCount * 100 / AllLectureCount).ToString("#,00");
        public int OnLectureId { get; set; }
        public int FirstLectureId { get; set; }
        public int lastLectureId { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
