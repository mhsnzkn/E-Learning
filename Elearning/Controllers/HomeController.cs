using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Elearning.Models;
using Elearning.Models.Dto;
using Elearning.Utility;
using Elearning.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Elearning.Controllers
{
    [ServiceFilter(typeof(CheckSessionFilter))]
    public class HomeController : Controller
    {
        private readonly AppDbContex db;

        public HomeController(AppDbContex db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult SendMail(Mail mail)
        {
            string messageEd =
               "<tr>" +
               "   <td style='font-size: 18px; line-height: 22px; font-family: Arial,Tahoma, Helvetica, sans-serif; color: #555555; font-weight: normal; text-align: left;'>" +
               "       <span style='color: #555555; font-weight: normal;'>" +
               "           <a href='#' style='text-decoration: none; color: #555555; font-weight: normal;'>" +
               "               <span style='color: #0099EF; font-weight: normal;'>Sayın Yetkili!</span>" +
               "           </a>" +
               "       </span>" +
               "   </td>" +
               "</tr>" +
               "<tr><td height='15'></td></tr>" +
               "<tr>" +
               "   <td style='font-size: 13px; line-height: 22px; font-family: Arial,Tahoma, Helvetica, sans-serif; color: #a3a2a2; font-weight: normal; text-align: left;'>" +
               "        <h2>" + mail.name + "</h2> <br><br>" +
               "        E-Mail: <em>" + mail.email + "</em><br><br>" +
               "        Konu: <em>" + mail.subject + "</em><br><br>" +
               "        Mesaj: <em>" + mail.message + "</em><br><br>" +
               "        Tarih: <em>" + DateTime.Now + "</em><br><br>" +
               "        IP: <em>" + HttpContext.Connection.RemoteIpAddress.ToString() + "</em><br><br>" +
               "   </td>" +
               "</tr>";

            //MailClient.sendEmail(SD.default_smtp_from, "", "harun.er@bilimselbilisim.com", "İletişim Formu", messageEd);
            MailClient.sendEmail("muhsin.ozkan@bilimselbilisim.com", "", "İletişim Formu", messageEd);

            return Json("Ok");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
