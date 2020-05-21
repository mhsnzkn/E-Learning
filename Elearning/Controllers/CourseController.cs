using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearning.Data;
using Elearning.Models;
using Elearning.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearning.Controllers
{
    [ServiceFilter(typeof(CheckSessionFilter))]
    public class CourseController : Controller
    {
        private readonly AppDbContex db;

        public CourseController(AppDbContex db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index(string search, string filter, int? pg)
        {
            if (search != null)
            {
                pg = 1;
            }
            else
            {
                search = filter;
            }

            ViewData["filter"] = search;

            var courses = from a in db.Courses
                          where a.Active
                          select new Course
                          {
                              Id = a.Id,
                              Title = a.Title,
                              PreviewPath = a.PreviewPath,
                              Publisher = a.Publisher,
                              Price=a.Price
                          };
            if (!string.IsNullOrEmpty(search))
                courses = courses.Where(a => a.Title.Contains(search) || a.Publisher.Contains(search));


            int pageSize = 9;
            return View(await PaginatedList<Course>.CreateAsync(courses.AsNoTracking(), pg ?? 1, pageSize));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var course = await db.Courses.Where(a=>a.Id==id).Include(a => a.LectureGroups).Include(a => a.Lectures).FirstOrDefaultAsync();
            return View(course);
        }
        public async Task<IActionResult> LectureDetail(int id)
        {
            var lecture = await db.Lectures.Include(a => a.Instructor).FirstOrDefaultAsync(a => a.Id == id);
            return View(lecture);
        }

        public async Task<IActionResult> Buy(int id,int comp)
        {
            var date = DateTime.Now;
            var userid = HttpContext.Session.GetInt32("userid").Value;
            var usercourse = new UserCourse()
            {
                UserId = userid,
                CourseId = id,
                DateBegin = date,
                IsAll = true
            };
            Method.CrtFill(usercourse, userid, date, HttpContext.Connection.RemoteIpAddress.ToString());

            if (comp != 0)
                usercourse.DateEnd = date.AddDays(comp);

            db.Add(usercourse);
             
            var lectures =await db.Lectures.Where(a => a.CourseId == id && a.Active).Select(a=>new {Id=a.Id,Row=a.Row,lectureGroupId=a.LectureGroupId }).ToListAsync();
            foreach (var item in lectures)
            {
                var lecturetoadd = new UserCourseDetail()
                {
                    CourseId = id,
                    UserCourseId = usercourse.Id,
                    LectureGroupId=item.lectureGroupId,
                    UserId = userid,
                    LectureId = item.Id,
                    DateBegin=usercourse.DateBegin,
                    DateEnd=usercourse.DateEnd,
                    Row=item.Row,
                    Done = false
                };

                Method.CrtFill(lecturetoadd, userid, date, HttpContext.Connection.RemoteIpAddress.ToString());

                db.Add(lecturetoadd);
            }

            
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Mycourse");
        }
    }
}