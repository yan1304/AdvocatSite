using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvocatApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите e-mail")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина строки должна быть от 6 до 50 символов")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина строки должна быть от 6 до 50 символов")]
        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}