using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class StorageRoom : Room
    {
        internal override string CreateDescription() =>
@"Tu vois du materiel de nettoyage et des caisses remplis de chapeaux de fete, de petits cadeaux, etc...
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
