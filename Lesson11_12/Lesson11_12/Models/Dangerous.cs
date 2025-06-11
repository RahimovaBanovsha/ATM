using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11_12.Models
{
    static class Dangerous
    {
        public static int DangerousMethod()
        {
            int number = 100;
            return (number / 0);
        }
    }
}
