using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.Dto
{
    public class AddLectureandDoneDto
    {
        public int usercoursedetailid { get; set; }
        public int userid { get; set; }
        public int questionid { get; set; }
        public int questionchoiceid { get; set; }
        public int usercourseid { get; set; }
        public string type { get; set; }
        public int lectureid { get; set; }
    }
}
