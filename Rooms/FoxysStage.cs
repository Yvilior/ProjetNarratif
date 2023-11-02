using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class FoxysStage : Room
    {
        static string cond;
        internal override void Condition()
        {

            if (SecurityRoom.Batterie <= 100)
            {
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

                    Game.Transition<SecurityRoom>(); SecurityRoom.CounterB++;
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;

            }

        }
    }
}
