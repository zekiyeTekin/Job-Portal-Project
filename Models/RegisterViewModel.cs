using System.ComponentModel.DataAnnotations;

namespace EFCoreFinalApp.Models{

    public class RegisterViewModel{

        [Display(Name = "UserName")]
        [Required]
        public string? Username {get;set;}

        [Display(Name = "Ad Soyad")]
        [Required]
        public string? Name {get;set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password {get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Tekrar")]
        [Compare(nameof(Password),ErrorMessage = "Parolanız eşleşmiyor")]
        public string? ConfirmPassword {get;set;}
    }
}