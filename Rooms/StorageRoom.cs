using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class StorageRoom : Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        internal override void Condition()
        {

            if (isBonnie == false)
            {
                cond = @"Tu vois du materiel de nettoyage et des caisses remplis de chapeaux de fete, de petits cadeaux, etc...
tu peux quitter[q] la camera a tout moment.
";
            }
            if (isBonnie)
            {
                cond = @"Tu vois Bonnie a cote d'une etagere fixant la camera juste au dessus de lui.
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
