using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.Dto
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }
    }
}
