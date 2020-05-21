using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class Article : ICrtModel
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        public string Text { get; set; }
        [MaxLength(150)]
        public string Author { get; set; }
        public int CrtUsr { get; set ; }
        public DateTime CrtDate { get; set; }
        public string CrtHost { get; set; }
    }
}
