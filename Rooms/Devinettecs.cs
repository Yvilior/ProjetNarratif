using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Devinettecs:Room
    {
        static string cond;
        static int essai = 3;
        
        internal override void Condition()
        {
            cond = @"
Je suis plus leger mais plus grand que la tour effeil:
tu as un total de trois essais
";


        }
        internal override string CreateDescription() => cond;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                default:
                    essai--;
                    Console.WriteLine($"non encore {essai} essai.");
                    if ( essai == 0 )
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("tu as perdu");
                        Console.ReadKey();
                        Game.Transition<SecurityRoom>();
                    }
                    if(essai == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Je suis noir");
                    }
                    if(essai == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Je suis immateriel");
                    }
                    
                    break;
                case "ombre":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Bravo");break;







            }
        }



    }
}
