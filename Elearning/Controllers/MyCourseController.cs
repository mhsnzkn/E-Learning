using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearning.Data;
using Elearning.Models;
using Elearning.Models.Dto;
using Elearning.Models.ViewModel;
using Elearning.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearning.Controllers
{
    [ServiceFilter(typeof(CheckSessionFilter))]
    public class MyCourseController : Controller
    {
        private readonly AppDbContex db;
        private readonly IDataRepository repo;

        public MyCourseController(AppDbContex db,IDataRepository repo)
        {
            this.db = db;
            this.repo = repo;
        }
        public async Task<IActionResult> Index(string search, string filter, int? pg)
        {
            int userid = HttpContext.Session.GetInt32("userid").Value;
            if (search != null)
            {
                pg = 1;
            }
            else
            {
                search = filter;
            }
            ViewData["filter"] = search;

            var mycourses = repo.GetUserCoursesbyUserid(userid);

            if (!string.IsNullOrEmpty(search))
                mycourses = mycourses.Where(a => a.Title.Contains(search) || a.Publisher.Contains(search));

            int pageSize = 9;
            return View(await PaginatedList<MyCourseIndexDto>.CreateAsync(mycourses.AsNoTracking(), pg ?? 1, pageSize));
        }
        public async Task<IActionResult> Detail(int id)
        {
            var userid = HttpContext.Session.GetInt32("userid");
            var date = DateTime.Now;
            var usercourse =await db.UserCourses.Where(a => a.Id == id && a.UserId==userid && (a.DateEnd>date || a.DateEnd==null)).Include(a => a.Course).ThenInclude(a => a.LectureGroups)
                .Include(a => a.UserCoursesDetail).ThenInclude(a => a.Lecture)
                .Select(a => new MyCourseDetailDto
                {
                    UserCourseId=a.Id,
                    CourseTitle = a.Course.Title,
                    Publisher = a.Course.Publisher,
                    Description = a.Course.Description,
                    Whatwilllearn = a.Course.WhatWillLearn,
                    Requirements = a.Course.Requirements,
                    Whosfor = a.Course.WhosFor,
                    EndDate=a.DateEnd,
                    LectureGroups = a.Course.LectureGroups.Where(q=>q.CourseId==a.CourseId).Select(s => new MyCourseDetailLectureGroupDto
                    {
                        LectureGroupId = s.Id,
                        LectureGroupRow = s.Row,
                        LectureGroupTitle = s.Title,
                        Lectures = s.Lectures.Select(f => new MyCourseDetailLecturesDto { LectureId = f.Id,UserCourseDetailId= a.UserCoursesDetail.FirstOrDefault(g => g.LectureId == f.Id).Id, LectureRow = f.Row, LectureTitile = f.Title,IsRequired= f.IsRequired, Done = a.UserCoursesDetail.FirstOrDefault(g=>g.LectureId==f.Id).Done })
                    })
                }).FirstOrDefaultAsync();

            if (usercourse == null)
                return RedirectToAction("Index");

            var lecturelist = usercourse.LectureGroups.SelectMany(a => a.Lectures);
            
            usercourse.lastLectureId = lecturelist.OrderByDescending(a => a.LectureRow).Select(a => a.UserCourseDetailId).FirstOrDefault();
            usercourse.FirstLectureId = lecturelist.OrderBy(a => a.LectureRow).Select(a => a.UserCourseDetailId).FirstOrDefault();

            if (lecturelist.All(a => a.Done))
            {
                usercourse.OnLectureId = 0;
            }
            else
            {
                usercourse.OnLectureId = lecturelist.OrderBy(a => a.LectureRow).FirstOrDefault(a => a.Done == false).UserCourseDetailId;
            }
            
            return View(usercourse);
        }
    }
}