using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheConnoisseur.Models;

namespace TheConnoisseur.Controllers
{
    public class CoffeesController : Controller
    {
        private TheConnoisseurContext db = new TheConnoisseurContext();

        private SelectList GetPrivacyList(int? current)
        {
            SelectList s1;
            if (current != null)
            {
                 s1 = new SelectList(db.Privacies.OrderBy(p => p.PType), "PrivacyID", "PType", 1);
                 return s1;        
            }
            s1 = new SelectList(db.Privacies.OrderBy(p => p.PType), "PrivacyID", "PType", current);
            return s1;
        }
        // GET: Coffees
        public ActionResult Index()
        {
            return View(db.Coffees.ToList());
        }

        // GET: Coffees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // GET: Coffees/Create
        public ActionResult Create()
        {
            ViewBag.PrivacyList = GetPrivacyList(null);
            return View();
        }

        // POST: Coffees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoffeeID,JournalID,RoastType,Origin,FoodPairing,Maker,Title,Rating,Description,Location")] CoffeeViewModel cvm, int PrivacyList)
        { 
            if (ModelState.IsValid)
            {
                // Create journal object and add to database
                Journal j = new Journal()
                {
                    AuthorID = 1,   // TODO: use Identity to set this property
                    Date = DateTime.Now,
                    Description = cvm.Description,
                    JType = cvm.JType,
                    Location = cvm.Location,
                    Maker = cvm.Maker,
                    PrivacyType = PrivacyList,
                    Rating = cvm.Rating,
                    Title = cvm.Title,
                };
                db.Journals.Add(j);
                db.SaveChanges();

                // Create pairing coffee objecgt and add to database
                Coffee c = new Coffee()
                {
                    FoodPairing = cvm.FoodPairing,
                    JournalID = j.JournalID,
                    Origin = cvm.Origin,
                    RoastType = cvm.RoastType
                };

                db.Coffees.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");   // TODO: make sure this link to appropriate page. Consider the user's profile.
            }

            return View(cvm);
        }

        // GET: Coffees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            Journal journal = db.Journals.Find(coffee.JournalID);
            if (journal == null)
            {
                return HttpNotFound();
            }
            // Journal record exists, make ViewModel and pass to edit view
            CoffeeViewModel cvm = new CoffeeViewModel()
            {
                AuthorID = journal.AuthorID,
                Date = journal.Date,
                Description = journal.Description,
                ImagePath = journal.ImagePath,
                Location = journal.Location,
                Maker = journal.Maker,
                Rating = journal.Rating,
                Title = journal.Title,
                CoffeeID = coffee.CoffeeID,
                FoodPairing = coffee.FoodPairing,
                Origin = coffee.Origin,
                RoastType = coffee.RoastType
            };
            // Set dropdownlist to preselected privacy type.
            ViewBag.PrivacyList = GetPrivacyList(journal.PrivacyType);
            return View(coffee);
        }

        // POST: Coffees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoffeeID,JournalID,RoastType,Origin,FoodPairing")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffee);
        }

        // GET: Coffees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: Coffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coffee coffee = db.Coffees.Find(id);
            db.Coffees.Remove(coffee);
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
    }
}
