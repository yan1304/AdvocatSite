using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Entities
{
    /// <summary>
    /// Модель вопрос-ответ
    /// </summary>
    class Question
    {
        public int Id { get; set; }
        public int Ask { get; set; }
        public int Resp { get; set; }
    }
}
