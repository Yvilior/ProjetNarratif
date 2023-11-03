using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class PartAndService : Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        internal override void Condition()
        {

            if (isBonnie == false)
            {
                cond = @"Tu vois un grand nombre de pieces detaches et de costume d'animatroniques etales sur des etageres.
tu peux [quitter] la camera a tout moment.
";
            }
            if(isBonnie == true)
            {
                cond = @"Tu vois un grand lapin bleu qui ce chache derriere des etageres.
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

                    Game.Transition<SecurityRoom>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++;
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;

            }

        }
    }
}
