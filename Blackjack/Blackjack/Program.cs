using Blackjack.Classes;
using System;
using System.Text;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            
            var runTests = false;
            

            if (!runTests)
            {
                
                new GameArea();  
            }
            else
            {
                //test mode
                // new Tests().Run();
            }
        }
    }
}
