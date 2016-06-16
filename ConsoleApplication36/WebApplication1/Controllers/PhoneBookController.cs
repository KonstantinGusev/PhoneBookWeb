using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhoneBook.Core;
using MyPhoneBook;
using Newtonsoft.Json.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PhoneBookController : Controller
    {
        // GET: PhoneBook
        public ActionResult Index()
        {
            var service = new MyPhoneBookService();
            return
                View(
                    service.GetPeople()
                        .Select(p => new PersonView { Name = p.Name, PhoneNumber = p.PhoneNumber, Id = p.Id }));
        }

        // GET: PhoneBook/Details/5
        public ActionResult Details(int id)
        {
            var service = new MyPhoneBookService();
            var person = service.GetPerson(id);
            return View(new PersonView { Name = person.Name, PhoneNumber = person.PhoneNumber, Id = person.Id });
        }
        // GET: PhoneBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneBook/Create
        [HttpPost]
        public ActionResult Create(PersonView personView)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var service = new MyPhoneBookService();
                    service.AddPerson(new Person { Name = personView.Name, PhoneNumber = personView.PhoneNumber });
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneBook/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new MyPhoneBookService();
            var person = service.GetPerson(id);
            return View(new PersonView
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                Id = person.Id
            });
        }

        // POST: PhoneBook/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonView personView)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    var service = new MyPhoneBookService();
                    service.UpdatePerson(
                        id,
                        new Person { Name = personView.Name, PhoneNumber = personView.PhoneNumber, });
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneBook/Delete/5
        public ActionResult Delete(int id)
        {
            var service = new MyPhoneBookService();
            var person = service.GetPerson(id);
            return View(new PersonView
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                Id = person.Id
            }); return View();
        }

        // POST: PhoneBook/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var service = new MyPhoneBookService();
                service.DeletePerson(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
