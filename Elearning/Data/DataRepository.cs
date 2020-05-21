using Elearning.Models;
using Elearning.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly AppDbContex db;

        public DataRepository(AppDbContex db)
        {
            this.db = db;
        }
        public void Add<T>(T entity) where T : class
        {
            db.Add(entity);
        }

        public UserQuestionChoice AddUserQuestionChoice(int userid, int questionid, int questionchoiceid, int usercourseid,int usercoursedetailid,string type)
        {
            var userchoice = new UserQuestionChoice()
            {
                UserId = userid,
                QuestionId = questionid,
                QuestionChoiceId = questionchoiceid,
                UserCourseId = usercourseid,
                UserCourseDetailId=usercoursedetailid,
                Type=type,
                CrtUsr = userid,
                CrtDate = DateTime.Now,
                CrtHost = "::1"
            };
            db.Add(userchoice);
            return userchoice;
        }
        public async Task<UserLogin> GetUserLoginbyId(int id, string password)
        {
            var userid = await db.Users.Where(a => a.Id == id && a.Password == password).Include(a=>a.UserType).Select(a=>new UserLogin { Id= a.Id,Role=a.UserType.TypeName,Active=a.Active }).FirstOrDefaultAsync();
            return userid;
        }

        public void Delete<T>(T entity) where T : class
        {
            db.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            db.Update(entity);
        }

        public async Task<UserCourseDetail> DoneLecture(int usercoursedetailid)
        {
            var usercoursedetail =await db.UserCourseDetails.FindAsync(usercoursedetailid);
            usercoursedetail.Done = true;
            return usercoursedetail;
        }

        public async Task<int> GetUserCountbyUserName(string username)
        {
            return await db.Users.CountAsync(a => a.UserName == username);
        }
        public IQueryable<User> GetUserbyUserName(string username)
        {
            return db.Users.Where(a => a.UserName == username);
        }
        public IQueryable<User> GetUserbyId(int id)
        {
            return db.Users.Where(a => a.Id == id);
        }
        //public async Task<LectureIndexDto> GetLectureIndex(int usercoursedetailid, int userid)
        //{
        //    return await db.UserCourseDetails.Include(a => a.Lecture).Where(a => a.Id == usercoursedetailid && a.UserId == userid)
        //            .Select(a => new LectureIndexDto
        //            {
        //                Id = a.Id,
        //                Title = a.Lecture.Title,
        //                Row = a.Row,
        //                UserCourseId = a.UserCourseId,
        //                Type = a.Lecture.Type,
        //                TypeId = a.Lecture.TypeId,
        //                Done = a.Done
        //            }).FirstOrDefaultAsync();
        //}

        //public async Task<LectureIndexDto> GetLectureIndexNext(int usercourseid, int row, int userid)
        //{
        //    return await db.UserCourseDetails.Include(a => a.Lecture).OrderBy(a => a.Row).Where(a => a.UserCourseId == usercourseid && a.Row > row && a.UserId == userid)
        //                .Select(a => new LectureIndexDto
        //                {
        //                    Id = a.Id,
        //                    Title = a.Lecture.Title,
        //                    Row = a.Row,
        //                    UserCourseId = a.UserCourseId,
        //                    Type = a.Lecture.Type,
        //                    TypeId = a.Lecture.TypeId,
        //                    Done = a.Done
        //                }).FirstOrDefaultAsync();
        //}

        //public async Task<LectureIndexDto> GetLectureIndexPrev(int usercourseid, int row, int userid)
        //{
        //    return await db.UserCourseDetails.OrderByDescending(a => a.Row).Where(a => a.UserCourseId == usercourseid && a.Row < row && a.UserId == userid).Include(a => a.Lecture)
        //                .Select(a => new LectureIndexDto
        //                {
        //                    Id = a.Id,
        //                    Title = a.Lecture.Title,
        //                    Row = a.Row,
        //                    UserCourseId = a.UserCourseId,
        //                    Type = a.Lecture.Type,
        //                    TypeId = a.Lecture.TypeId,
        //                    Done = a.Done
        //                }).FirstOrDefaultAsync();
        //}

        public IQueryable<MyCourseIndexDto> GetUserCoursesbyUserid(int userid)
        {
            var param = new SqlParameter("userid", userid);
            var query = db.MyCourseIndexDtos.FromSql("SELECT uc.Id,PreviewPath,Title,Publisher,(select count(*) from UserCourseDetails where UserCourseId=uc.Id) as AllLect,(select count(*) from UserCourseDetails where UserCourseId=uc.Id and Done=1) as DoneLect "+
                        "FROM UserCourses uc join Courses c on uc.CourseId = c.Id where UserId = @userid and (uc.DateEnd>GETDATE() or uc.DateEnd is null) and c.Active=1", param);

            return query;
        }

        public async Task<bool> SaveAll()
        {
            return await db.SaveChangesAsync() > 0;
        }

        public IQueryable<Course> GetCoursesQuery()
        {
            return from a in db.Courses select a;
        }
        public async Task<UserLogin> GetUserLogin(string username,string password)
        {
            return await db.Users.Where(a => a.UserName == username && a.Password == password).Include(a => a.UserType).Select(a => new UserLogin { Id = a.Id, Active = a.Active, Role = a.UserType.TypeName }).FirstOrDefaultAsync();
        }
    }
}
