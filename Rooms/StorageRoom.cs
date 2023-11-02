using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class StorageRoom : Room
    {
        static string cond;
        internal override void Condition()
        {

            if (SecurityRoom.Batterie <= 100)
            {
                cond = @"Tu vois du materiel de nettoyage et des caisses remplis de chapeaux de fete, de petits cadeaux, etc...
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
