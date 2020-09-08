using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberToWord
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong input = Convert.ToUInt64(Console.ReadLine());
            NumberToWord(input);
        }

        public static void NumberToWord(ulong b)
        {
            string num = "";
        
            List<string> sentence = new List<string>();
            ulong rem = 0;
            Dictionary<ulong, string> numbers = new Dictionary<ulong, string>()
            {

                {1,"bir" },
                {2,"iki" },
                {3,"uc" },
                {4,"dord" },
                {5,"bes" },
                {6,"alti" },
                {7,"yeddi" },
                {8,"sekkiz" },
                {9,"doqquz" },
                {10,"on" },
                {20,"iyirmi" },
                {30,"otuz" },
                {40,"qirx" },
                {50,"elli" },
                {60,"altmis" },
                {70,"yetmis" },
                {80,"seksen" },
                {90,"doxsan" },
                {100,"yuz" },
                {1000,"min" },
                {1000000,"milyon" },
                {1000000000,"milyard" } 


            };
            ulong z = 0;
            ulong s = 0;
            ulong m = 0;
        
            for (ulong i = 0; b > 0; i++)
            {

                string element;
                ulong pow = Convert.ToUInt64(Math.Pow(10, i));
             
                if (i % 3 == 0 && i>0)
                {
                    z += i;
                    pow = Convert.ToUInt64(Math.Pow(10, z));
                    s = pow;
                    i = 0;
                }  
                rem = b % 10;
                if (rem == 0)
                {
                   
                    if (m != s && s>0)
                    {                       
                        element = numbers[s];
                        sentence.Add(element);
                    }     
                    b = (b - rem) / 10;
                     m = s;
                    continue;
                }
               
                if (pow < 100 && rem!=0)
                {
                    element = numbers[pow * rem];
                    sentence.Add(element);
                    b = (b - rem) / 10;
                    continue;
                }
                
                element = numbers[pow];
                sentence.Add(element);  
                element = numbers[rem];
                sentence.Add(element);
                b = (b - rem) / 10;

            }

            for (int i=0;i<sentence.Count()-1;i++)
            {
                var myKey1 = numbers.FirstOrDefault(x => x.Value ==sentence[i]).Key;
                var myKey2 = numbers.FirstOrDefault(x => x.Value == sentence[i+1]).Key;
                if (myKey2 % 1000 == 0 && myKey1 % 1000 == 0)
                {
                    sentence.RemoveAt(i);
                    i -= 1;
                }
                    
            }

            foreach (var item in sentence)
            {
                num = String.Concat(item," ",num);
            }
            Console.WriteLine(num);
        }



    }
}
