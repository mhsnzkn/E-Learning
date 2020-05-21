using Elearning.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.ViewModel
{
    public class PollViewModel
    {
        public Question Question { get; set; }
        public LectureDetailDto UserCourseDetail { get; set; }
        public int Userid { get; set; }
    }
}
