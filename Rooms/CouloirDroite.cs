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
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        internal override void Condition()
        {

            if (isFreddy == false && isChica == false)
            {
                cond = @"Tu vois un long couloir sombre et defraichi.
tu peux [quitter] la camera a tout moment.
";
            }
            if (isFreddy && isChica == false)
            {
                cond = @"Tu vois un long couloir sombre et une ombre aux oreilles rondes au bout de celui-ci.
tu peux [quitter] la camera a tout moment.
";
               
            }
            if(isFreddy == false && isChica)
            {
                cond = @"Tu vois un long couloir sombre et defraichi. Tu arrives a voir le bec de Chica dans ton angle-mort.
tu peux [quitter] la camera a tout moment.
";
            }
            if(isFreddy && isChica)
            {

                cond = @"Tu vois un long couloir sombre et une ombre aux oreilles rondes au bout de celui-ci. Tu arrives a voir le bec de Chica dans ton angle-mort.
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
