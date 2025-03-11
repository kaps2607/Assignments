using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackthonTask.Exceptions
{
    internal class IdIsAlreadyPresentException:ApplicationException
    {
        public IdIsAlreadyPresentException()
        {
            
        }
        public IdIsAlreadyPresentException(string mess):base(mess)
        {
            
        }
    }
}
