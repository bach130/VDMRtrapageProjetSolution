﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VDMRtrapageProjet.Data;
using VDMRtrapageProjet.Models;

namespace VDMRtrapageProjet.Controllers
{
    public class SallesController : Controller
    {
        private VDMRtrapageProjetContext db = new VDMRtrapageProjetContext();

        // GET: Salles
        public ActionResult Index()
        {
            return View(db.Salles.ToList());
        }

        // GET: Salles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = db.Salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // GET: Salles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalleID,NomSalle")] Salle salle)
        {
            if (ModelState.IsValid)
            {
                db.Salles.Add(salle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salle);
        }

        // GET: Salles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = db.Salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // POST: Salles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalleID,NomSalle")] Salle salle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salle);
        }

        // GET: Salles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = db.Salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // POST: Salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salle salle = db.Salles.Find(id);
            db.Salles.Remove(salle);
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
