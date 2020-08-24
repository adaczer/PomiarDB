using ModalTut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModalTut.ViewModel
{
    public class PomiarItemsViewModel
    {

        public Pomiar Pomiar { get; set; }

        public IEnumerable<Items> Items { get; set; }

    }
}