using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahuvati
{
    class Class1
    {
        public static void Test(string name)
        {
            if(String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Error");
            }else
            {
                Console.WriteLine("Hello " + name );
            }
        }
    }
}
