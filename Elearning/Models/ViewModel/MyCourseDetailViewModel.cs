using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.ViewModel
{
    public class MyCourseDetailViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<int> DoneLectures { get; set; }
        public int OnLecture { get; set; }
        public string Percentage { get; set; }
    }
}
