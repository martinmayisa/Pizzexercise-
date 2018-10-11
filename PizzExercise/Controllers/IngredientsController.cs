using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using PizzExercise.Models;

namespace PizzExercise.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IngredientsController : Controller
    {
        private PizzaDb db = new PizzaDb();

        // GET: Ingredients
        public ActionResult Index()
        {
            return View(db.Ingredients.ToList());
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return HttpNotFound();
            }
            return View(ingredients);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngredientId,IngredientName,IngredientPrice")] Ingredients ingredients)
        {
            if (ModelState.IsValid)
            {
                db.Ingredients.Add(ingredients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredients);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return HttpNotFound();
            }
            return View(ingredients);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngredientId,IngredientName,IngredientPrice")] Ingredients ingredients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredients);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return HttpNotFound();
            }
            return View(ingredients);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredients ingredients = db.Ingredients.Find(id);
            db.Ingredients.Remove(ingredients);
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