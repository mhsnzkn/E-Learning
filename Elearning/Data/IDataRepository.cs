using Elearning.Models;
using Elearning.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Data
{
    public interface IDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<UserCourseDetail> DoneLecture(int usercoursedetailid);
        UserQuestionChoice AddUserQuestionChoice(int userid, int questionid, int questionchoiceid, int usercourseid,int usercoursedetailid, string type);
        IQueryable<MyCourseIndexDto> GetUserCoursesbyUserid(int userid);
        Task<UserLogin> GetUserLoginbyId(int id, string password);
        Task<int> GetUserCountbyUserName(string username);
        IQueryable<User> GetUserbyUserName(string username);
        IQueryable<User> GetUserbyId(int id);
        IQueryable<Course> GetCoursesQuery();
        Task<UserLogin> GetUserLogin(string username, string password);
        //Task<LectureIndexDto> GetLectureIndexNext(int usercourseid, int row, int userid);
        //Task<LectureIndexDto> GetLectureIndexPrev(int usercourseid, int row, int userid);
        //Task<LectureIndexDto> GetLectureIndex(int usercoursedetailid,int userid);
    }
}
