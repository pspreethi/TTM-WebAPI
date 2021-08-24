using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BusBooking.Models;

namespace BusBooking.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("MyConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<Route> Routes { get; set; }
        public System.Data.Entity.DbSet<Bus> Buses { get; set; }
        public System.Data.Entity.DbSet<Admin> Admins { get; set; }
        public System.Data.Entity.DbSet<Booking> Bookings { get; set; }


    }
}