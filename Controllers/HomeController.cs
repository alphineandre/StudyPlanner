using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ST10097490_POE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Login objUser)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var EncodePassword = Encoding.ASCII.GetBytes(objUser.Password);
            var sha1data = sha1.ComputeHash(EncodePassword);
            var hashedPassword = ASCIIEncoding.ASCII.GetString(sha1data);
            objUser.Password = hashedPassword;

            if (ModelState.IsValid)
            {
                using (MyDBEntities1 db = new MyDBEntities1())
                {
                    if (objUser != null)
                    {
                        db.Logins.Add(objUser);
                        db.SaveChanges();
                        return RedirectToAction("Login", "Home");
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Login objUser)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var DecodePassword = UnicodeEncoding.ASCII.GetBytes(objUser.Password);
            var sha1data = sha1.ComputeHash(DecodePassword);
            var hashedPassword = ASCIIEncoding.ASCII.GetString(sha1data);
            objUser.Password = hashedPassword;

            if (ModelState.IsValid)
            {
                using (MyDBEntities1 db = new MyDBEntities1())
                {
                    var obj = db.Logins.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        return RedirectToAction("Course", "Course", obj.Username);
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong Password or Username');</script>");
                    }
                }
            }
            return View(objUser);
        }
    }
}