using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class VidlyContext : DbContext
    {
        public VidlyContext()
            :base("name=VidlyConnection")
        {
            
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<MembershipType> MembershipType { get; set; }
    }
}