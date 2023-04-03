using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Elaveler
{
    public  static class Consol
    {
        
        public  static void MyWriteLine(string message)
        {
            MyWrite(message);
            Console.Write("\n");
           
        }


        public static void MyerrorWriteLine(string message)
        {
           MyerrorWrite(message);
            Console.Write("\n");
            
        }


        public static void MyWrite(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in message)
            {
                Thread.Sleep(40);
                Console.Write(item);

            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void MyerrorWrite(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var item in message)
            {
                Thread.Sleep(60);
                Console.Write(item);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
