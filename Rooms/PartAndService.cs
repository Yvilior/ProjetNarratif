using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class PartAndService : Room
    {
        internal override string CreateDescription() =>
@"Tu vois un grand nombre de pieces detaches et de costume d'animatroniques etales sur des etageres.
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
