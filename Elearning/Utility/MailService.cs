using Elearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Elearning.Utility
{
    public class MailClient
    {
        public static bool sendEmail(string to, string cc, string subject, string body)
        {
            try
            {
                //Mail Settings
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(SD.Mail, SD.SenderName, Encoding.UTF8);
                mail.To.Add(to.Replace(";", ","));
                if (cc != "" && cc != null)
                {
                    mail.CC.Add(cc.Replace(";", ","));
                }
                
                mail.Bcc.Add("harun.er@bilimselbilisim.com");
                mail.Bcc.Add(SD.Mail);
                


                mail.Subject = subject;
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Body = body;
                mail.Priority = MailPriority.Normal;


                //Client Settings
                SmtpClient client = new SmtpClient();
                NetworkCredential credentials = new NetworkCredential(SD.Mail, SD.MailPass);
                client.Host = SD.MailServer;
                client.Port = 587;
                client.UseDefaultCredentials = true;
                client.Credentials = credentials;

                client.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool sendPasswordMail(User user)
        {
            try
            {
                string message =
                "<tr>" +
                "   <td style='font-size: 18px; line-height: 22px; font-family: Arial,Tahoma, Helvetica, sans-serif; color: #555555; font-weight: normal; text-align: left;'>" +
                "       <span style='color: #555555; font-weight: normal;'>" +
                "           <a href='#' style='text-decoration: none; color: #555555; font-weight: normal;'>" +
                "               <span style='color: #0099EF; font-weight: normal;'>Sayın " + user.Title + " " + user.Name + " " + user.Surname + "</span>" +
                "           </a>" +
                "       </span>" +
                "   </td>" +
                "</tr>" +
                "<tr><td height='15'></td></tr>" +
                "<tr>" +
                "   <td style='font-size: 13px; line-height: 22px; font-family: Arial,Tahoma, Helvetica, sans-serif; color: #a3a2a2; font-weight: normal; text-align: left;'>" +
                "        Şifreniz: " +
                "           <span style='color: #2f9bbe;'>" + user.Password + "</span>" +
                "   </td>" +
                "</tr>" +
                "<tr><td height='15'></td></tr><tr><td style='font-size: 13px; line-height: 22px; font-family: Arial,Tahoma, Helvetica, sans-serif; color: #a3a2a2; font-weight: normal; text-align: left;'><small>ref: " +
                user.Id + "</small></td></tr>";

                //Mail Settings
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(SD.Mail, SD.SenderName, Encoding.UTF8);
                mail.To.Add(user.UserName);
                

                mail.Bcc.Add("harun.er@bilimselbilisim.com");
                mail.Bcc.Add(SD.Mail);



                mail.Subject = "Yeni Şifre";
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Body = message;
                mail.Priority = MailPriority.Normal;


                //Client Settings
                SmtpClient client = new SmtpClient();
                NetworkCredential credentials = new NetworkCredential(SD.Mail, SD.MailPass);
                client.Host = SD.MailServer;
                client.Port = 587;
                client.UseDefaultCredentials = true;
                client.Credentials = credentials;

                client.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
