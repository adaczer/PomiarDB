using ModalTut.DAL;
using ModalTut.Models;
using ModalTut.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ModalTut.Controllers
{
    public class PomiarController : Controller
    {

        private ModalContext context = new ModalContext();

        



        //  karta szczegolow generowana po indywidualnym numerze id klienta
        public ActionResult Details(int id, bool? SendEmail)
        {
            if(SendEmail == true)
            {
                ViewBag.sendEmail = "yes";
            }

            var pom = context.Pomiars.Where(c => c.PomiarId == id).FirstOrDefault();

            List<Items> itemy = context.Items.Where(c => c.PomiarId == id).ToList();

            PomiarItemsViewModel vm = new PomiarItemsViewModel()
            {
                Items = itemy,
                Pomiar = pom
            };



            return View(vm);
        }




        // kasowanie klienta wraz z jego pomiarem
        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {

            var data = context.Pomiars.FirstOrDefault(x => x.PomiarId == id);
            var items = context.Items.Where(x => x.PomiarId == id).ToList();
            if (data != null)
            {
                context.Items.RemoveRange(items);
                context.Pomiars.Remove(data);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }






        //get / edycja klienta, generowana po id - wyswiretlenie
        public ActionResult EditClient(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PomiarItemsViewModel data = new PomiarItemsViewModel();

            var pom1 = context.Pomiars.Where(c => c.PomiarId == id).FirstOrDefault();


            if (pom1 == null)
            {
                return HttpNotFound();
            }

            data.Pomiar = pom1;

            Pomiar pp = data.Pomiar;

            return View(pp);
        }


        //post/ edycja klienta - wyslany formularz - 
        [HttpPost]
        public ActionResult EditClient(Pomiar pivm)
        {

            if (ModelState.IsValid)
            {

                Pomiar data2 = context.Pomiars.Find(pivm.PomiarId);

                data2.Name = pivm.Name;
                data2.Ulica = pivm.Ulica;
                data2.Miejscowosc = pivm.Miejscowosc;
                data2.KodPocztowy = pivm.KodPocztowy;
                data2.NrTel = pivm.NrTel;
                data2.Status = pivm.Status;
                data2.Data = pivm.Data;
                data2.Notes = pivm.Notes;
                data2.Email = pivm.Email;

                context.Entry(data2).State = EntityState.Modified;
                context.SaveChanges();

             

                return RedirectToAction("Details", new { id = data2.PomiarId });
            }

            return View(pivm);
        }



        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }


        // kasowanie wybranej pozycji w pomiarze - generowane na podstawie id klienta oraz po id produktu.
        [HttpGet]
        [Authorize]
        public ActionResult DeleteItem(int id, int id2)
        {
           
                var data = context.Items.FirstOrDefault(x => x.ItemsId == id);

            if (data == null)
            {
                return HttpNotFound();
            }

            if (data != null)
                {
                    context.Items.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Details", new { id = id2 });
                }
                else
                    return RedirectToAction("Index");
            
        }



        // get / edycja produktu - generowane na podstawie id klienta oraz id produktu
        public ActionResult EditItem2(int? id, int? id2)
        {

            Items data = context.Items.FirstOrDefault(c => c.ItemsId == id);

            if (data == null)
            {
                return HttpNotFound();
            }

            Pomiar dataPomiar = context.Pomiars.FirstOrDefault(x => x.PomiarId == id2);

            if (dataPomiar == null)
            {
                return HttpNotFound();
            }


            PomiarItems2ViewModel vm4 = new PomiarItems2ViewModel();
            vm4.Items = data;
            vm4.Pomiar = dataPomiar;
   
            return PartialView("_EditItem", vm4);
        }


        // edycja kienta - post -
        [HttpPost]
        public ActionResult EditItem2(PomiarItems2ViewModel pm2)
        {

            Items items = new Items();

            items = pm2.Items;

            if (items != null)
            {
                context.Entry(items).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Details", new { id = pm2.Items.PomiarId });
            }
            else
                return View(items);
        }

        ////wysylka maila
        public ActionResult SendEmail(int? id, string targetEm)
        {

            PomiarConfirmationEmail email = new PomiarConfirmationEmail();

            var target = context.Pomiars.FirstOrDefault(m => m.PomiarId == id);

            List<Items> pomiar1 = context.Items.Where(m => m.PomiarId == id).ToList();

            //email.To = target.Email.ToString();

            email.To = targetEm;

            email.Pomiar = target;

            email.Pomiar.Name = target.Name;
            email.Pomiar.Miejscowosc = target.Miejscowosc;
            email.Pomiar.Ulica = target.Ulica;
            email.Pomiar.KodPocztowy = target.KodPocztowy;
            email.Pomiar.Email = target.Email;
            email.Pomiar.NrTel = target.NrTel;
            email.Pomiar.Data = target.Data;
            email.Pomiar.Status = target.Status;
            email.Pomiar.Status = target.Status;

            email.ItemsList = pomiar1;

            email.Send();
            ViewBag.sendMail = "yes";

            return RedirectToAction("Details", "Pomiar", new { id = target.PomiarId, SendEmail = true});
            //return RedirectToAction("Index", "Home", new { id = target.PomiarId, sendMail = true });
        }



    }
}