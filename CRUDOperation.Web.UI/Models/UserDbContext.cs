using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDOperation.Web.UI.Models
{
    public class UserDbContext : DbContext
    {
        //Database instance name
        public UserDbContext() : base("DefaultConnection") { }
        public DbSet<Movie> MovieDB { get; set; }
    }
}