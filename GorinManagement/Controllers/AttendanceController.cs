using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GorinManagement.Data;
using GorinManagement.Managers;
using GorinManagement.Models;
using GorinManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GorinManagement.Controllers
{
    public class AttendanceController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IPersonManager personManager;

        public AttendanceController(ApplicationDbContext db, IPersonManager personManager)
        {
            _db = db;
            this.personManager = personManager;
        }

        public IActionResult Index()
        {
            var model = new PersonAttendanceViewModel();
            model.DateOfTraining = DateTime.Today;

            if (TempData["FilteredPeople"] is string s)
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonAttendanceViewModel>(s);
            }
            

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(PersonAttendanceViewModel model)
        {
            foreach(var m in model.Attendances)
            {
                var actAtt = _db.PersonAttendance.Where(a => a.PersonId == m.PersonId && a.DateOfTraining == model.DateOfTraining).FirstOrDefault();
                actAtt.IsAttended = m.IsAttended;
                _db.PersonAttendance.Update(actAtt);
                _db.SaveChanges();
            }
            TempData["FilteredPeople"] = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return Redirect("/Attendance/Index");
        }

        public RedirectToActionResult Filter(PersonAttendanceViewModel model)
        {
            var people = _db.People.ToList();
            foreach(var person in people)
            {
                //Hozzunk létre új kapcsolótábla elemet(PersonAttendance), ha még arra az időpontra ahhoz a személyhez nem létezik
                var singelAttendance = _db.PersonAttendance.Where(x => x.DateOfTraining == model.DateOfTraining && x.PersonId == person.Id).FirstOrDefault();
                if(singelAttendance is null)
                {
                    //alap esetben false-al hozzuk létre, hogy ha utólag megnyitunk egy régebbi dátummal egy listát és közben lett új személy, akkor annak
                    //ne true legyen alapból mert elferdíti a statisztikát
                    _db.PersonAttendance.Add(new PersonAttendance { PersonId = person.Id, DateOfTraining = model.DateOfTraining, IsAttended = false });
                    _db.SaveChanges();
                }
            }

            var partialResult = _db.PersonAttendance.Where(x => x.DateOfTraining == model.DateOfTraining)
                .Select(y => new PersonAttendancePartial {PersonId = y.PersonId, FirstName = personManager.GetPersonById(y.PersonId).FirstName, IsAttended = y.IsAttended }).ToList();

            model.Attendances = partialResult;
            TempData["FilteredPeople"] = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return RedirectToAction("Index","Attendance");
        }
    }
}
