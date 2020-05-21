using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class Network : ICrtModel
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool Active { get; set; } = true;
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
    }
}
