namespace BusBooking.Migrations
{
    using BusBooking.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BusBooking.Models.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BusBooking.Models.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //context.Users.AddOrUpdate(x => x.ID,
            //   new User()
            //   {
            //       FirstName = "RandomUser",
            //       LastName = "1",
            //       Age = 20,
            //       Email = "RandomUser1@gmail.com",
            //       Mobile = 9876534567,
            //       Gender = "M",
            //       Password = "randomuser1"
            //   });
            //context.Routes.AddOrUpdate(x => x.RouteID,
            //   new Route()
            //   {
            //       RouteID = 101,
            //       Start = "Hyderabad",
            //       End = "Bangalore"
            //   });
            //context.Buses.AddOrUpdate(x => x.BusId,
            //   new Bus()
            //   {
            //       BusId = 201,
            //       BusName = "TMS Travels",
            //       Time = "8:30",
            //       Fare = 1000,
            //       Seats = 40,
            //       RouteID = 101,

            //   });
            context.Bookings.AddOrUpdate(x => x.BookingID,
               new Booking()
               {
                   BookingID = 1,
                   Start = "Hyderabad",
                   End = "Bangalore",
                   Date = "2021-06-24",
                   Seat = "01",
                   BusID = 1,
                   Email = "xyz@gmail.com"


               });

        }
    }
}
