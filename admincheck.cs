using System;

namespace ConsoleApp1
{
    class admincheck
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            pre();
        }

        public static void pre()
        {
            String input;
            input = Console.ReadLine();

            if (input != null && input.Length > 4)
            {
                String prefix = input.Substring(0, 4);
                Console.WriteLine(prefix);
                if (prefix.Equals("/adm"))
                    Console.WriteLine("Admin account " + input +  " logged in. . .");
                else
                    Console.WriteLine("User account logged in. . .");

                Console.ReadKey();
            }
            else
                Console.WriteLine("User account logged in. . .");
            Console.ReadKey();
        }
    }

}
