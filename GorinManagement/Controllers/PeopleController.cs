using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GorinManagement.Data;
using GorinManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace GorinManagement.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PeopleController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListPeople()
        {
            var people = _db.People;
            return View(people);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person model)
        {
            if (ModelState.IsValid)
            {
                model.IsActive = true;
                _db.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Listpeople");
            }

            return View();
        }

        public IActionResult Details(int Id)
        {
            var model = _db.People.Where(m => m.Id == Id).FirstOrDefault();
            return View(model);
        }

        public IActionResult Edit(int Id)
        {
            var model = _db.People.Where(m => m.Id == Id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            _db.People.Update(person);
            _db.SaveChanges();
            return Redirect("/People/ListPeople");
        }

        public IActionResult Delete(int Id)
        {
            var person = _db.People.Where(m => m.Id == Id).FirstOrDefault();
            return View(person);
        }

        [HttpPost]
        public IActionResult Delete(Person person)
        {
            _db.People.Remove(person);
            _db.SaveChanges();
            return Redirect("/People/ListPeople");
        }
    }
}
