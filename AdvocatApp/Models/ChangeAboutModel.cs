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
        [Display(Name = "Мобильный телефон*")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Второй телефон")]
        [DataType(DataType.PhoneNumber)]
        public string AnotherPhone { get; set; }
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
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Введите основной текст")]
        public string AboutMe { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Введите основной текст для контактов")]
        public string TextForContacts { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string Email { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string Password { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Подпись к первой карте")]
        public string ForMap1 { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Подпись ко второй карте")]
        public string ForMap2 { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Подпись к третей карте")]
        public string ForMap3 { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        [Display(Name = "Введите первую карту")]
        public string Map1 { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        [Display(Name = "Введите вторую карту")]
        public string Map2 { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        [Display(Name = "Введите третью карту")]
        public string Map3 { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        [Display(Name = "Введите первую карту малых размеров")]
        public string Map1M { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        [Display(Name = "Введите вторую карту малых размеров")]
        public string Map2M { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        [Display(Name = "Введите третью карту малых размеров")]
        public string Map3M { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Ссылка на видео о вас")]
        public string VideoURL { get; set; }
    }
}