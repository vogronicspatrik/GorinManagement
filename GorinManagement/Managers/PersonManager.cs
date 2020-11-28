using GorinManagement.Data;
using GorinManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorinManagement.Managers
{
    public class PersonManager : IPersonManager
    {

        private readonly ApplicationDbContext _db;

        public PersonManager(ApplicationDbContext db)
        {
            _db = db;
        }

        public Person GetPersonById(int Id)
        {
            var result = _db.People.Where(x => x.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
