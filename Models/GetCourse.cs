using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ST10097490_POE.Models
{
    public class GetCourse
    {
        public async Task<List<CourseInfo>> GetAllCourseInfo()
        {
            MyDBEntities1 db = new MyDBEntities1();

            var courseInfos = new List<CourseInfo>();
            var allCourse = await db.Courses.ToListAsync();
            if (allCourse != null)
            {
                foreach (var course in allCourse)
                {
                    courseInfos.Add(new CourseInfo()
                    { courseName = course.CourseName, courseCode = course.CourseCode, numberOfCredit = course.Credit, numberOfClassHoursPerWeek = course.ClassHoursPerWeek, numberOfWeeks = course.NumberOfWeeks, startDate = course.StartDate, endDate = course.EndDate });
                }
            }
            return courseInfos;
        }
    }
}