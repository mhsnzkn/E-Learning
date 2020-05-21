using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class Instructor : ICrtModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(60)]
        public string Institution { get; set; }
        public string PreviewPath { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public int? UptUsr { get; set; }
        public DateTime? UptDate { get; set; }
        [MaxLength(30)]
        public string UptHost { get; set; }
    }
}
