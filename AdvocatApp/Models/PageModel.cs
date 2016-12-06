using AdvocatApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Models
{
    /// <summary>
    /// Модель для статьи
    /// </summary>
    public class PageModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Заголовок пункта меню")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Заголовок")]
        public string Header { get; set; }
        [Display(Name = "Ссылка на видео с YouTube")]
        [DataType(DataType.Url)]
        public string VideoURL { get; set; }
        [AllowHtml]
        [Display(Name = "Текст статьи")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [HiddenInput(DisplayValue = false)]
        public TypePage Type { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime Date { get; set; }
    }
    /// <summary>
    /// Модель для новости или уведомления
    /// </summary>
    public class PageModelWithoutVideo
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Заголовок статьи")]
        public string Header { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string VideoURL { get; set; }
        [AllowHtml]
        [Display(Name = "Введите текст статьи")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [HiddenInput(DisplayValue = false)]
        public TypePage Type { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime Date { get; set; }
    }
}