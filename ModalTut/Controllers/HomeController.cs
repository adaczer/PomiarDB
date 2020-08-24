using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModalTut.Models;
using ModalTut.DAL;
using System.Net;
using System.Data.Entity;
using ModalTut.ViewModel;

namespace ModalTut.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        private ModalContext context = new ModalContext();



        [HandleError]

        public ActionResult Index()
        {

            return View(context.Pomiars.ToList());
        }





        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = context.Pomiars.Find(id);

            if (result == null)
            {
                return HttpNotFound();
            }


            return View(result);
        }




        public ActionResult AddorEdit()
        {
            
            return View();
        }



        [HttpPost]
        public ActionResult AddorEdit(Pomiar p2)
        {

            if (ModelState.IsValid)
            {

                context.Pomiars.Add(p2);
                context.SaveChanges();

                return RedirectToAction("Details", "Pomiar", new { id = p2.PomiarId });
            }
         
            return View(p2);
        }



        [HttpPost]
        public ActionResult AddItems2(PomiarItems2ViewModel vm2)
        {
            context.Items.Add(vm2.Items);
            context.SaveChanges();

            return RedirectToAction("Details", "Pomiar", new {id=vm2.Items.PomiarId});
        }

        public PartialViewResult AddNextItem(int id)
        {

            var num = id;

            ViewBag.ID = id;

            return PartialView("_AddNextItem");
        }


        public ActionResult Test()
        {
            return View();
        }

    }






}