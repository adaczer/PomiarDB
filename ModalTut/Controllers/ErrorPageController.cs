using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModalTut.Controllers
{
    public class ErrorPageController : Controller
    {
        public ActionResult Oops()
        {

            return View();
        }
    }
}