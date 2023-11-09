using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class BathroomBoy: Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        internal override void Condition()
        {

            if (!isFreddy)
            {
                cond = @"Tu vois l'entree des toilettes des garcons sombre et des eclats de mirroir sont repandu sur le sol. 
tu peux quitter[q] la camera a tout moment.
";
            }
            if (isFreddy)
            {
                cond = @"Tu vois l'entree des toilettes des garcons sombre et des eclats de mirroir sont repandu sur le sol. Dans le reflet des eclats de mirroir tu vois Freddy t'observer. 
tu peux quitter[q] la camera a tout moment.
";

            }

        }
        internal override string CreateDescription() => cond;


        internal override void ReceiveChoice(string choice)
        {

            switch (choice)
            {
                case "q":

                    Game.Transition<SecurityRoom>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++;
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;

            }

        }
    }
}
