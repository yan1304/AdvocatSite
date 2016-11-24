using AdvocatApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Models
{
    public class PageModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Системное имя статьи")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Заголовок статьи")]
        public string Header { get; set; }
        [Display(Name = "Ссылка на видео с YouTube")]
        public string VideoURL { get; set; }
        [Required]
        [AllowHtml]
        [Display(Name = "Введите текст статьи")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [HiddenInput(DisplayValue = false)]
        public TypePage Type { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime Date { get; set; }
    }

    public class PageModelWithoutVideo
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Системное имя статьи")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Заголовок статьи")]
        public string Header { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string VideoURL { get; set; }
        [Required]
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