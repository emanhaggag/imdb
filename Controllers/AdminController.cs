using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using imdb.Models;

namespace imdb.Controllers
{
    public class AdminController : Controller
    {

        private Cmodel db = new Cmodel();
        // GET: Admin
        public ActionResult Index()
        {
            Session["Userid"] = "0";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string username = form["Usename"].ToString();
            string password = form["Password"].ToString();

            if(username == "admin" && password =="admin"){
                Session["Userid"] = "-1";
            }
            return RedirectToAction("AdminActions","Admin");
        }

        public ActionResult AdminActions()
        {
            if (Session["Userid"] == "0" )
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        public ActionResult Addmovie()
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null || Session["Userid"] != "-1")
            {
                return RedirectToAction("Index", "Admin");
            }
            return View(db.directors.ToList());
        }
         

        [HttpPost]
        public ActionResult Addmovie(FormCollection form , HttpPostedFileBase photo)
        {
            movie movie = new movie();

            movie.name = form["name"].ToString();
            movie.description = form["description"].ToString();


            HttpPostedFileBase postedFile = Request.Files["photo"];
            if (postedFile != null ){
                string path = Server.MapPath("~/movie/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
            }

            movie.director = db.directors.Find(Convert.ToInt32(form["director"]));
            movie.id_director = Convert.ToInt32(form["director"]);
            movie.photo = "/movie/" + Path.GetFileName(postedFile.FileName);
            db.movies.Add(movie);
            
            db.SaveChanges();
            return RedirectToAction("AllMovie");
        }

        public ActionResult AddActor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddActor(FormCollection form , HttpPostedFileBase photo)
        {
            string name = form["name"].ToString();
            HttpPostedFileBase postedFile = Request.Files["photo"];
            
            actor actor = new actor();

            if (postedFile != null)
            {
                string path = Server.MapPath("~/Actor/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
            }
            actor.name = name;
            actor.photo = "/Actor/" + Path.GetFileName(postedFile.FileName);
            db.actors.Add(actor);
            db.SaveChanges();
            return View();
        }

        public ActionResult Adddirector()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Adddirector(FormCollection form, HttpPostedFileBase photo)
        {
            string name = form["name"].ToString();
            HttpPostedFileBase postedFile = Request.Files["photo"];
            director director = new director();
            if (postedFile != null)
            {
                string path = Server.MapPath("~/director/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
            }
            director.name = name;
            director.photo = "/director/" + Path.GetFileName(postedFile.FileName);
            db.directors.Add(director);
            db.SaveChanges();
            return View();
        }

        public ActionResult AllMovie()
        {
            return View(db.movies.ToList());
        }

        public ActionResult Alldirectors()
        {
            return View(db.directors.ToList());
        }

        
        public ActionResult AllActor()
        {
            return View(db.actors.ToList());
        }
    }
}