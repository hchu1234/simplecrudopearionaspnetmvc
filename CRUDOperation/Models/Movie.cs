using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDOperation.Models
{
    public class Movie
    {
        #region Prtoperty Initilize
        private UserDbContext db = new UserDbContext();
        #endregion

        #region Constructor

        #endregion

        #region Propery
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "ErrMsgName", ErrorMessageResourceType = typeof(CRUDOperation.Common.Message.Movie.Resource))]
        [StringLength(50, ErrorMessageResourceName = "ErrMsgNameMaxLength", ErrorMessageResourceType = typeof(CRUDOperation.Common.Message.Movie.Resource))]
        [Display(Name = "LblName", ResourceType = typeof(CRUDOperation.Common.Message.Movie.Resource))]
        [RegularExpression(CRUDOperation.Common.Constants.Validation.Expressions.HtmlTag, ErrorMessageResourceName = "ErrMsgNameInvalidChars", ErrorMessageResourceType = typeof(CRUDOperation.Common.Message.Movie.Resource))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "ErrMsgDate", ErrorMessageResourceType = typeof(CRUDOperation.Common.Message.Movie.Resource))]
        public DateTime  DateOfRelease { get; set; }
        public string Poster { get; set; }

        #endregion

        #region Method
        /// <summary>
        /// Get the list of movie 
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetList()
        {
            return db.MovieDB.ToList();
        }
        /// <summary>
        /// Get Movie By Id
        /// </summary>
        /// <param name="id">Movie Id</param>
        public Movie GetMovieById(int? id)
        {
            Movie movieObj = db.MovieDB.Where(x => x.Id == id).FirstOrDefault();
            return movieObj;
        }
        /// <summary>
        /// Delete movie by Id
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns></returns>
        public bool DeleteMovie(int? id)
        {
            bool flag = false;
            Movie movieObj = db.MovieDB.Where(x => x.Id == id).FirstOrDefault();
            if (movieObj != null)
            {
                db.MovieDB.Remove(movieObj);
                db.SaveChanges();
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// Save or Update movie 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public bool SaveMovie(Movie movie)
        {
            bool flag = false;

            if (movie.Id != 0)
            {
                //if id not equal to zero then update/edit that data
                db.MovieDB.Attach(movie);
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                flag = true;
            }
            else
            {
                //if id equal to zero than add the record
                db.MovieDB.Add(movie);
                db.SaveChanges();
                flag = true;
            }
            return flag;
        }
        #endregion
    }
}