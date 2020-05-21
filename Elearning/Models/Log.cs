using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [MaxLength(50)]
        public string ActionType { get; set; }
        [MaxLength(100)]
        public string SessionKey { get; set; }
        public bool SessionActive { get; set; }
        public int NetworkId { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(100)]
        public string CrtHost { get; set; }
    }
}
