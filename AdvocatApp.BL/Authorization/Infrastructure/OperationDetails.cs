using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.BL.Authorization.Infrastructure
{
    public class OperationDetails
    {
        /// <summary>
        /// Успешна ли операция
        /// </summary>
        /// <param name="succedeed">Успешна ли операция</param>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="prop">Свойство, в котором произошла ошибка</param>
        public OperationDetails(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }
        /// <summary>
        /// Успешна ли операция
        /// </summary>
        public bool Succedeed { get; private set; }
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// Свойство, в котором произошла ошибка
        /// </summary>
        public string Property { get; private set; }
    }
}
