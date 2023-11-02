using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Livingroom : Room
    {
        internal override string CreateDescription() =>
            @"Dans le salon, une lumiere rassurante brille.
            La [television] est eteinte et la telecommande sur la table a manger.
            Tu peux revenir dans ta [chambre].
            ";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "television":
                    Console.WriteLine("Tu allume la television et tu te fait aspirer.");
                        Game.Finish();
                    break;
                case "chambre":
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }




    }
}
