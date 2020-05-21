using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models.Dto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Şifre Boş bırakılamaz")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
