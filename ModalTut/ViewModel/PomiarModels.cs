using ModalTut.Models;
using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModalTut.ViewModel
{
    public class PomiarConfirmationEmail : Email
    {
        public string To { get; set; }

        public Pomiar Pomiar { get; set; }

        public List<Items> ItemsList { get; set; }
    }
}