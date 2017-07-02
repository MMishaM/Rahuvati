using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahuvati
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int n = 11 , a, b , c;

          

            for (int i = 0; i <= 200; i++)
            {
              /*  

            if((a + b + c) == 15 )
                {
                    Console.WriteLine(i);
                }    */
                
            
            if( i> 9 && i <100)
                {
                  if((i % 10) + (i / 10) == 15)

                    Console.WriteLine(i);
                }else if( i >= 100)
                {
                    a = i / 100;
                    b = i / 10 % 10;
                    c = i % 10;
                    sum = a + b + c;

                    if(sum == 15)
                    {
                        Console.WriteLine(i);
                    }
                }

              


            }

           

        

          
          

            string s = "abr";
            string s2 = "dog";

           Console.WriteLine( isUnique(s));

            //   Console.WriteLine("(char)97 is {0}", (char)98);

            Console.WriteLine(permutation("Is palindrome " + s2,s));

            Console.ReadLine();
        }



        //чи зустрічалась буква
       static bool isUnique(string str)
        {
            bool[] char_set = new bool[128];
            if(str.Length > 128)
            {
                return false;
            }

            for (int i = 0; i < str.Length; i++)
            {
                 int val = str[i];

                if (char_set[val])
                {
                    return false;
                }
                char_set[val] = true;
            }
            return true;
           
        }

                        /*Palindrome*/
        static string sort(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort(content);

            return new string(content);
        }


       static bool permutation(string s , string t)
        {
            if(s.Length != t.Length)
            {
                return false;
            }
            return sort(s).Equals(sort(t));
        }

    }
}
