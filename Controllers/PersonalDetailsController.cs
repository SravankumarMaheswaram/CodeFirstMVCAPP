using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class PersonalDetailsController : Controller
    {
        //// GET: PersonalDetails
        //public ActionResult Index()
        //{
        //    return View();
        //}

        MVCAPPContext _context = new MVCAPPContext();

        public ActionResult Index()
        {
            return View(_context.PersonalDetails.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonalDetail personalDetail)
        {
            if (ModelState.IsValid)
            {
                _context.PersonalDetails.Add(personalDetail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalDetail);
        }

        //[HttpGet]
        public ActionResult Edit(int? id)
        {
            PersonalDetail personalDetail = _context.PersonalDetails.Find(id);
            return View(personalDetail);
        }

        [HttpPost]
        public ActionResult Edit(PersonalDetail personalDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(personalDetail).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalDetail);
        }

        public ActionResult Delete(int id) 
        {
            PersonalDetail personalDetail = _context.PersonalDetails.Find(id);
            //_context.PersonalDetails.Remove(personalDetail);
            //_context.SaveChanges();
            //List<PersonalDetail> personaldet = _context.PersonalDetails.ToList();
            return View (personalDetail);
        }

        [HttpPost]
        public ActionResult Delete(PersonalDetail personalDetail)
        {
            if (ModelState.IsValid)
            {
                PersonalDetail personalDetail1 = _context.PersonalDetails.Find(personalDetail.AutoId);
                _context.PersonalDetails.Remove(personalDetail1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalDetail);
        }

    }
}