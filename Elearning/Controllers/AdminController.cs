using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Elearning.Data;
using Elearning.Models;
using Elearning.Models.ViewModel;
using Elearning.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Elearning.Controllers
{
    [ServiceFilter(typeof(AdminSessionFilter))]
    public class AdminController : Controller
    {
        private readonly AppDbContex db;
        private readonly IDataRepository repo;
        private readonly IHostingEnvironment hostenv;

        public AdminController(AppDbContex db,IDataRepository repo,IHostingEnvironment hostenv)
        {
            this.db = db;
            this.repo = repo;
            this.hostenv = hostenv;
        }
        public async Task<IActionResult> Index(string search, string filter, int? pg)
        {
            var courses = repo.GetCoursesQuery().Select(a=> new Course
            {
                Id=a.Id,
                Title=a.Title,
                Publisher=a.Publisher,
                Price=a.Price
            });

            if (search != null)
            {
                pg = 1;
            }
            else
            {
                search = filter;
            }
            ViewData["filter"] = search;

            if (!string.IsNullOrEmpty(search))
                courses = courses.Where(a => a.Title.Contains(search) || a.Publisher.Contains(search));

            int pageSize = 9;

            return View(await PaginatedList<Course>.CreateAsync(courses.AsNoTracking(), pg ?? 1, pageSize));
        }
        public IActionResult AddCourse()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course,IFormFile certificate, IFormFile certificate2, IFormFile preview)
        {
            if (!string.IsNullOrEmpty(course.Title))
            {
                Method.CrtFill(course, HttpContext.Session.GetInt32("userid") ?? 1, DateTime.Now, HttpContext.Connection.RemoteIpAddress.ToString());

                course.CertificatePath = Method.Upload(hostenv.WebRootPath, "\\files\\certificates\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + Path.GetFileName(certificate?.FileName), preview);
                course.Certificate2Path = Method.Upload(hostenv.WebRootPath, "\\files\\certificates\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + Path.GetFileName(certificate2?.FileName), preview);
                course.PreviewPath = Method.Upload(hostenv.WebRootPath, "\\files\\previews\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + Path.GetFileName(preview?.FileName), preview); ;

                repo.Add(course);
                await repo.SaveAll();
                return RedirectToAction("AddLectureGroup", new { courseid = course.Id });
            }

            return View();
        }

        public async Task<ActionResult> EditCourse(int id)
        {
            var course = await db.Courses.FindAsync(id);
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> EditCourse(Course course, IFormFile certificate, IFormFile certificate2, IFormFile preview)
        {
            if (!string.IsNullOrEmpty(course.Title))
            {
                if (certificate != null)
                    course.CertificatePath = Method.Upload(hostenv.WebRootPath, "\\files\\certificates\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + Path.GetFileName(certificate?.FileName), preview);
                if (certificate2!=null)
                    course.Certificate2Path = Method.Upload(hostenv.WebRootPath, "\\files\\certificates\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + Path.GetFileName(certificate2?.FileName), preview);
                if(preview!=null)
                    course.PreviewPath = Method.Upload(hostenv.WebRootPath, "\\files\\previews\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + Path.GetFileName(preview?.FileName), preview); ;

                course.UptDate = DateTime.Now;
                course.UptHost = HttpContext.Connection.RemoteIpAddress.ToString();
                course.UptUsr = HttpContext.Session.GetInt32("userid") ?? 1;
                repo.Update(course);
                await repo.SaveAll();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddLectureGroup(int courseid)
        {
            ViewData["courseid"] = courseid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddLectureGroup(IFormCollection fc)
        {
            var a = Convert.ToInt16(fc["counter"]);
            var userid= HttpContext.Session.GetInt32("userid") ?? 1;
            var date = DateTime.Now;
            var host = HttpContext.Connection.RemoteIpAddress.ToString();
            var courseid = Convert.ToInt32(fc["courseid_0"]);

            for (int i = 0; i <= a; i++)
            {
                var lect_group = new LectureGroup()
                {
                    Active = Convert.ToBoolean(fc["active_" + i]),
                    CourseId = courseid,
                    Row = Convert.ToInt32(fc["row_" + i]),
                    Title = fc["title_" + i].ToString()
                };
                Method.CrtFill(lect_group,userid,date,host);

                if(!string.IsNullOrEmpty(lect_group.Title))
                    repo.Add(lect_group);
            }
            await repo.SaveAll();
            return RedirectToAction("AddLecture", new { courseid = courseid });
        }
        public async Task<IActionResult> EditLectureGroup(int id)
        {
            var lgrouplist = await db.LectureGroups.Where(a => a.CourseId == id).ToListAsync();
            return View(lgrouplist);
        }
        [HttpPost]
        public async Task<IActionResult> EditLectureGroup(LectureGroup lgroup)
        {
            if (!string.IsNullOrEmpty(HttpContext.Request.Form["Active"].ToString()))
                lgroup.Active = true;
            else
                lgroup.Active = false;

            var msg = 0;
            try
            {
                repo.Update(lgroup);
                await repo.SaveAll();
                msg = 1;
            }
            catch
            {
                msg = 2;
            }
            return Ok(msg);
        }
        public async Task<IActionResult> AddLecture(int courseid,int upt)
        {
            ViewData["courseid"] = courseid;
            var model = new AddLectureViewModel()
            {
                LectureGroups = await db.LectureGroups.Where(a => a.CourseId == courseid).Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString() }).ToListAsync(),
                Lecture = new Lecture()
            };
            ViewData["upt"] = upt;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddLecture(Lecture lecture,IFormFile preview)
        {
            int upt = 0;
            try
            {
                lecture.Status = true;
                Method.CrtFill(lecture, HttpContext.Session.GetInt32("userid") ?? 1, DateTime.Now, HttpContext.Connection.RemoteIpAddress.ToString());

                lecture.PreviewPath = Method.Upload(hostenv.WebRootPath,
                    "\\files\\previews\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + Path.GetFileName(preview?.FileName),
                    preview);

                repo.Add(lecture);
                if (await repo.SaveAll())
                    upt = 1;
            }
            catch
            {
                upt = 2;
            }

            return Ok(upt);
        }
        public async Task<IActionResult> LectureList(int id)
        {
            var model = await db.Lectures.Where(a => a.CourseId == id).OrderBy(a=>a.Row).ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> EditLecture(int id)
        {
            var model = await db.Lectures.FirstOrDefaultAsync(a => a.Id == id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditLecture(Lecture lecture, IFormFile preview)
        {
            int upt = 0;
            try
            {
                lecture.PreviewPath = Method.Upload(hostenv.WebRootPath,
                    "\\files\\previews\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + Path.GetFileName(preview?.FileName),
                    preview);

                repo.Update(lecture);
                if (await repo.SaveAll())
                    upt = 1;
            }
            catch
            {
                upt = 2;
            }

            return Ok(upt);
        }

        public async Task<IActionResult> AddLectureDetail(int courseid)
        {
            var model = new AddLectureDetailViewModel()
            {
                Lectures = await db.Lectures.Where(a => a.CourseId == courseid).Select(a => new SelectListItem() { Text = a.Title, Value = a.Id.ToString() }).ToListAsync(),
                LectureDetail = new LectureDetail()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddLectureDetail(LectureDetail ldetail)
        {
            int upt = 0;
            try
            {
                Method.CrtFill(ldetail, HttpContext.Session.GetInt32("userid") ?? 1, DateTime.Now, HttpContext.Connection.RemoteIpAddress.ToString());

                repo.Add(ldetail);
                await repo.SaveAll();
            }
            catch
            {
                
            }

            return Ok(ldetail.Id);
        }

        [HttpPost]
        public async Task<IActionResult> EditLectureDetail(LectureDetail ldetail)
        {
            int upt = 0;
            try
            {
                repo.Update(ldetail);
                if (await repo.SaveAll())
                    upt = 1;
            }
            catch
            {
                upt = 2;
            }

            return Ok(upt);
        }
        public async Task<IActionResult> DeleteLectureDetail(int id)
        {
            var msg = 0;
            var ldetail = new LectureDetail() { Id = id };
            try
            {
                db.Attach(ldetail);
                db.Remove(ldetail);
                if (await db.SaveChangesAsync() > 0)
                    msg = 1;
            }
            catch
            {

            }

            return Ok(msg);
        }
        public async Task<IActionResult> LectureDetailList(int id)
        {
            var model=await db.LectureDetails.Where(a => a.LectureId == id).ToListAsync();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Addinstructor(Instructor ins,IFormFile file)
        {
            Method.CrtFill(ins, HttpContext.Session.GetInt32("userid") ?? 1, DateTime.Now, HttpContext.Connection.RemoteIpAddress.ToString());

            ins.PreviewPath=Method.Upload(hostenv.WebRootPath,
                "\\files\\instructors\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + Path.GetFileName(file.FileName),
                file);
           
            repo.Add(ins);
            await repo.SaveAll();
            return Ok(ins.Id);
        }

        [HttpPost]
        public async Task<IActionResult> AddVideo(Video video)
        {
            Method.CrtFill(video, HttpContext.Session.GetInt32("userid") ?? 1, DateTime.Now, HttpContext.Connection.RemoteIpAddress.ToString());
            repo.Add(video);
            await repo.SaveAll();
            return Ok(video.Id);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(IFormCollection fc)
        {
            var userid = HttpContext.Session.GetInt32("userid") ?? 1;
            var date = DateTime.Now;
            var host = HttpContext.Connection.RemoteIpAddress.ToString();

            var question = new Question();
            Method.CrtFill(question, userid, date, host);

            question.Text = fc["Text"].ToString();
            question.Description = fc["Description"].ToString();
            question.Type = "select";
            question.Active = true;
            var counter = Convert.ToInt32(fc["counter"]);
            var correct = Convert.ToInt32(fc["isCorrect"]);
            ICollection<QuestionChoice> clist = new List<QuestionChoice>();
            for (int i = 0; i <= counter; i++)
            {
                var choice = new QuestionChoice()
                {
                    Row = Convert.ToInt32(fc["row_" + i]),
                    Text = fc["text_" + i].ToString(),
                };
                Method.CrtFill(choice,userid,date,host);
                if (i == correct)
                    choice.IsCorrect = true;
                else
                    choice.IsCorrect = false;

                clist.Add(choice);

            }
            question.QuestionChoices = clist;

            repo.Add(question);
            await repo.SaveAll();
            return Ok(question.Id);
        }
    }
}