using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class MiniJeu4 : Room
    {
        internal override void Condition()
        {
            Console.Clear();


        }
        internal override string CreateDescription() => "Tu t'es endormis pour la quatrieme fois et es actuellement en train de rever:\n(Tapez 'enter' pour continuer)";
        internal override void ReceiveChoice(string choice)
        {
            string ans;
        p1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("MiniJeu en court, tapez [x]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Reponse: ");
            ans = Console.ReadLine();
            Console.Clear();
            if (ans == "")
            {


            }
            else if (ans == "x")
            {
                Game.Transition<SecurityRoom>();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tu te reveilles...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else { goto p1; }
        }
    }
}
