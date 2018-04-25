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
        

        static char IntTo64 (int i)
        {
            string karakteret = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
            StringBuilder sb4 = new StringBuilder();
            char karakteri = 'a';

            for (int c = 0; c < karakteret.Length; c++)
            {
                if (i == c)
                {
                    karakteri = karakteret[c];
                    break;
                }
            }

            return karakteri;
        }

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

            return sb.ToString(); //nuk egzekutohet kurr
        }

        StringBuilder sb2 = new StringBuilder();
        public string StringToBinary (string stringu)
        {   
            for (int i = 0; i < stringu.Length; i++)
            {
                sb.Clear();
                int num = (int)(stringu[i]);
                double numri = Convert.ToDouble(num);
                string numriFinal = ToBinary(numri);

                Console.WriteLine(numriFinal);
                
                sb2.Append(numriFinal);
            }

            return sb2.ToString();
        }

        StringBuilder sb3 = new StringBuilder();
        public string NdajeNga6 (string stringu)
        {
            int sum = 0;
            char positiveBit = '1';

            for (int i = 0; i < stringu.Length - 1; i=i+6)
            {
                if (stringu[i].Equals(positiveBit))
                {
                    sum = sum + 32;
                }
                if (stringu[i+1].Equals(positiveBit))
                {
                    sum = sum + 16;
                }
                if (stringu[i+2].Equals(positiveBit))
                {
                    sum = sum + 8;
                }
                if (stringu[i+3].Equals(positiveBit))
                {
                    sum = sum + 4;
                }
                if (stringu[i + 4].Equals(positiveBit))
                {
                    sum = sum + 2;
                }
                if (stringu[i + 5].Equals(1))
                {
                    sum = sum + 1;
                }

                Console.WriteLine(IntTo64(sum));
                sb3.Append(sum);
                sum = 0;
            }




            return sb3.ToString();
        }

        static void Main(string[] args)
        {
            Program prg = new Program();

            string asd = prg.StringToBinary("ASDAA");
            Console.WriteLine(prg.NdajeNga6(asd));

            Console.ReadKey();
        }
    }
}
