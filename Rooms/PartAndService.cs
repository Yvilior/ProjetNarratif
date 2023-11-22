using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class PartAndService : Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        internal override void Condition()
        {
            if (SecurityRoom.isInfo) { SecurityRoom.Info(); }
            if (isBonnie == false)
            {
                cond = @"Tu vois un grand nombre de pieces detaches et de costume d'animatroniques etales sur des etageres.
tu peux quitter[q] la camera a tout moment.
";
            }
            if(isBonnie == true)
            {
                cond = @"Tu vois un grand lapin bleu qui ce chache derriere des etageres.
tu peux quitter[q] la camera a tout moment.
";
            }


        }
        internal override string CreateDescription() => cond;


        internal override void ReceiveChoice(string choice)
        {
            SecurityRoom.Attacke();
            Console.WriteLine("Tu inspectes les cameras:\ncouloir gauche[cg]\ncouloir droit[cd]\ntoilettes fille[tf]\ntoilettes garcon[tg]\nsalle a manger[sm]\nscene de foxy[sf]\nscene principale[sp]\ncuisine[c]\nstockage[s]\ngarage[g]\n");

            switch (choice)
            {
                case "q":

                    Game.Transition<SecurityRoom>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
                case "cg":
                    Game.Transition<CouloirGauche>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;

                case "cd":
                    Game.Transition<CouloirDroite>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;
                case "tf":
                    Game.Transition<BathroomGirl>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;
                case "tg":
                    Game.Transition<BathroomBoy>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;
                case "sm":
                    Game.Transition<DinnerRoom>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;
                case "sf":
                    Game.Transition<FoxysStage>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;
                case "sp":
                    Game.Transition<Stage>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;
                case "c":
                    Game.Transition<Kitchen>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;
                case "s":
                    Game.Transition<StorageRoom>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;
                case "g":
                    Game.Transition<PartAndService>(); SecurityRoom.CounterB++; SecurityRoom.CounterAM++; SecurityRoom.MouvMechant();
                    break;









            }

        }
    }
}
