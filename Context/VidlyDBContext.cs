using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using VidlyMVC.Models;

namespace VidlyMVC.Context
{
    public class VidlyDBContext : DbContext
    {
        public VidlyDBContext()
        {

        }

        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<Movie> Movies { get; set; } // My domain models
        public DbSet<Genre> Genres { get; set; } // My domain models
        public DbSet<MembershipType> MembershipTypes { get; set; } // My domain models


    }
}