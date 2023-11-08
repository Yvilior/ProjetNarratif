using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class FoxysStage : Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = true;
        internal override void Condition()
        {

            if (SecurityRoom.AM == 0)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                cond = @"Tu vois une petite scene cache derriere un rideau violet, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux [quitter] la camera a tout moment.
";
            }
            if (SecurityRoom.AM == 1)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                cond = @"Tu vois une petite scene cache derriere un rideau violet, un oeil luisant dans le noir fixe la camera derriere le rideau entre-ouvert, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux [quitter] la camera a tout moment.
";
            }
            if (SecurityRoom.AM == 2)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                cond = @"Tu vois une petite scene cache derriere un rideau violet, un oeil, un crochet de pirate et un grande bouche ce trouve derriere le rideau entre-ouvert, un des projecteurs est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux [quitter] la camera a tout moment.
";
            }
            if (SecurityRoom.AM == 3)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                cond = @"Tu vois une petite scene sur laquel Foxy fixe la camera, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux [quitter] la camera a tout moment.
";
            }
            if (SecurityRoom.AM == 4)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = false;
                
                cond = @"Tu vois une petite scene vide, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux [quitter] la camera a tout moment.
";
            }
            if (SecurityRoom.AM >= 5)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                cond = @"Tu vois une petite scene cache derriere un rideau violet, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
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
