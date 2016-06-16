using MyPhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryViev
        public ActionResult Index()
        {
            var service = new MyPhoneBookService();
            return View(service.GetCategories()
                .Select(c => new CategoryViev
                {
                    Id = c.Id,
                    Name = c.Name
                }));
            return View();
        }

        // GET: CategoryViev/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryViev/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryViev/Create
        [HttpPost]
        public ActionResult Create(CategoryViev categoryViev)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new MyPhoneBookService();
                    service.AddCategory(new MyPhoneBook.Core.Category
                    {
                        Name = categoryViev.Name
                    });
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryViev/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new MyPhoneBookService();
            var category = service.GetCategory(id);
            return View(new CategoryViev
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        // POST: CategoryViev/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryViev categoryViev)
        {
            try
                {
                    if (ModelState.IsValid)
                    {
                        var service = new MyPhoneBookService();
                        service.UpdateCategory(id,new MyPhoneBook.Core.Category
                        {
                            Name = categoryViev.Name
                        });
                        return RedirectToAction("Index");
                    }

                    return View();
                }
            catch
            {
                return View();
            }
        }
    

        // GET: CategoryViev/Delete/5
        public ActionResult Delete(int id)
        {
            var service = new MyPhoneBookService();
            var category = service.GetCategory(id);
            return View(new CategoryViev
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        // POST: CategoryViev/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var service = new MyPhoneBookService();
                service.DeleteCategory(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
