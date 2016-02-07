using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AIS.Models;

namespace AIS.Controllers
{
    public class BlogController : Controller
    {
        private AIS_Entities db = new AIS_Entities();

        // GET: Blog
        public ActionResult Index()
        {
            IEnumerable <get_Posts_Result> results = db.get_Posts();
            return View(results);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<get_Post_ByID_Result> record = db.get_Post_ByID(id);
            get_Post_ByID_Result result = record.FirstOrDefault(blog => blog.Id == id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
