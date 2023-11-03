using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class CouloirGauche : Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        internal override void Condition()
        {

            if (isBonnie == false)
            {
                cond = @"Tu vois a travers la camera un couloir poussiereux et sale.
tu peux [quitter] la camera a tout moment.
";
            }
            if (isBonnie)
            {
                cond = @"Tu vois a travers la camera Bonnie te fixe du regard.
tu peux [quitter] la camera a tout moment.
";
                int RandomBonnie = SecurityRoom.random.Next(1,21);
                if(RandomBonnie == 1)
                {
                    isBonnie = false;
                    SecurityRoom.isBonnie = true;
                }
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






    


