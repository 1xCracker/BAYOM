using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Utilities
{
    public class Encryption
    {
        public static string sifreCoz(string sifrelisifre)
        {
            sifrelisifre = sifrelisifre.TrimEnd();

            string sifresizsifre = "";

            for (int i = 0; i < sifrelisifre.Length; i++)
            {
                string s = sifrelisifre.Substring(i, 1);
                byte b = Encoding.ASCII.GetBytes(s)[0];
                char c = Convert.ToChar(b - (sifrelisifre.Length - i));
                sifresizsifre = sifresizsifre + c;
            }
            return sifresizsifre;
        }


        public static string sifreSifrele(string sifresizsifre)
        {
            string pass, pass1 = null;
            char A = '0', F = ' ';
            int B, D, E;
            pass = sifresizsifre;
            B = pass.Length;
            E = 0;

            for (int i = 0; i < pass.Length; i++)
            {
                string x = pass.Substring(i, 1);
                A = Convert.ToChar(x);
                D = to_n1(A) + B;
                E = D % 256;
                F = to_c1(E);
                pass1 = pass1 + F;
                B = B - 1;
            }
            return pass1;
        }


        private static int to_n1(char C)
        {
            for (int i = 0; i < 256; i++)
            {
                if (C == (char)(i + 1))
                {
                    return (i + 1);
                }
            }
            return 0;
        }

        private static char to_c1(int C)
        {
            return (char)C;
        }
    }
}
