using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class CommonFile
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string FileName { get; set; }
        [MaxLength(300)]
        public string Path { get; set; }
        [MaxLength(5)]
        public string Extension { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
    }
}
