using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Kitchen : Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        internal override void Condition()
        {

            if (isChica == false && isFreddy == false)
            {
                cond = @"La camera de la cuisine est casse.
tu peux quitter[q] la camera a tout moment.
";
            }
            if (isChica && !isFreddy)
            {
                cond = @"La camera de la cuisine est casse. Tu entends des casseroles tombe.
tu peux quitter[q] la camera a tout moment.
";
            }
            if (isFreddy && !isChica)
            {
                cond = @"La camera de la cuisine est casse. Tu entends la musique iconique de Freddy.
tu peux quitter[q] la camera a tout moment.
";
            }
            if (isFreddy && isChica)
            {
                cond = @"La camera de la cuisine est casse. Tu entends des casseroles tombe et la musique iconique de Freddy.
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
