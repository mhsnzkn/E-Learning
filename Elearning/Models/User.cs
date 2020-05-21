using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Models
{
    public class User :ICrtModel
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string UserName { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(60)]
        public string Surname { get; set; }
        [StringLength(11,MinimumLength =11,ErrorMessage ="Tc No 11 hane olmalı")]
        public string TcNo { get; set; }
        [MaxLength(200)]
        public string Institute { get; set; }
        [MaxLength(60)]
        public string Job { get; set; }
        [Required(ErrorMessage = "Telefon adı boş bırakılamaz")]
        [MaxLength(30)]
        public string Phone { get; set; }
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Adres yetersiz!")]
        public string Address { get; set; }
        public int UserTypeId { get; set; }
        public bool UserStatus { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Active { get; set; }
        public bool PasswordChanged { get; set; }
        public int CrtUsr { get; set; }
        public DateTime CrtDate { get; set; }
        [MaxLength(30)]
        public string CrtHost { get; set; }
        public int? UptUsr { get; set; }
        public DateTime? UptDate { get; set; }
        [MaxLength(30)]
        public string UptHost { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
