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
        internal override string CreateDescription() =>
@"Tu vois l'entree des toilettes des garcons sombre et des eclats de mirroir sont repandu sur le sol. 
tu peux [quitter] la camera a tout moment.
";

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
