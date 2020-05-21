using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class UserType
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string TypeName { get; set; }
        public bool Active { get; set; }
    }
}
