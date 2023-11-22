using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class FoxysStage : Room
    {
        static string cond; public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = true;
        internal override void Condition()
        {
            if (SecurityRoom.isInfo) { SecurityRoom.Info(); }
            if (SecurityRoom.AM == 0)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                
                cond = @"Tu vois une petite scene cache derriere un rideau violet, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux quitter[q] la camera a tout moment.
";
            }
            if (SecurityRoom.AM == 1)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                cond = @"Tu vois une petite scene cache derriere un rideau violet, un oeil luisant dans le noir fixe la camera derriere le rideau entre-ouvert, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux quitter[q] la camera a tout moment.
";
            }
            if (SecurityRoom.AM == 2)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                cond = @"Tu vois une petite scene cache derriere un rideau violet, un oeil, un crochet de pirate et un grande bouche ce trouve derriere le rideau entre-ouvert, un des projecteurs est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux quitter[q] la camera a tout moment.
";
            }
            if (SecurityRoom.AM == 3)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                cond = @"Tu vois une petite scene sur laquel Foxy fixe la camera, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux quitter[q] la camera a tout moment.
";
            }
            if (SecurityRoom.AM == 4)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = false;
                
                cond = $@"Tu vois une petite scene vide, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
tu peux quitter[q] la camera a tout moment.
";
            }
            if (SecurityRoom.AM >= 5)
            {
                isBonnie = false; isFreddy = false; isChica = false; isFoxy = true;
                cond = @"Tu vois une petite scene cache derriere un rideau violet, un des projecteur est casse.
Tu vois un panneau s'excusant pour l'attraction en reparation.
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
