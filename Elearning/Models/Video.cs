using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class Video : ICrtModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Speaker { get; set; }
        [MaxLength(500)]
        public string Path { get; set; }
        public bool Active { get; set; } = true;
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
    }
}
