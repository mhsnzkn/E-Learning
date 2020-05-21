using Elearning.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.ViewModel
{
    public class VideoViewModel
    {
        public LectureDetailDto UserCourseDetail { get; set; }
        public Video Video { get; set; }
        public int Userid { get; set; }
    }
}
