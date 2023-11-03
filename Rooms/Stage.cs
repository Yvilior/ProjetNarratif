using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Stage : Room
    {
        static string cond; public static bool isBonnie = true, isFreddy = true, isChica = true, isFoxy = false;
        internal override void Condition()
        {

            if (SecurityRoom.AM == 0)
            {
                isBonnie = true;isFreddy = true;isChica = true; isFoxy = false;
                cond = @"Tu vois une grande scene de spectacle donnant sur la salle a manger, ou trois animatroniques, Bonnie, Freddy, Chica, sont positionnes, pret a performer.
tu peux [quitter] la camera a tout moment.
";
            }
            if (SecurityRoom.CounterAM == 5)
            {
                isBonnie = false; isFreddy = true; isChica = true; isFoxy = false;
                cond = @"Tu vois une grande scene de spectacle donnant sur la salle a manger, ou deux animatroniques, Freddy, Chica, sont positionnes, pret a performer.
tu peux [quitter] la camera a tout moment.
";
            }
            if (SecurityRoom.AM == 1 || SecurityRoom.AM == 2)
            {
                isBonnie = false; isFreddy = true; isChica = false; isFoxy = false;
                cond = @"Tu vois une grande scene de spectacle donnant sur la salle a manger, ou un animatronique, Freddy, est positionne, pret a performer.
tu peux [quitter] la camera a tout moment.
";
            }
            if (SecurityRoom.AM >= 3)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = false;
                cond = @"Tu vois une grande scene de spectacle donnant sur la salle a manger. La scene est vide.
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
