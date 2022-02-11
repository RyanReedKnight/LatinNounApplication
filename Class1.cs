using System;
using System.Collections.Generic;
using System.Text;

namespace LatinNounApplication
{
    static class CharCase
    {
        public static String LowerStr(String str)
        { 
            char[] charArr = new char[str.Length];

            for(int i = 0; i!= str.Length; ++i)
                charArr[i] = Char.ToUpper(str[i]);

            return new string(charArr);

        }

        // Capitalize: Capitalizes first char in string and puts following chars into lowercase.
        public static String Capitalize(String str)
        {

            char[] charArr = new char[str.Length];

            charArr[0] = Char.ToUpper(str[0]);

            for (int i = 1; i != str.Length; ++i)
                charArr[i] = Char.ToLower(str[i]);

            return new string(charArr);
        }
    }
}
