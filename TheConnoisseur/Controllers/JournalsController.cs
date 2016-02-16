using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheConnoisseur.Models;

namespace TheConnoisseur.Views
{
    public class JournalsController : Controller
    {
        private TheConnoisseurContext db = new TheConnoisseurContext();
        
        /* TODO: Implement this function. Currently the 'db.' is giving error
        public static SelectList GetPrivacyList()
        {
            SelectList sl = new SelectList(db.Privacies.OrderBy(s => s.Title), "PrivacyId", "PType");
        }*/

        // GET: Journals
        public ActionResult Index()
        {
            return View(db.Journals.ToList());
        }

        // GET: Journals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Journals.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // GET: Journals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Journals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JournalID,AuthorID,Maker,Title,JType,ImagePath,Rating,Description,Date,Location,PrivacyType")] Journal journal)
        {
            if (ModelState.IsValid)
            {
                db.Journals.Add(journal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(journal);
        }

        // GET: Journals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Journals.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // POST: Journals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JournalID,AuthorID,Maker,Title,JType,ImagePath,Rating,Description,Date,Location,PrivacyType")] Journal journal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(journal);
        }

        // GET: Journals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Journals.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Journal journal = db.Journals.Find(id);
            db.Journals.Remove(journal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Journals/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: Journals/Search/searchTerm
        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            // Get journals that match the searchTerm
            var journals = (from j in db.Journals
                            where j.Description.Contains(searchTerm)
                            select j).ToList();
            // Return searchTerm to display to user.
            ViewBag.SearchTerm = searchTerm;
            return View("Search", journals);
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
