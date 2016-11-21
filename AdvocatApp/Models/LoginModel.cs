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
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}