using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Mayer Tamara
namespace RFC
{
    public class RFC_Protocol
    {
        static Random rand = new Random();
        const int lowerBoundary = 1;
        const int upperBoundary = 127;

        public static string GenerateData()
        {
            string s = string.Empty;

            for (int i = 0; i < 72; i++)
            {
                char c = Convert.ToChar(rand.Next(lowerBoundary,upperBoundary+1));
                s =s+c;
            }

            return s;
        }
    }
}
