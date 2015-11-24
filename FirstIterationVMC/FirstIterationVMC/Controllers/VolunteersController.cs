using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstIterationVMC.Models;
using System.Data.Entity.Migrations;

//internal sealed class Configuration : DbMigrationsConfiguration<FirstIterationVMC.Models.VolunteerDbContext>
//{
//    public Configuration()
//    {
//        AutomaticMigrationsEnabled = false;
//    }

//    protected override void Seed(FirstIterationVMC.Models.VolunteerDbContext context)
//    {
//        //  This method will be called after migrating to the latest version.

//        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
//        //  to avoid creating duplicate seed data. E.g.
//        //
//        context.Volunteer.AddOrUpdate(i => i.ID,
//            new Volunteer
//            {
//                ID = 1,
//                FName = "Nadiia",
//                LName = "Semenchuk",
//                DOB = DateTime.Parse("01/01/1987"),
//                phone = "(904)786-6767",
//                Email = "ahig@gmail.com",
//                Address = "10789 Nice Street",
//                City = "Jacksonville",
//                State = "FL",
//                Zip = "32225",
//                Specialty = "Nurse"
//            },
//            new Volunteer
//            {
//                ID = 2,
//                FName = "Marie",
//                LName = "Davis",
//                DOB = DateTime.Parse("04/06/1978"),
//                phone = "(904)789-5634",
//                Email = "yuioigh67@gmail.com",
//                Address = "908 Another Street",
//                City = "Jacksonville",
//                State = "FL",
//                Zip = "32225",
//                Specialty = "Pediatrics"
//            },
//            new Volunteer
//            {
//                ID = 3,
//                FName = "Jack",
//                LName = "London",
//                DOB = DateTime.Parse("01/01/1969"),
//                phone = "(904)678-4589",
//                Email = "yuiogvhj@gmail.com",
//                Address = "Atlantic Blvd N",
//                City = "Jacksonville",
//                State = "FL",
//                Zip = "32225",
//                Specialty = "Primary Care"
//            },
//            new Volunteer
//            {
//                ID = 4,
//                FName = "Gabriella",
//                LName = "Malada",
//                DOB = DateTime.Parse("12/07/1967"),
//                phone = "(904)789-5667",
//                Email = "yuirfbgfhk@gmail.com",
//                Address = "10789 Nice Street",
//                City = "Jacksonville",
//                State = "FL",
//                Zip = "32225",
//                Specialty = "Nurse"
//            }
//            );
//    }
//}

namespace FirstIterationVMC.Controllers
{
    public class VolunteersController : Controller
    {
        private VolunteerDbContext db = new VolunteerDbContext();

        // GET: Volunteers
        //public ActionResult Index()
        //{
        //    return View(db.Volunteer.ToList());
        //}


        public ActionResult Index(string volSpecialty, string searchString)
        {
            var SpecList = new List<string>();
            var SpecQry = from d in db.Volunteer
                          orderby d.Specialty
                          select d.Specialty;
            SpecList.AddRange(SpecQry.Distinct());
            ViewBag.volSpecialty = new SelectList(SpecList);

            var volunteers = from v in db.Volunteer
                             select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                volunteers = volunteers.Where(s => s.LName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(volSpecialty))
            {
                volunteers = volunteers.Where(x => x.Specialty == volSpecialty);
            }

            return View(volunteers);
        }


        // GET: Volunteers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteer.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // GET: Volunteers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ID,FName,LName,DOB,phone,Email,Address,City,State,Zip,Specialty")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Volunteer.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volunteer);
        }

        // GET: Volunteers/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteer.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "ID,FName,LName,DOB,phone,Email,Address,City,State,Zip,Specialty")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }

        // GET: Volunteers/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteer.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteer = db.Volunteer.Find(id);
            db.Volunteer.Remove(volunteer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Profiles()
        {
            return View();
        }
    }
}

