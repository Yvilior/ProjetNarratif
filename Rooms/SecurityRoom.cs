using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class SecurityRoom:Room
    {
        public static int Batterie = 100;
        public static int CounterB = 0;
        public static int AM = 0;
        public static int CounterAM = 0;
        internal override string CreateDescription() =>
@"Tu est dans le poste de securite.
A ta gauche il y a une [fenetre gauche] et une [porte gauche].
A ta droite il y a une [fenetre droite] et une [porte droite].
Tu peux utiliser le [moniteur] pour regarder les cameras.
";
        
        internal override void ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "moniteur":
                    
                    Console.WriteLine("Tu inspecte les cameras:\n[couloir gauche]\n[couloir droit]\n[toilettes fille]\n[toilettes garcon]\n[salle a manger]\n[scene de foxy]\n[scene principale]\n[cuisine]\n[stockage]\n[garage]\n");
                    string? option = Console.ReadLine()?.ToLower() ?? "";
                    switch (option)
                    {
                        case "couloir gauche":
                            Game.Transition<CouloirGauche>();CounterB++;
                            break;
                            
                        case "couloir droit":
                            Game.Transition<CouloirDroite>(); CounterB++;
                            break;
                        case "toilettes fille":
                            Game.Transition<BathroomGirl>(); CounterB++;
                            break;
                        case "toilettes garcon":
                            Game.Transition<BathroomBoy>(); CounterB++;
                            break;
                        case "salle a manger":
                            Game.Transition<DinnerRoom>(); CounterB++;
                            break;
                        case "scene de foxy":
                            Game.Transition<FoxysStage>(); CounterB++;
                            break;
                        case "scene principale":
                            Game.Transition<Stage>(); CounterB++;
                            break;
                        case "cuisine":
                            Game.Transition<Kitchen>(); CounterB++;
                            break;
                        case "stockage":
                            Game.Transition<StorageRoom>(); CounterB++;
                            break;
                        case "garage":
                            Game.Transition<PartAndService>(); CounterB++;
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
