using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public interface ICrtModel
    {
        int CrtUsr { get; set; }
        DateTime CrtDate { get; set; }
        string CrtHost { get; set; }
    }
}
