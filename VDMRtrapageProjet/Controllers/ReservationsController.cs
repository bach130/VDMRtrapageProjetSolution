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
    public class ReservationsController : Controller
    {
        private VDMRtrapageProjetContext db = new VDMRtrapageProjetContext();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.personne).Include(r => r.salle).Include(r => r.theme);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.PersonneID = new SelectList(db.Personnes, "PersonneID", "Nom");
            ViewBag.SalleID = new SelectList(db.Salles, "SalleID", "NomSalle");
            ViewBag.ThemeID = new SelectList(db.Themes, "ThemeID", "NomTheme");
            return View();
        }

        // POST: Reservations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResrvationId,DateDeReservation,tarif,PersonneID,SalleID,ThemeID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonneID = new SelectList(db.Personnes, "PersonneID", "Nom", reservation.PersonneID);
            ViewBag.SalleID = new SelectList(db.Salles, "SalleID", "NomSalle", reservation.SalleID);
            ViewBag.ThemeID = new SelectList(db.Themes, "ThemeID", "NomTheme", reservation.ThemeID);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonneID = new SelectList(db.Personnes, "PersonneID", "Nom", reservation.PersonneID);
            ViewBag.SalleID = new SelectList(db.Salles, "SalleID", "NomSalle", reservation.SalleID);
            ViewBag.ThemeID = new SelectList(db.Themes, "ThemeID", "NomTheme", reservation.ThemeID);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResrvationId,DateDeReservation,tarif,PersonneID,SalleID,ThemeID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonneID = new SelectList(db.Personnes, "PersonneID", "Nom", reservation.PersonneID);
            ViewBag.SalleID = new SelectList(db.Salles, "SalleID", "NomSalle", reservation.SalleID);
            ViewBag.ThemeID = new SelectList(db.Themes, "ThemeID", "NomTheme", reservation.ThemeID);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
