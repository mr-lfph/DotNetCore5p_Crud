using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore5.Data;
using DotnetCore5.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore5.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
                return View(objList);
        }
        //Get Create
        public IActionResult Create()
        {
           
            return View();
        }
        //post -Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");        
        }
    }
}
