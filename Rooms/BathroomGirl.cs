﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class BathroomGirl : Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        internal override void Condition()
        {

            if (isChica == false)
            {
                cond = @"Tu vois l'entree des toilettes des filles, elle est parsemee de dechets en tout genre.
tu peux [quitter] la camera a tout moment.
";
            }
            if (isChica)
            {
                
                cond = @"Tu vois l'entree des toilettes des filles, Tu voix le pied de Chica cache derriere une porte.
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
