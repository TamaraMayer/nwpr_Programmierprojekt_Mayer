using System;
using System.Collections.Generic;
using System.Text;

namespace RFC_Protokoll
{
    public class RFC
    {
        private static char[] asciiCharacters;

        private static void SetCharArray()
        {
            asciiCharacters = new char[95];

            for (int i = 0; i < 95; i++)
            {
                char c = Convert.ToChar(i+32);
               asciiCharacters[i] =c;
            }
        }

        public static string GetAllLines()
        {
            SetCharArray();

            string s = string.Empty;

            for (int i = 0; i < 72; i++)
            {
                for (int j = 0; j < 95; j++)
                {
                    int c = (i + j) % 95;

                    s=s+asciiCharacters[c];
                }

                s += "\r\n";
            }

            return s;
        }
    }
}
