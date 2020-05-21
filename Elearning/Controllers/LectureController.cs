using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class LectureController : Controller
    {
        private readonly AppDbContex db;
        private readonly IDataRepository repo;

        public LectureController(AppDbContex db, IDataRepository repo)
        {
            this.db = db;
            this.repo = repo;
        }
        public async Task<IActionResult> Index(int id)
        {
            var model = await db.UserCourseDetails.Include(a => a.Lecture).ThenInclude(a => a.LectureDetails).Include(a => a.Lecture)
                .ThenInclude(a => a.Instructor).FirstOrDefaultAsync(a => a.Id == id);
           
            return View(model);
        }

        public async Task<IActionResult> Detail(int id, int uscor, int row, string way)
        {
            //id usercoursedetailid
            int userid = HttpContext.Session.GetInt32("userid").Value;

            var usercoursedetlist = await db.LectureDetailDtos.FromSql("select ucd.Id,ld.Row,UserCourseId,Type,TypeId,Done from UserCourseDetails ucd " +
                    "join LectureDetails ld on ucd.LectureId = ld.LectureId where ucd.Id=@id and ucd.userId=@userid order by row",
                    new SqlParameter("id", id), new SqlParameter("userid", userid)).ToListAsync();

            bool over = false;
            var usercoursedet = new LectureDetailDto();
            if (string.IsNullOrEmpty(way))
            {
                usercoursedet = usercoursedetlist.FirstOrDefault();
            }
            else
            {
                if (way == "next")
                {
                    if (row != usercoursedetlist.LastOrDefault().Row)
                    {
                        usercoursedet = usercoursedetlist.Where(a => a.Row > row).FirstOrDefault();
                    }
                    else
                    {
                        if (!usercoursedetlist.FirstOrDefault().Done)
                        {
                            var usercourse = await db.UserCourseDetails.FindAsync(id);
                            usercourse.Done = true;
                            await db.SaveChangesAsync();
                        }


                        over = true;
                    }
                }
                else if (way == "prev")
                {
                    if (row != usercoursedetlist.FirstOrDefault().Row)
                    {
                        usercoursedet = usercoursedetlist.OrderByDescending(a => a.Row).Where(a => a.Row < row).FirstOrDefault();
                    }
                    else
                    {
                        usercoursedet = usercoursedetlist.FirstOrDefault();
                    }
                }

            }

            if (usercoursedet == null || over)
            {
                return RedirectToAction("Detail", "MyCourse", new { id = usercoursedetlist.FirstOrDefault().UserCourseId });
            }


            if (usercoursedet.Type == SD.Video)
            {
                var videoVM = new VideoViewModel()
                {
                    UserCourseDetail = usercoursedet,
                    Video = await db.Videos.Where(a => a.Id == usercoursedet.TypeId).Select(a => new Video { Path = a.Path }).FirstOrDefaultAsync(),
                    Userid=userid
                };
                return base.View("Video", videoVM);
            };
            if (usercoursedet.Type == SD.Poll || usercoursedet.Type == SD.Pretest)
            {
                var pollVM = new PollViewModel()
                {
                    UserCourseDetail = usercoursedet,
                    Question = await db.Questions.Where(a => a.Id == usercoursedet.TypeId).Include(a => a.QuestionChoices)
                    .Select(a => new Question { Text = a.Text, QuestionChoices = a.QuestionChoices.Select(r => new QuestionChoice { Id = r.Id, Text = r.Text }).ToList() }).FirstOrDefaultAsync(),
                    Userid=userid
                };

                return base.View("Poll", pollVM);
            }
            if (usercoursedet.Type == SD.Aftertest)
            {
                var pollVM = new PollViewModel()
                {
                    UserCourseDetail = usercoursedet,
                    Question = await db.Questions.Where(a => a.Id == usercoursedet.TypeId).Include(a => a.QuestionChoices)
                    .Select(a => new Question { Text = a.Text, QuestionChoices = a.QuestionChoices.Select(r => new QuestionChoice { Id = r.Id, Text = r.Text }).ToList() }).FirstOrDefaultAsync(),
                    Userid=userid
                };

                return base.View("Aftertest", pollVM);
            }
            if (usercoursedet.Type == SD.Quiz)
            {
                return base.View("Quiz", usercoursedet);
            }
            if (usercoursedet.Type == SD.Presentation)
            {
                return base.View("Presentation", usercoursedet);
            }

            return View();
        }


        }
}