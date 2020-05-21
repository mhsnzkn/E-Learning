using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearning.Data;
using Elearning.Models;
using Elearning.Models.Dto;
using Elearning.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly AppDbContex db;
        private readonly IDataRepository repo;

        public ServicesController(AppDbContex db,IDataRepository repo)
        {
            this.db = db;
            this.repo = repo;
        }
        [HttpPost("AddQuestionChoice")]
        public async Task<IActionResult> AddQuestionChoice(AddLectureandDoneDto model)
        {

            if (model.userid > 0 && model.questionid > 0 && model.questionchoiceid > 0 && model.usercourseid > 0)
            {
                var userchoice = await db.UserQuestionChoices
                    .FirstOrDefaultAsync(a => a.UserId == model.userid && a.UserCourseDetailId == model.usercoursedetailid && a.QuestionId==model.questionid);
                if (userchoice==null)
                {
                    
                    repo.AddUserQuestionChoice(model.userid, model.questionid, model.questionchoiceid, model.usercourseid,model.usercoursedetailid,model.type);
                }
                else
                {
                    if (userchoice.QuestionChoiceId!=model.questionchoiceid)
                    {
                        userchoice.QuestionChoiceId = model.questionchoiceid;
                    }
                }

            }


            if (await repo.SaveAll())
                return Ok("1");
            else
                return Ok("0");

        }

        [HttpPost("AddAftertestChoice")]
        public async Task<IActionResult> AddAftertestChoice(AddLectureandDoneDto model)
        {
            var msg = "";
            if (model.userid > 0 && model.questionid > 0 && model.questionchoiceid > 0 && model.usercourseid > 0)
            {
                var userchoice = await db.UserQuestionChoices
                    .FirstOrDefaultAsync(a => a.UserId == model.userid && a.UserCourseDetailId == model.usercoursedetailid && a.QuestionId == model.questionid);
                if (userchoice == null)
                {

                    repo.AddUserQuestionChoice(model.userid, model.questionid, model.questionchoiceid, model.usercourseid, model.usercoursedetailid, model.type);
                }
                else
                {
                    if (userchoice.QuestionChoiceId != model.questionchoiceid)
                    {
                        userchoice.QuestionChoiceId = model.questionchoiceid;
                    }
                }

            }
            await repo.SaveAll();

            var pretestChoice = await db.UserQuestionChoices.Where(a => a.UserId == model.userid && a.UserCourseId == model.usercourseid && a.QuestionId == model.questionid && a.Type==SD.Pretest)
                .Include(a => a.QuestionChoice).Select(a => a.QuestionChoice.Text).FirstOrDefaultAsync();
            msg = !string.IsNullOrEmpty(pretestChoice) ? pretestChoice : "";

            return Ok(msg);

        }

        [HttpGet("GetUserChoice")]
        public async Task<IActionResult> GetUserChoice([FromQuery]AddLectureandDoneDto model)
        {
            var userchoice = await db.UserQuestionChoices.Where(a => a.UserId == model.userid && a.QuestionId == model.questionid && a.UserCourseDetailId==model.usercoursedetailid).Select(a => a.QuestionChoiceId).FirstOrDefaultAsync();

            return Ok(userchoice);
        }
        [HttpGet("GetUserCertificates")]
        public async Task<IActionResult> GetUserCertificates()
        {
            var userid = HttpContext.Session.GetInt32("userid");
            if (userid==null || userid==0)
            {
                return NotFound();
            }

            var usercert = await db.UserCertificates.Include(a=>a.UserCourse).ThenInclude(a=>a.Course).Where(a => a.UserId == userid && a.Active)
                .Select(a=>new {title=a.UserCourse.Course.Title,path=a.Path,id=a.UserCourseId }).ToListAsync();

            return Ok(usercert);
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            var msg = "";
            var userfromdb = await repo.GetUserCountbyUserName(user.UserName);
            if (userfromdb>0)
            {
                msg = "0####Bu e-posta adresi sistemde kayıtlı!";
            }
            else
            {
                user.RegisterDate = user.CrtDate = DateTime.Now;
                user.Active = true;
                user.CrtHost = HttpContext.Connection.RemoteIpAddress.ToString();
                user.Password = Method.GenerateString(6);
                user.UserTypeId = (int)SD.Roles.User;
                repo.Add(user);
                
                if (await repo.SaveAll())
                {
                    MailClient.sendPasswordMail(user);
                    msg = "1####";
                }
                else
                    msg = "0####Bir hata oldu!";
            }
            

            return Ok(msg);
        }
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var userid = HttpContext.Session.GetInt32("userid");
            if (userid == null)
                return Ok("0");

            var dbuser = await db.Users.FindAsync(userid);
            if(dbuser==null)
                return Ok("0");

            dbuser.Address = user.Address;
            dbuser.UserName = user.UserName;
            dbuser.Institute = user.Institute;
            dbuser.Job = user.Job;
            dbuser.Name = user.Name;
            dbuser.Surname = user.Surname;
            dbuser.Phone = user.Phone;
            dbuser.TcNo = user.TcNo;
            dbuser.Title = user.Title;
            dbuser.UptDate = DateTime.Now;
            dbuser.UptUsr = userid;
            dbuser.UptHost = HttpContext.Connection.RemoteIpAddress.ToString();


            if (await db.SaveChangesAsync()>0)
                return Ok("1");
            else
                return Ok("0");
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(UserLoginDto user)
        {
            var userid = HttpContext.Session.GetInt32("userid");
            if (userid == null)
                return Ok("0####İşlem yapabilmek için yeniden giriş yapmanız gerekmektedir.");

            var dbuser = await db.Users.FindAsync(userid);
            if (dbuser == null)
                return Ok("0");
            var msg = "";
            if (dbuser.Password==user.UserName)
            {
                dbuser.Password = user.Password;
                dbuser.UptDate = DateTime.Now;
                dbuser.UptUsr = userid;
                dbuser.UptHost = HttpContext.Connection.RemoteIpAddress.ToString();
                dbuser.PasswordChanged = true;

                if (await db.SaveChangesAsync() > 0)
                    msg="1####";
            }
            else
            {
                msg = "0####Mevcut şifre doğru değil!";
            }
            

           return Ok(msg);
        }

        [HttpPost("passForgot")]
        public async Task<IActionResult> PassForgot(Mail model)
        {
            var msg = "0";
            var user = await repo.GetUserbyUserName(model.email)
                .Select(a => new User { Title = a.Title, Name = a.Name, Surname = a.Surname, Password = a.Password, Id = a.Id, UserName = a.UserName, Active = a.Active })
                .FirstOrDefaultAsync();
            if (user!=null)
            {
                if (!user.Active)
                {
                    msg = "0####Kullanıcınız aktif değil.";
                }
                else
                {
                    var newpass = Method.GenerateString(6);
                    user.Password = newpass;
                    await repo.SaveAll();

                    MailClient.sendPasswordMail(user);
                    msg = "1";
                }
                
            }

            return Ok(msg);
        }
        [HttpGet("GetIns")]
        public async Task<List<InstructorDto>> GetInstructor(string search)
        {
            var ins = from a in db.Instructors select a;
            if (!string.IsNullOrEmpty(search))
                ins = ins.Where(a => a.Name.Contains(search));

            var result =await ins.Select(a => new InstructorDto { Id = a.Id, Name = a.Name }).Take(10).ToListAsync();
            return result;
        }
    }
}