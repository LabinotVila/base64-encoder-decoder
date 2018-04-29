using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decryption
{
    public class fromBase64
    {
        public int convertCharToInt(char character)
        {
            int found = 0;
            string range = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

            for (int i = 0; i < range.Length; i++)
            {
                if (character == range[i])
                {
                    found = i;
                    break;
                }
            }

            return found;
        }

        StringBuilder first = new StringBuilder();
        public string ConvertIntToBinary(int numri)
        {
            if (numri == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    first.Insert(0, 0);
                }

                return first.ToString();
            }
            if (numri == 1)
            {
                first.Insert(0, 1);

                while (first.Length % 6 != 0)
                {
                    first.Insert(0, 0);
                }

                return first.ToString();
            }
            if (numri % 2 == 0)
            {
                first.Insert(0, 0);
            }
            if (numri % 2 == 1)
            {
                first.Insert(0, 1);
            }

            numri = numri / 2;
            ConvertIntToBinary(numri);

            return first.ToString();
        }

        StringBuilder second = new StringBuilder();
        public string convertTextToBinary(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                first.Clear();
                int charPerText = convertCharToInt(text[i]);
                


                second.Append(ConvertIntToBinary(charPerText));
            }

            return second.ToString();
        }

        StringBuilder third = new StringBuilder();
        public string splitByEightBits(string text)
        {
            int sum = 0;
            char pos = '1';

            if (text.Length % 8 != 0)
            {
                text = text.PadRight(text.Length + (8 - text.Length % 8), '0');
            }

            for (int i = 0; i < text.Length; i = i + 8)
            {
                if (text[i].Equals(pos))
                {
                    sum = sum + 128;
                }
                if (text[i + 1].Equals(pos))
                {
                    sum = sum + 64;
                }
                if (text[i + 2].Equals(pos))
                {
                    sum = sum + 32;
                }
                if (text[i + 3].Equals(pos))
                {
                    sum = sum + 16;
                }
                if (text[i + 4].Equals(pos))
                {
                    sum = sum + 8;
                }
                if (text[i + 5].Equals(pos))
                {
                    sum = sum + 4;
                }
                if (text[i + 6].Equals(pos))
                {
                    sum = sum + 2;
                }
                if (text[i + 7].Equals(pos))
                {
                    sum = sum + 1;
                }

                third.Append((char)sum);
                sum = 0;
            }

            return third.ToString();
        }

        public string Decode (string text)
        {
            text = text.Replace("=", "");
            string string1 = convertTextToBinary(text);
            string string2 = splitByEightBits(string1);

            first.Clear();
            second.Clear();
            third.Clear();

            return string2;
        }
    }
}
