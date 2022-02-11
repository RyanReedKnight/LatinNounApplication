using System;
using System.Collections.Generic;
using System.Text;

namespace LatinNounApplication
{
    static class UserInputFunctions
    {

        public static String RequestValidConsoleInput(String message)
        {

            Console.WriteLine(message);
            return Console.ReadLine();

        }
        public static String RequestValidConsoleInput() { return RequestValidConsoleInput("Please input valid value into console."); }
        
        

    }
}
