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
            if (true & false)
            {
                Console.WriteLine("testssadas");
            }
            int[] array = new int[4] { 1, 2, 3, 4 };


            PrintName(surname: "Petko");


       


          
            var aa = new[,]
        {
      {5, 10, 13, -4, 10},
      {20, 2, 9, 9, -1},
      {5, 10, 4, 8, 14},
      {6, 1, 2, 6, 10},
      {95, 5, 10, 10, 2}
    };
            var bb = new[,]
            {
      {5, 10, 8, -4, 62},
      {20, 2, 9, 9, -1},
      {5, 10, 1, 8, 1},
      {6, 1, 2, 6, -5},
      {95, 5, 1, 3, 2}
    };

            var cc = new[,]
           {
      {0, 0, 0, 0, 0},
      {0, 0, 0, 0, 0},
      {0, 0, 0, 0, 0},
      {0, 0, 0, 0, 0},
      {0, 0, 0, 0, 0}
    };



            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    for (int k = 0; k < 5; k++)
                    {
                        cc[i, j] += aa[i, k] * bb[k, j];
                       

                    }
                    Console.Write(cc[i, j] + " ");



                }

                Console.WriteLine();
            }

            int sum = 0;
            int a, b , c;

          

            for (int i = 0; i <= 200; i++)
            {
             
                
            
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



            Console.WriteLine("***Sorting***");

            Sort();


            Console.WriteLine("***Sorting MERGE***");
            int[] arrayMerge = { 3, 8, 2, 1, 5, 4, 6, 7 };
           MergeSort(arrayMerge);


          

            string s = "abr";
            string s2 = "dog";

           Console.WriteLine( isUnique(s));

            //   Console.WriteLine("(char)97 is {0}", (char)98);

            Console.WriteLine(permutation("Is palindrome " + s2,s));

            Console.ReadLine();
        }




        public static void MergeSort(int[] items)
        {
            if(items.Length <= 1)
            {
                return;
            }

            int leftSize = items.Length / 2; // size of the left subarray
            int rightSize = items.Length - leftSize;
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize,  right , 0 , rightSize);


            MergeSort(left); // |3|8|  |2|1|
            MergeSort(right);

            Merge(items, left, right);
        }

  public static void MergeSort() { }


        public static void Merge(int[] items  ,int[] left , int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;

            int remaining = left.Length + right.Length;


            while(remaining > 0)
            {
                if(leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex];
                }else if(rightIndex >= right.Length)
                {

                }else if(left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }else
                {
                    items[targetIndex] = right[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
        }




        static void PrintName(string name = "Vasylii", string surname = "Kuchko", string middleName = "Petrovych")
        {
            Console.WriteLine($"{name} {surname} {middleName}");
        }




        public static void Sort()
        {
            var a = new[]
            {
      10, 10, 5, 2, 2, 5, 6, 7, 8, 15, 4, 4, 4, 2, 3, 5, 5, 36, 32, 623, 7, 475, 7, 2, 2, 44, 5, 6, 7, 71, 2
    };
            for (int i = 0; i < a.Length; i++)
            {
                int maxValueIndex = i;
               

                for (int j = i+1; j < a.Length; j++)
                {
                    if(a[j] > a[maxValueIndex])
                    {
                        maxValueIndex = j;
                        
                    }
                   
                }
                int temp = a[i];
                a[i] = a[maxValueIndex];
                a[maxValueIndex] = temp;


                Console.Write(maxValueIndex + " ");
               

            }
            Console.WriteLine();
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
                Console.Write(' ');
            }

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
