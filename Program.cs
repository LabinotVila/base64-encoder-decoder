using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        StringBuilder sb = new StringBuilder();
        public string ToBinary(double numri)
        {
            numri = Math.Floor(numri);

            if (numri == 1)
            {
                sb.Insert(0,1);

                return sb.ToString();
            }

            if (numri % 2 == 0)
            {
                sb.Insert(0, 0);
            }
            else if (numri % 2 == 1)
            {
                sb.Insert(0, 1);
            }

            numri = numri / 2;
            
            ToBinary(numri);

            return sb.ToString(); //nuk ekzekutohet kurr
        }

 

        static void Main(string[] args)
        {
            Program prg = new Program();
            Console.WriteLine(prg.ToBinary(8));

            Console.ReadKey();
        }
    }
}
