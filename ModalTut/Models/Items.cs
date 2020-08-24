using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModalTut.Models
{
    public class Items
    {

        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemsId { get; set; }

        public int PomiarId { get; set; }

        public int Lp { get; set; }


        [Display(Name ="rodzaj drzwi")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string RodzajDrzwi { get; set; }

        [Display(Name = "Szerokość drzwi")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string SzerDrzwi { get; set; }

        [Display(Name = "Kierunek drzwi")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public Kierunek KierDrzwi { get; set; }


        [Display(Name = "Szerokość ościeżnicy")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string OscWym { get; set; }

        public bool IsOpaska { get; set; }

        [Display(Name = "Ilość")]
        [Required(ErrorMessage = "Podaj ilość")]
        public int Ilosc { get; set; }

        [Display(Name = "Nazwa pomieszczenia")]
        [Required(ErrorMessage = "Podaj nazwę pomieszczenia")]
        public string Uwagi { get; set; }


        public virtual Pomiar Pomiar { get; set; }

    }


    //public enum Rodzaj
    //{
    //    [Display(Name ="Drzwi wewnętrzne")]
    //    wewnetrzne,
    //    [Display(Name = "Drzwi przesuwne")]
    //    przesuwne,
    //    [Display(Name = "Drzwi nietypowe")]
    //    inne
        
    //}

    //public enum Szerokosc
    //{
    //    [Display(Name = "60")]
    //    drzwi60,
    //    [Display(Name = "70")]
    //    drzwi70,
    //    [Display(Name = "80")]
    //    drzwi80,
    //    [Display(Name = "90")]
    //    drzwi90,
    //    [Display(Name = "100")]
    //    drzwi100,
    //    [Display(Name = "nietypowe")]
    //    nietypowe
    //}

    public enum Kierunek
    {
        Lewe,
        Prawe
    }

    //public enum Oscieznica
    //{
    //    [Display(Name = "75-95")]
    //    osc75_95,
    //    [Display(Name = "100-120")]
    //    osc100_120,
    //    [Display(Name = "120-140")]
    //    osc120_140,
    //    [Display(Name = "140-160")]
    //    osc140_160,
    //    [Display(Name = "160-180")]
    //    osc160_180,
    //    [Display(Name = "180-200")]
    //    osc180_200,
    //    [Display(Name = "200-220")]
    //    osc200_220,
    //    [Display(Name = "220-240")]
    //    osc220_240,
    //    [Display(Name = "240-260")]
    //    osc240_260,
    //    [Display(Name = "260-280")]
    //    osc260_280,
    //    [Display(Name = "280-300")]
    //    osc280_300

    //}



}