using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Utility
{
    public static class SD
    {
        //Lecture types
        public const string Poll = "poll";
        public const string Quiz = "quiz";
        public const string Pretest = "pretest";
        public const string Aftertest = "aftertest";
        public const string Video = "video";
        public const string Presentation = "presentation";


        
        public static string HOSTURL = "http://www.kaduzem.org";
        public static string FROMMAIL = "kaduzem@kaduzem.org";
        public static string corresponding_mail = "cevik_ibrahim@hotmail.com,harun.er@bilimselbilisim.com";
        public static string tel = "(0312) 232 01 26";
        public static string adress = "Bükreş Sok. No:3/18 Kavaklıdere/ANKARA";
        //Mail
        public static string Mail = "akcigersagligi@gmail.com";
        public static string SenderName = "Kaduzem";
        public static string MailServer = "mail.kaduzem.org";
        public static string MailPass = "7818Tihud31";


        //Roles
        public enum Roles
        {
            User=1,
            Admin=2,
            Editor=3
        };

    }
}
