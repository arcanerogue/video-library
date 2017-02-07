using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VideoLibrary.Models;


namespace VideoLibrary.Controllers
{
    public class HomeController : Controller
    {
        private VideoDbSet _db;

        public HomeController()
        {
            _db = new VideoDbSet();
        }
        
        public ActionResult Index()
        {
            // Populate Director drop-down list
            var directorQuery = _db.Videos.OrderBy(d => d.Director)
                                         .Select(d =>d.Director)
                                         .Distinct();

            ViewBag.Director = new SelectList(directorQuery);

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}