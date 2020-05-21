using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.ViewModel
{
    public class ResultIndexViewModel
    {
        public int correct { get; set; }
        public int all { get; set; }
        public int wrong => all - correct;
        public int percentage => (int)Math.Ceiling(correct * 100M / all);
        public int UserCourseId { get; set; }
        public bool Success { get; set; }
    }
}
