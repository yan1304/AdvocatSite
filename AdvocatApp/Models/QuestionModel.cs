using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvocatApp.Models
{
    public class QuestionModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Вопрос")]
        [Required]
        public string Ask { get; set; }
        [Display(Name = "Ответ")]
        [Required]
        public string Resp { get; set; }
    }
}