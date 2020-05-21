using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class UserNetwork
    {
        public int UserId { get; set; }
        public int NetworkId { get; set; }
        public User User { get; set; }
        public Network Network { get; set; }
    }
}
