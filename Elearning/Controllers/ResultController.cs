using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearning.Data;
using Elearning.Models;
using Elearning.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Drawing.Imaging;
using Elearning.Utility;
using Microsoft.AspNetCore.Http;

namespace Elearning.Controllers
{
    [ServiceFilter(typeof(CheckSessionFilter))]
    public class ResultController : Controller
    {
        private readonly AppDbContex db;
        private readonly IHostingEnvironment env;
        private readonly IDataRepository repo;

        public ResultController(AppDbContex db,IHostingEnvironment env,IDataRepository repo)
        {
            this.db = db;
            this.env = env;
            this.repo = repo;
        }
        public async Task<IActionResult> Index(int id)
        {
            int userid = HttpContext.Session.GetInt32("userid").Value;
            var usercourseid = id;
            var resVM = new ResultIndexViewModel();

            //--------  UserExamResult oluşturma--------
            //sınav sonucuna göre sertifikayı oluşturacak eğer sınav sonucu yok sertifika var ise sertifikayı tekrar oluşturur.
            //sınav sonucu silinecekse sertifika da silinmeli...
            var curuserresult = await db.UserExamResults.FirstOrDefaultAsync(a => a.UserId == userid && a.UserCourseId == usercourseid);
            if (curuserresult == null)
            {
                var model = db.UserQuestionChoices.Include(a => a.QuestionChoice).Where(a => a.UserCourseId == id && a.UserId == userid && a.Type == SD.Poll).ToList();
                resVM.all = model.Count();
                resVM.correct = model.Count(a => a.QuestionChoice.IsCorrect);
                resVM.UserCourseId = usercourseid;

                var userresult = new UserExamResult()
                {
                    UserId = userid,
                    UserCourseId = usercourseid,
                    TotalQuestion=resVM.all,
                    TotalCorrect=resVM.correct,
                    Score = resVM.percentage
                };
                Method.CrtFill(userresult, userid, DateTime.Now, HttpContext.Connection.RemoteIpAddress.ToString());

                var uscourse = await db.UserCourses.Include(a => a.Course).FirstOrDefaultAsync(a => a.Id == id);
                if (resVM.percentage > uscourse.Course.SuccessRate)
                {
                    userresult.Success=resVM.Success = true;
                    var filepath = env.WebRootPath;
                    var certpath = "";
                    var certno = usercourseid + "-" + uscourse.CourseId;
                    var user = await repo.GetUserbyId(userid).Select(a=>new User
                    {
                        Name=a.Name,
                        Surname=a.Surname,
                        TcNo=a.TcNo
                    }).FirstOrDefaultAsync();
                    using (Bitmap b = new Bitmap(filepath + uscourse.Course.CertificatePath.Replace('/', '\\'))) //load the image file
                    {
                        using (Graphics g = Graphics.FromImage(b))
                        {

                            StringFormat nameFormat = new StringFormat();
                            nameFormat.Alignment = StringAlignment.Near;
                            Font nameFont = new Font("sans serif", 37);

                            Font textFont = new Font("sans serif", 41);

                            g.DrawString("Adı Soyadı", textFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(508, 1448, b.Width - 10, b.Height - 10), nameFormat);
                            g.DrawString(":", textFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(895, 1448, b.Width - 10, b.Height - 10), nameFormat);
                            g.DrawString(user.Name + " " + user.Surname, nameFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(968, 1448, b.Width - 10, b.Height - 10), nameFormat);

                            g.DrawString("Tarih", textFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(508, 1537, b.Width - 10, b.Height - 10), nameFormat);
                            g.DrawString(":", textFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(895, 1537, b.Width - 10, b.Height - 10), nameFormat);
                            g.DrawString((DateTime.Now.ToString("dd.MM.yyyy")), nameFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(968, 1537, b.Width - 10, b.Height - 10), nameFormat);

                            g.DrawString("T.C. Kimlik No ", textFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(508, 1625, b.Width - 10, b.Height - 10), nameFormat);
                            g.DrawString(":", textFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(895, 1625, b.Width - 10, b.Height - 10), nameFormat);
                            g.DrawString(user.TcNo, nameFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(968, 1625, b.Width - 10, b.Height - 10), nameFormat);

                            g.DrawString("Sertifika No", textFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(508, 1713, b.Width - 10, b.Height - 10), nameFormat);
                            g.DrawString(":", textFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(895, 1713, b.Width - 10, b.Height - 10), nameFormat);
                            g.DrawString(certno, nameFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(968, 1713, b.Width - 10, b.Height - 10), nameFormat);



                            //StringFormat stringFormat = new StringFormat();
                            //stringFormat.Alignment = StringAlignment.Near;
                            //Font stringFont = new Font("sans serif", 20);
                            //g.DrawString("Bu başarı belgesini web sitemizden sorgulayarak bilgileri teyit edebilirsiniz.", stringFont, new SolidBrush(Color.FromArgb(60, 35, 19)), new RectangleF(620, 1905, b.Width - 10, b.Height - 10), stringFormat);
                            //g.DrawString("kaduzem.org", stringFont, new SolidBrush(Color.FromArgb(0, 36, 255)), new RectangleF(620, 1945, b.Width - 10, b.Height - 10), stringFormat);

                        }
                        //usercourseid unique olduğu için 
                        certpath = "\\files\\user_certificates\\" + certno + ".png";

                        using (MemoryStream memory = new MemoryStream())
                        {
                            var a = filepath + certpath;
                            using (FileStream fs = new FileStream(a, FileMode.Create))
                            {
                                b.Save(memory, ImageFormat.Png);
                                byte[] bytes = memory.ToArray();
                                fs.Write(bytes, 0, bytes.Length);
                            }
                        }

                    }
                    var usercert = new UserCertificate()
                    {
                        UserId = userid,
                        UserCourseId = usercourseid,
                        Active = true,
                        Path = certpath
                    };
                    Method.CrtFill(usercert, userid, DateTime.Now, HttpContext.Connection.RemoteIpAddress.ToString());
                    curuserresult = userresult;
                    db.Add(usercert);
                }
                else
                {
                    userresult.Success=resVM.Success = false;
                }

                db.Add(userresult);
                await db.SaveChangesAsync();
            }
            else
            {
                resVM.all = curuserresult.TotalQuestion;
                resVM.correct = curuserresult.TotalCorrect;
                resVM.UserCourseId = usercourseid;
                resVM.Success = curuserresult.Success;

            }

            return View(resVM);
        }

        public async Task<IActionResult> Certificate(int id)
        {
            int userid = HttpContext.Session.GetInt32("userid").Value;

            var cert = await db.UserCertificates.FirstOrDefaultAsync(a => a.UserId == userid && a.UserCourseId == id);

            return View(cert);
        }
    }
}