using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.Dto
{
    public class MyCourseIndexDto
    {
        public int Id { get; set; }
        public string PreviewPath { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int DoneLect { get; set; }
        public int AllLect { get; set; }
        public string CompletionRate => ((decimal)DoneLect * 100 / AllLect).ToString("#,0");
    }
}
