using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private GenericRepository<Customer> CustRepository;

        //CustomerRepository CustRepository;
        public HomeController()
        {
            this.CustRepository = new GenericRepository<Customer>(new Customer_Entities());
        }

        // GET: Home
        public ActionResult Index()
        {
            var test = CustRepository.GetAll();
            return View(test);
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Customer model)
        {
            if (ModelState.IsValid)
            {
                CustRepository.Insert(model);
                CustRepository.Save();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            this.CustRepository.Delete(id);
            CustRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            return View(this.CustRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Customer model)
        {
            this.CustRepository.Update(model);
            CustRepository.Save();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}