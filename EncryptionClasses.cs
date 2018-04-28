using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecrypt
{
    class toBase64
    {
        public char convertIntToChar(int number)
        {
            char found = 'a';
            string range = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

            for (int i = 0; i < range.Length; i++)
            {
                if (number == i)
                {
                    found = range[i];
                    break;
                }
            }

            return found;
        }

        StringBuilder first = new StringBuilder();
        public string convertIntToBinary(int number)
        {
            if (number == 1)
            {
                first.Insert(0, 1);

                while (first.Length % 8 != 0)
                {
                    first.Insert(0, 0);
                }

                return first.ToString();
            }
            if (number % 2 == 0)
            {
                first.Insert(0, 0);
            }
            if (number % 2 == 1)
            {
                first.Insert(0, 1);
            }

            number = number / 2;
            convertIntToBinary(number);

            return first.ToString();
        }

        StringBuilder second = new StringBuilder();
        public string convertTextToBinary(string text)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(text); //i kthejme ne ASCII

            for (int i = 0; i < byteArray.Length; i++) //i shtojm bita me u ba 8
            {
                first.Clear();
                string binaryNumber = convertIntToBinary(byteArray[i]);
                second.Append(binaryNumber);


            }

            return second.ToString();
        }

        StringBuilder third = new StringBuilder();
        public string splitBySixBits(string text)
        {
            int sum = 0;
            char pos = '1';

            if (text.Length % 6 != 0)
            {
                text = text.PadRight(text.Length + (6 - text.Length % 6), '0');
            }

            //text = text.PadRight((text.Length / 6) + (6 - (text.Length % 6)), '0');
            //Console.WriteLine(text);

            for (int i = 0; i < text.Length; i = i + 6)
            {
                if (text[i].Equals(pos))
                {
                    sum = sum + 32;
                }
                if (text[i + 1].Equals(pos))
                {
                    sum = sum + 16;
                }
                if (text[i + 2].Equals(pos))
                {
                    sum = sum + 8;
                }
                if (text[i + 3].Equals(pos))
                {
                    sum = sum + 4;
                }
                if (text[i + 4].Equals(pos))
                {
                    sum = sum + 2;
                }
                if (text[i + 5].Equals(pos))
                {
                    sum = sum + 1;
                }

                third.Append(convertIntToChar(sum));
                sum = 0;

            }

            return third.ToString();
        }

        public string addPaddingToText(string text)
        {
            if (text.Length % 4 != 0)
            {
                text = text.PadRight(text.Length + (4 - text.Length % 4), '=');
            }

            return text;
        }

        public string Encode (string text)
        {
            string string1 = convertTextToBinary(text);
            string string2 = splitBySixBits(string1);

            return addPaddingToText(string2);
        }
    }
}