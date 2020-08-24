using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModalTut.Models
{
    public class Pomiar
    {

        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PomiarId { get; set; }

        [Display(Name="Imię i Nazwisko")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Name { get; set; }

        public string Ulica { get; set; }

        [Display(Name = "Miejscowość")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Miejscowosc { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string KodPocztowy { get; set; }

        [EmailAddress(ErrorMessage ="Nieprawidłowy adres email")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Email { get; set; }

        [Display(Name = "Numer telefonu")]
        public string NrTel { get; set; }

        public Status Status { get; set; }

        [Editable(true)]
        [Display(Name = "Data pomiaru")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Data { get; set; }


        public string Notes { get; set; }


        public virtual ICollection<Items>Items { get; set; }

    }


    public enum Status
    {
        Pomiar,
        Realizacja,
        Zrealizowano
    }
}
