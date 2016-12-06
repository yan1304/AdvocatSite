using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Models
{
    /// <summary>
    /// Модель для отображения или изменения данных о владельце сайта
    /// </summary>
    public class ChangeAboutModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Название сайта*")]
        public string NameOfSite { get; set; }
        [Required]
        [Display(Name = "Имя*")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Фамилия*")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Отчество*")]
        public string Fathername { get; set; }
        [Required]
        [Display(Name = "Мобильный телефон*")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Домашний телефон")]
        [DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }
        [Display(Name = "Адрес ВКонтакте")]
        [DataType(DataType.Url)]
        public string Vk { get; set; }
        [Display(Name = "Адрес Фейсбук")]
        [DataType(DataType.Url)]
        public string Facebook { get; set; }
        [Display(Name = "Адрес Твиттер")]
        [DataType(DataType.Url)]
        public string Twitter { get; set; }
        [Display(Name = "Адрес Google+")]
        [DataType(DataType.Url)]
        public string GooglePl { get; set; }
        [Display(Name = "Адрес Youtube")]
        [DataType(DataType.Url)]
        public string Youtube { get; set; }
        [Display(Name = "Адрес, по которому вас можно найти")]
        public string Address { get; set; }
        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Введите основной текст, а также партнеров*")]
        public string AboutMe { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string Email { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string Password { get; set; }
    }
}