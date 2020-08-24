using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModalTut.ViewModel
{
    //public class LoginViewModels
    //{
    //    [Required]
    //    [Display(Name = "Adres e-mail")]
    //    [EmailAddress]
    //    public string Email { get; set; }

    //    [Required]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Hasło")]
    //    public string Password { get; set; }

    //    [Display(Name = "Zapamiętać Cię?")]
    //    public bool RememberMe { get; set; }

    //}

    //public class RegisterViewModel
    //{
    //    [Required]
    //    [EmailAddress]
    //    [Display(Name = "Adres e-mail")]
    //    public string Email { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "{0} musi zawierać co najmniej następującą liczbę znaków: {2}.", MinimumLength = 6)]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Hasło")]
    //    public string Password { get; set; }

    //    [DataType(DataType.Password)]
    //    [Display(Name = "Potwierdź hasło")]
    //    [Compare("Password", ErrorMessage = "Hasło i jego potwierdzenie są niezgodne.")]
    //    public string ConfirmPassword { get; set; }

    //}


    public class Login2ViewModels
    {

     

        [Required(ErrorMessage = "To pole jest wymagane")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(20, MinimumLength = 6 , ErrorMessage = "Hasło musi zawierać conajmniej 6 liter")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        //[NotMapped]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Podane hasła różnią się")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Zapamiętać Cię?")]
        public bool RememberMe { get; set; }

    }


}