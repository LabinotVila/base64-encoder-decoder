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
<<<<<<< HEAD
        StringBuilder sb = new StringBuilder();
        public string ToBinary(double numri)
        {
=======
    
        static char IntTo64 (int i)
        {
            int c = 0;
            string karakteret = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
            StringBuilder sb4 = new StringBuilder();
            char karakteri = 'b';

            for (c = 0; c <= 63; c++)
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

        public string ToBinary(double numri, int counter)
        {
            
>>>>>>> Labinot
            numri = Math.Floor(numri);

            if (numri == 1)
            {
                sb.Insert(0,1);
<<<<<<< HEAD
=======
                counter = counter + 1;
                
                if (counter == 7)
                {
                    sb.Insert(0, 0);
                }
>>>>>>> Labinot

                return sb.ToString();
            }

            if (numri % 2 == 0)
            {
                sb.Insert(0, 0);
<<<<<<< HEAD
=======
                counter = counter + 1;
>>>>>>> Labinot
            }
            else if (numri % 2 == 1)
            {
                sb.Insert(0, 1);
<<<<<<< HEAD
=======
                counter = counter + 1;
>>>>>>> Labinot
            }

            numri = numri / 2;
            
<<<<<<< HEAD
            ToBinary(numri);

            return sb.ToString(); //nuk ekzekutohet kurr
        }

 
=======
            ToBinary(numri, counter);
            

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
                string numriFinal = ToBinary(numri, 0);

                sb2.Append(numriFinal);
            }

            return sb2.ToString();
        }

        StringBuilder sb3 = new StringBuilder();
        public string NdajeNga6 (string stringu)
        {
            int sum = 0;
            char positiveBit = '1';

            int bitat = 6;
            int mbetja = stringu.Length % 6;
            int finalMbetja = bitat - mbetja;

            for (int i = 0; i < finalMbetja; i++)
            {
                stringu = stringu + "0";
            }

            for (int i = 0; i < stringu.Length; i=i+6)
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
                if (stringu[i + 5].Equals(positiveBit))
                {
                    sum = sum + 1;
                }
                
                sb3.Append(IntTo64(sum));
                sum = 0;
            }




            return sb3.ToString();
        }
>>>>>>> Labinot

        static void Main(string[] args)
        {
            Program prg = new Program();
<<<<<<< HEAD
            Console.WriteLine(prg.ToBinary(8));
=======

            string stringu = "diqkaslkdjaslkdjklajsldjasldjalsjdljaksdalsj";

            string asd = prg.StringToBinary(stringu);

            byte[] bytes = Encoding.UTF8.GetBytes(stringu);
            string base64 = Convert.ToBase64String(bytes);

            Console.WriteLine("Si duhet: " + base64);

            Console.WriteLine("Si osht: " + prg.NdajeNga6(asd));
            
>>>>>>> Labinot

            Console.ReadKey();
        }
    }
}
