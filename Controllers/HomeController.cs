using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace concurrentprj.Controllers
{
    public class HomeController : Controller
    {
        private cpEntities db = new cpEntities();
        public ActionResult Chat()
        {
            
            ViewBag.Message = "Your contact page.";

            return View(db.tbl_User.ToList());
        }
       
        //public ActionResult editAdmin(int? id, string name)
        //{


        //    return Json( JsonRequestBehavior.AllowGet);
        //}
        public int editAdmin(string input, int id)
        {
            //char[] arr =input.ToCharArray();
            //Array.Reverse(arr);

            var user = db.tbl_User.Find(id);
            var frnd = db.tbl_User.Where(p=>p.UserName.Equals(input)).FirstOrDefault();

            frnd.AdminCode = user.AdminCode;
            db.Entry(frnd).State = EntityState.Modified;
            db.SaveChanges();
            

          //  return new string(arr);
            return id;
        }
        public ActionResult Index()
        {
            return View();
        }

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
    }
}