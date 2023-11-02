using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class SecurityRoom:Room
    {
        int Batterie = 100;
        internal override string CreateDescription() => 
@"Tu est dans cette salle.
Tu peux utiliser le [moniteur] pour regarder les cameras.            
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "moniteur":
                    
                    Console.WriteLine("Tu inspecte les cameras:\n[couloir gauche]\n[couloir droit]\n[toilettes fille]\n[toilettes garcon]\n[salle a manger]\n[scene de foxy]\n[scene principale]\n[cuisine]\n[stockage]\n[garage]");
                    string? option = Console.ReadLine()?.ToLower() ?? "";
                    switch (option)
                    {
                        case "couloir gauche":
                            Game.Transition<CouloirGauche>();
                            break;
                        case "couloir droit":
                            Game.Transition<CouloirDroite>();
                            break;
                        case "toilettes fille":
                            Game.Transition<BathroomGirl>();
                            break;
                        case "toilettes garcon":
                            Game.Transition<BathroomBoy>();
                            break;
                        case "salle a manger":
                            Game.Transition<DinnerRoom>();
                            break;
                        case "scene de foxy":
                            Game.Transition<FoxysStage>();
                            break;
                        case "scene principale":
                            Game.Transition<Stage>();
                            break;
                        case "cuisine":
                            Game.Transition<Kitchen>();
                            break;
                        case "stockage":
                            Game.Transition<StorageRoom>();
                            break;
                        case "garage":
                            Game.Transition<PartAndService>();
                            break;
                        default:
                            Console.WriteLine("Commande invalide.");
                            break;





                    }
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
