using Elearning.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Utility
{
    public static class Method
    {
        public static bool CheckSession(this HttpContext context)
        {
            if (context.Session.GetInt32("userid")!=null && context.Session.GetInt32("userid")!=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GenerateString(int length)
        {
            var rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        public static string Upload(string webrootpath,string path, IFormFile file)
        {
            if (file != null)
            {
                using (var filestream = new FileStream(webrootpath + path, FileMode.Create))
                {
                    file.CopyTo(filestream);
                }

                return path.Replace("\\","/");
            }
            else
                return null;
        }
        public static void CrtFill(ICrtModel model,int userid,DateTime date,string host)
        {
            model.CrtDate = date;
            model.CrtHost = host;
            model.CrtUsr = userid;
        }
    }
}
