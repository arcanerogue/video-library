using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VideoLibrary.Models;
using VideoLibrary.ViewModels;

namespace VideoLibrary.Controllers
{
    public class VideosController : Controller
    {

        private VideoDbSet _db;
        
        public VideosController() 
        {
            _db= new VideoDbSet();
        }
    
        // GET: VideoList
        [AllowAnonymous]
        public ActionResult VideoList(SearchCriteria searchValues)
        {
            IQueryable<Video> movies = _db.Videos;

            if (!string.IsNullOrEmpty(searchValues.SearchTitle))
            {
                movies = movies.Where(s => s.Title.Contains(searchValues.SearchTitle));                
            }

            if (!string.IsNullOrEmpty(searchValues.SearchDirector))
            {
                movies = movies.Where(x => x.Director == searchValues.SearchDirector);                
            }

            if (searchValues.SearchYear > 0)
            {
                movies = movies.Where(y => y.Year == searchValues.SearchYear);                
            }

            return View(movies.OrderBy(t => t.Title));
        }

        // GET: VideoList/Details/id
        //[Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = _db.Videos.Find(id);
            
            VideoDetailsViewModel videoDetails = new VideoDetailsViewModel
            {
                VideoId = video.VideoId,
                Title = video.Title,
                Year = video.Year,
                Director = video.Director,
                Reviews = video.Reviews,
                PlotSummary = video.PlotSummary
            };
            
            if (videoDetails == null)
            {
                return HttpNotFound();
            }
            return View(videoDetails);
        }

        //[Authorize]
        public ActionResult Create()
        {

            return View();
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var video = new Video
            {
                Title = model.Title,
                Year = model.Year,
                Director = model.Director,
                FormatCode = model.FormatCode.ToString()                    
            };

            _db.Videos.Add(video);
            _db.SaveChanges();            

            return RedirectToAction("VideoList", "Videos");            
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
