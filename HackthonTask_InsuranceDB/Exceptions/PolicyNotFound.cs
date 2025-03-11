using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackthonTask.Exceptions
{
    internal class PolicyNotFoundException : ApplicationException
    {
        public PolicyNotFoundException()
        {
            
        }
        public PolicyNotFoundException(String mess):base(mess)
        {
            
        }
    }
}
