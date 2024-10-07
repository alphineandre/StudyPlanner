using ST10097490_POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ST10097490_POE.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Course()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Course(Course objUser)
        {
            if (Session["UserName"] != null)
            {
                objUser.UserName = Session["UserName"].ToString();
            }
            if (ModelState.IsValid)
            {
                using (MyDBEntities1 db = new MyDBEntities1())
                {
                    if (objUser != null)
                    {
                        db.Courses.Add(objUser);
                        db.SaveChanges();
                        return RedirectToAction("Course", "Course");
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong Password or Username');</script>");
                    }
                }
            }
            return View(objUser);
        }
        private readonly GetCourse _getCourse = new GetCourse();

        public async Task<ViewResult> GetCourse()
        {
            var data = await _getCourse.GetAllCourseInfo();

            return View(data);
        }
    }
}