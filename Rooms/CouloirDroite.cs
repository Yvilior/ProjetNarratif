using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class CouloirDroite : Room
    {
        static string cond;
        internal override void Condition()
        {

            if (SecurityRoom.Batterie <= 100)
            {
                cond = @"Tu vois un long couloir sombre et defraichi.
tu peux [quitter] la camera a tout moment.
";
            }


        }
        internal override string CreateDescription() => cond;


        internal override void ReceiveChoice(string choice)
        {

            switch (choice)
            {
                case "quitter":

                    Game.Transition<SecurityRoom>(); SecurityRoom.CounterB++;
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;

            }

        }
    }
}
