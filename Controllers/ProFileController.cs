using imdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace imdb.Controllers
{
    public class ProFileController : Controller
    {
        private Cmodel db = new Cmodel();
        public ActionResult Index()
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null)
            {
                return RedirectToAction( "Idnex" , "Home" );
            }
            
            int x = Convert.ToInt16(Session["Userid"]);

            return View(db.users.Find(x));
        }
        
        public ActionResult searsh(FormCollection form)
        {
            string name = form["nmovie"].ToString();
            return View(db.movies.Where(m => m.name == name).ToList());
        }
        
        public ActionResult AllMovie()
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null)
            {
                return RedirectToAction("Idnex", "Home");
            }
            return View(db.movies.ToList());
        }
        public ActionResult oneMovie(int? id)
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null)
            {
                return RedirectToAction("Idnex", "Home");
            }
            int idi = Convert.ToInt32(id);
            return View(db.movies.Find(id));
        }

        public ActionResult Alldirectors()
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null)
            {
                return RedirectToAction("Idnex", "Home");
            }
            return View(db.directors.ToList());
        }
        public ActionResult oneDirector(int? id)
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null)
            {
                return RedirectToAction("Idnex", "Home");
            }
            int idi = Convert.ToInt32(id);
            return View(db.directors.Find(idi));
        }
        
        public ActionResult AllActor()
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null)
            {
                return RedirectToAction("Idnex", "Home");
            }
            return View(db.actors.ToList());
        }
        public ActionResult oneActor(int? id)
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null)
            {
                return RedirectToAction("Idnex", "Home");
            }
            int idi = Convert.ToInt32(id);
            return View(db.actors.Find(id));
        }
    }
}