using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusBooking.Models;

namespace BusBooking.Controllers
{
    public class BusesController : ApiController
    {
        private UserContext db = new UserContext();
        public List<Bus> buses = new List<Bus>();

        // GET: api/Buses
        public IQueryable<Bus> GetBuses()
        {
            return db.Buses;
        }

        // GET: api/Buses/5
        [ResponseType(typeof(Bus))]
        public IHttpActionResult GetBus(int id)
        {
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return NotFound();
            }

            return Ok(bus);
        }
        //Get: api/Buses?Routeapi=
        //public IHttpActionResult GetBusbyRoute(string Routeid)
        //{
        //    //Bus bus = db.Buses.FirstOrDefault(m => m.RouteID.ToString().Contains(Routeid)).ToList();
        //    foreach(var item in db.Buses.Where(m => m.RouteID.ToString().Contains(Routeid)))
        //    { 

        //        return Ok(item);
        //    }
            
        //    return NotFound();
            

        //}
        //public Bus[] GetBusbyRoute(string Routeid)
        //{
        //    //Bus bus = db.Buses.FirstOrDefault(m => m.RouteID.ToString().Contains(Routeid)).ToList();
        //    var query = from a in db.Buses select a;
        //    query.Where(a => a.RouteID.ToString().Contains(Routeid));
        //    Bus[] buses = query.ToArray<Bus>();

        //    return buses;


        //}

        // PUT: api/Buses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBus(int id, Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bus.BusId)
            {
                return BadRequest();
            }

            db.Entry(bus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Buses
        [ResponseType(typeof(Bus))]
        public IHttpActionResult PostBus(Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Buses.Add(bus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bus.BusId }, bus);
        }

        // DELETE: api/Buses/5
        [ResponseType(typeof(Bus))]
        public IHttpActionResult DeleteBus(int id)
        {
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return NotFound();
            }

            db.Buses.Remove(bus);
            db.SaveChanges();

            return Ok(bus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusExists(int id)
        {
            return db.Buses.Count(e => e.BusId == id) > 0;
        }
    }
}