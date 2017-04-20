using CRUDOperation.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDOperation.Web.UI.Controllers
{
    public class MovieController : Controller
    {
        #region Property
        private UserDbContext db = new UserDbContext();
        #endregion

        #region Action Method
        public ActionResult Index()
        {
            //This is used for change the config connectionstring
            //new WebConfigHelper().UpdateConnectionString("Data Source", ".\\SQLEXPRESS");
            //new WebConfigHelper().UpdateConnectionString("Initial Catalog", "CodeFirstMovieDB");

            List<Movie> lstMovieObj = new List<Movie>();
            try
            {
                lstMovieObj = new Movie().GetList();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Err", ex.Message);
            }
            return View(lstMovieObj);
        }

        [HttpGet]
        public ActionResult Add(int? id)
        {
            Movie movieObj = new Movie();
            try
            {
                if (id != 0)
                {
                    movieObj = new Movie().GetMovieById(id);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Err", ex.Message);
            }
            return View(movieObj);
        }

        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            try
            {


                var file = Request.Files["Poster"];
                if (file != null && file.ContentLength > 0)
                {
                    var content = Server.MapPath("~/Content/");
                    var path = Path.Combine(content, "Img");
                    // Try to create the directory.
                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }

                    var imagePath = Path.Combine(path, file.FileName);
                    var imageUrl = Path.Combine(path, file.FileName);
                    file.SaveAs(imagePath);
                    movie.Poster = file.FileName;
                }


                var save = new Movie().SaveMovie(movie);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Err", ex.Message);
            }
            return View("Add", movie);
        }
        public ActionResult Delete(int? id)
        {
            var movieObj = new Movie().DeleteMovie(id);
            return View("Index", "Movie");
        }
        #endregion
    }
}