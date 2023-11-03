using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class DinnerRoom : Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        internal override void Condition()
        {

            if (isBonnie == false && isChica == false && isFreddy == false)
            {
                cond = @"Tu vois une grande salle a manger ou de multiples tables, chaises, et decorations sont presents.
tu peux [quitter] la camera a tout moment.
";
            }
            if (isFreddy && !isChica && !isBonnie)
            {
                
                cond = @"Tu vois Freddy au fond de la salle.
tu peux [quitter] la camera a tout moment.
";
            }
            if (isChica && !isBonnie && !isFreddy)
            {
                
                cond = @"Tu vois Chica devant la porte de la cuisine.
tu peux [quitter] la camera a tout moment.
";
            }
            if (isBonnie && !isChica && !isFreddy)
            {
                
                cond = @"Tu vois Bonnie devant la camera qu'il fixe.
tu peux [quitter] la camera a tout moment.
";

            }
            if(isFreddy && isChica && !isBonnie)
            {
                
                cond = @"Tu vois Freddy au fond de la salle et Chica devant la porte de la cuisine.
tu peux [quitter] la camera a tout moment.
";
            }
            if(isFreddy && isBonnie && !isChica)
            {
                cond = @"Tu vois Freddy au fond de la salle et Bonnie devant la camera qu'il fixe.
tu peux [quitter] la camera a tout moment.
";

            }
            if(isBonnie && isChica && !isFreddy)
            {
                cond = @"Tu vois Bonnie devant la camera qu'il fixe et Chica devant la porte de la cuisine.
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
