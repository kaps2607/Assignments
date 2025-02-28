using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques1.Model
{
    internal class UserCount
    {
        static int UCount = 0;
        public UserCount()
        {
            UCount++;

        }
        public int show()
        {
            return UCount;
        }
    }
}
