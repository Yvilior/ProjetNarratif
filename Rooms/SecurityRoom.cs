﻿using System;
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
        public static bool porteG = false, porteD = false;
        static string cond;
        public static bool isBonnie = false, isFreddy = false, isChica = false, isFoxy = false;
        public static Random random = new Random();
        static string Jumpscare;
        
        internal override void Condition()
        {

            
                cond = @"Tu est dans le poste de securite.
A ta gauche il y a une [fenetre gauche] et une [porte gauche].
A ta droite il y a une [fenetre droite] et une [porte droite].
Tu peux utiliser le [moniteur] pour regarder les cameras.
";
            //Foxy
            if(FoxysStage.isFoxy == false )
            {
                isFoxy = true;
            }
            //Bonnie
            if(isBonnie == false && Stage.isBonnie == false)
            {
                int BonnieRandom = random.Next(1, 8);
                if( BonnieRandom == 1 || BonnieRandom == 7)
                {
                    PartAndService.isBonnie = true;
                }
                else if( BonnieRandom == 2 || BonnieRandom == 5 || BonnieRandom == 6)
                {
                    DinnerRoom.isBonnie = true;
                }
                else if( BonnieRandom == 3)
                {
                    StorageRoom.isBonnie = true;
                }
                else if ( BonnieRandom == 4)
                {
                    CouloirGauche.isBonnie = true;
                }
            }
            //Chica
            if(isChica == false && Stage.isChica == false)
            {
                int ChicaRandom = random.Next(1, 9);
                if (ChicaRandom == 1 || ChicaRandom == 5 || ChicaRandom == 6)
                {
                    DinnerRoom.isChica = true;
                }
                else if(ChicaRandom == 2 || ChicaRandom == 7)
                {
                    BathroomGirl.isChica = true;
                }
                else if (ChicaRandom == 3 || ChicaRandom == 8)
                {
                    Kitchen.isChica = true;
                }
                else if ( ChicaRandom == 4)
                {
                    CouloirDroite.isChica = true;
                }

            }
            //Freddy
            if(isFreddy == false && Stage.isFreddy == false)
            {
                int FreddyRandom = random.Next(1,10);
                if (FreddyRandom == 1 || FreddyRandom == 5 || FreddyRandom == 6 || FreddyRandom == 9)
                {
                    DinnerRoom.isFreddy = true;
                }
                else if (FreddyRandom == 2 || FreddyRandom == 7)
                {
                    BathroomBoy.isFreddy = true;
                }
                else if (FreddyRandom == 3 || FreddyRandom == 8)
                {
                    Kitchen.isFreddy = true;
                }
                else if (FreddyRandom == 4)
                {
                    CouloirDroite.isFreddy = true;
                }
            }

        }
        internal override string CreateDescription() => cond;

        
        internal override void ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "moniteur":
                    if (isFreddy || isFoxy || isChica || isBonnie)
                    {
                        if (isBonnie && porteG == false)
                        {
                            JumpscareBonnie();
                            Console.WriteLine(Jumpscare);
                            Console.WriteLine("\n\tTu es mort...");
                            Game.Finish();
                        }
                        else if (isFoxy && porteG == false)
                        {
                            JumpscareFoxy();
                            Console.WriteLine(Jumpscare);
                            Console.WriteLine("\n\tTu es mort...");
                            Game.Finish();
                        }
                        else if (isChica && porteD == false)
                        {
                            JumpscareChica();
                            Console.WriteLine(Jumpscare);
                            Console.WriteLine("\n\tTu es mort...");
                            Game.Finish();
                        }
                        else if (isFreddy && porteD == false)
                        {
                            JumpscareFreddy();
                            Console.WriteLine(Jumpscare);
                            Console.WriteLine("\n\tTu es mort...");
                            Game.Finish();
                        }
                        if(porteG || porteD)
                        {
                            Batterie -= 2;
                        }
                    }
                    else
                    {

                    
                        Console.WriteLine("Tu inspecte les cameras:\n[couloir gauche]\n[couloir droit]\n[toilettes fille]\n[toilettes garcon]\n[salle a manger]\n[scene de foxy]\n[scene principale]\n[cuisine]\n[stockage]\n[garage]\n");
                        string? option = Console.ReadLine()?.ToLower() ?? "";
                        switch (option)
                        {
                            case "couloir gauche":
                                Game.Transition<CouloirGauche>(); CounterB++; CounterAM++;
                                break;

                            case "couloir droit":
                                Game.Transition<CouloirDroite>(); CounterB++; CounterAM++;
                                break;
                            case "toilettes fille":
                                Game.Transition<BathroomGirl>(); CounterB++; CounterAM++;
                                break;
                            case "toilettes garcon":
                                Game.Transition<BathroomBoy>(); CounterB++; CounterAM++;
                                break;
                            case "salle a manger":
                                Game.Transition<DinnerRoom>(); CounterB++; CounterAM++;
                                break;
                            case "scene de foxy":
                                Game.Transition<FoxysStage>(); CounterB++; CounterAM++;
                                break;
                            case "scene principale":
                                Game.Transition<Stage>(); CounterB++; CounterAM++;
                                break;
                            case "cuisine":
                                Game.Transition<Kitchen>(); CounterB++; CounterAM++;
                                break;
                            case "stockage":
                                Game.Transition<StorageRoom>(); CounterB++; CounterAM++;
                                break;
                            case "garage":
                                Game.Transition<PartAndService>(); CounterB++; CounterAM++;
                                break;
                            default:
                                Console.WriteLine("Commande invalide.");
                                break;




                        }
                    }
                    break;
                case "porte gauche":
                    if (porteG)
                    {
                        Console.WriteLine("Vous ouvrez la porte a votre gauche.");
                        porteG = false;
                        Batterie -= 2;
                        
                    }
                    else
                    {
                        Console.WriteLine("Vous fermez la porte a votre gauche.");
                        porteG = true;
                        Batterie -= 2;
                        if (isFoxy || isBonnie)
                        {
                            Console.WriteLine("Quelqu'un tappe a la porte et disparait dans le noir");
                            isFoxy = false; isBonnie = false;
                        }
                    }
                    break;
                case "porte droite":
                    if (porteD)
                    {
                        Console.WriteLine("Vous ouvrez la porte a votre droite.");
                        porteD = false;
                        Batterie -= 2;
                    }
                    else
                    {
                        Console.WriteLine("Vous fermez la porte a votre droite.");
                        porteD = true;
                        Batterie -= 2;
                        if (isChica || isFreddy)
                        {
                            Console.WriteLine("Quelqu'un tappe a la porte et disparait dans le noir");
                            isFreddy = false; isChica = false;
                        }
                    }
                    break;
                case "fenetre gauche":
                    Console.WriteLine("Vous allumez la lumiere a votre gauche.");
                    Batterie -= 2;
                    if (isBonnie)
                    {
                        Console.WriteLine("Vous voyez une silouhette");
                        
                    }
                    else
                    {
                        Console.WriteLine("Vous voyez rien");

                    }
                    break;
                case "fenetre droite":
                    Console.WriteLine("Vous allumez la lumiere a votre droite.");
                    Batterie -= 2;
                    if (isChica || isFreddy)
                    {
                        Console.WriteLine("Vous voyez une silouhette");

                    }
                    else
                    {
                        Console.WriteLine("Vous voyez rien");

                    }
                    break;
                case "secret":
                    Batterie = 0;
                    break;
                case "info":
                    Console.WriteLine($"CounterB = {CounterB}/2\nCounterAM = {CounterAM}/15");
                    break;
                case "bonus":
                    Batterie = 100;
                    CounterAM += 2;
                    break;
                case "bonheur":
                    AM = 6;
                    break;
                case "bonnie":
                    JumpscareBonnie();
                    Console.WriteLine(Jumpscare);
                    break;
                case "chica":
                    JumpscareChica();
                    Console.WriteLine(Jumpscare);
                    break;
                case "foxy":
                    JumpscareFoxy();
                    Console.WriteLine(Jumpscare);
                    break;
                case "freddy":
                    JumpscareFreddy();
                    Console.WriteLine(Jumpscare);
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }

        static void JumpscareChica()
        {
            Jumpscare =
@"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*++#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#*+=---=*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#****++++=-=#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%###%%%%%%%%%%%%%%%%%#***###***+===*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%#*++==+#%%%%%%%%%%%#*********++===+#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#+====+#%%%%%%%%#*******++++====*%%%%#**++=++*%%%%%%%%%%%%%%%%%%%%%%%%%
#########%%%%%%%%%%%%%%%%%%%%%%#*=--=+*#%%%%##****+++++======*##*+=======*#%%%%%%%%%%%%%%%%%%%%%%%%%
############%%%%%%%%%%%%%%%%%%%%%#+--=++*%%%#****++++======+++++=====--+#%%%%%%%%%%%%%%%%%%%%%%%%%%%
***###########%%%%%%%%%%%%%%%%%%%%%#+===#%#%#***++==++====+++++=+=---=#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
******#########%%%%%%%%####%#%%%%%%%%#===*%%#**++=========++++===---*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
*********######%%%%##############%%%%%%*=-+%##*============++-----+#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
************##%%%##################%%%%%*=-=##*===========-==---=*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
***********#%%%####**#################%%%#=:-**+======-----=---=#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
#######%%##%%%###********########********#*=--=+===--======---+%%%##%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
********###%%###****************++=========++=-====---=====+++++=====++**%%%%%%%%%%%%%%%%%%%%%%%%%%%
+++++++*****###*************++=====--------===++++==--=++++++++=====--====+*%%%%%%%%%%%%%%%%%%%%%%%%
+++++++++*****************++===-----------------========+===---------------==+*%%%%%%%%%%%%%%%%%%%%%
+++++++++++************+++===-----::::::::::-------------------::::::::::-----=+*#%%%%%%%%%%%%%%%%%%
++++++++++++++*******+++==-----------::::::::::::::::--::::::::::::::::::::::---==+#%%%%%%%%%%%%%%%%
+++++++++++++++**##*++==-----------::::::::::::::::::::::::::::::::::::::----:::---=*%%%%%%%%%%%%%%%
===++++++++++++*##*+====-------:::::::-::::::::::::::::::::::::::::::::::::--:::-::-=+#%%%%%%%%%%%%%
=======+++++++*##*+===------::-------==-=---:::::::::::::::::::::::::::::::::::::::--=+#%%%%%%%%%%%%
=======++++++*##*++===-----:-*#*#%%%#%%#**%#***-:::::::::::*%###+++=+++*##+-:::::::--:-+#%%%%%%%%%%%
========++++*##**+====---+%%%%%%%%%##%%##%#*+-=+:::::::::-*%#*=::===-==++++++**-:::----=+#%%%%%%%%%%
========+++*##*+++===--=*%%%%%%%%%%%%%%%%%%%%##-::::::::-=#%%%###%%%####%%%%**#%#-:----==+#%%%%%%%%%
========++*#**++=========*#*==---:--===*#%%%%%=::::::::::-+#%%%%%%##*++++*#%%%%%#:::-----=+#%%%%%%%%
========+*#**++=-==-----:::::::::::::::::::::::::::::-:::::-==:::::::::::::::::::::-------=+#%%%%%%%
=======+*#**+++=-=---::::::::::::::::----::::::::::::::::::::::::::::::::::::::::::::---:--=+#%%%%%%
======+##**++==---:-:::::::::::-+*%%%%%%%##=:::::::::::::::::::-+*####*+-::::::::::::::-:---=+#%%%%%
=====+##**++===--::-::::::::-+#%%%%%%%%%%%%%%+-::::::::::::::+#%%%%%%%%%%%%+:::::::::::::::--=+#%%%%
====+##**+++==-------:::::-*%%%%%%%%%%%%%%%%%%%=:::::::::::+%%%%%%%%%%%%%%%%%#-:::::::::::::--=+#%%%
====###*+++==----------::+%%%%%%%%%##%%%%%%%%%%%+-:::::::-*%%%%%%%%#%%%%%%%%%%%*-::::::::::::---+#%%
***#%##**+===-----=----=#%%%%%*:.......+%%%%%%%%%=::--:::*%%%%%%%%#%#%%%%%%%%%%%%+-:::---:::----=*%%
++*%%##*++===-----=---=#%##%=.............*%%%%%%*--::::=%%%%%%%#%*=:....=##%%%%%%*-::-:::::----=+#%
###%%##*+===---==--=-=*%%*#=:....::........:%%%%%*=--::-***#%#*-..::.........*%%%%%+-----:::----=+*%
##%%%##*+===----=-=--=#%%##=:.:=#%#:.....::.-%#+=+=-----***%#-::=##-:.........*%%%%#=-----:::::--+*%
%%%%##**===--------:-+%%%%#+-:-*##+=:.......:*====-:::::::=%*--+*%#=-.........+%%%%%=----::::::--++#
+#%%##*+====---------*%%%%%#=-::===.........==:::-:-=--:-*%%#+--***=..........*%%%%%+:::::::::::-=+*
+#%%##*+===--==-=--::+%#%%%%%#=::..........+*:::-=++====-+%%%%*-::..........=%%%%%%#=-:-::::::::-=++
#%%%##*+===---===---:=##%%%%%%%%#*+-:::=+#%*:::-+**+===-==+%%%%###*=-:-=+*#%%%%%%%%#-::--:-::::---++
#%%%##*+=====--------:=%%%%%%%%%%%%%%##%%#::::=**#*+======:=%%%%%%%##%%%%%%%#+%%%%#=::::---::::---++
%%%%%#*+====----=-----:-=#%%%%%%%%%%%%%%%+::-=****++====-=--:+%%%%%%%%%%%%%#+-%%%*=:::::-::::::--=++
%%%%%#*+====----=------::::--=+##%%%%##*=::-+***++++========-::-*#%%%%%##%#*+-+=-:::::::-:::::::--++
%%%%%#*++==--==---------::::::::::::::::::=+***+++=======--===-:::::::::::::::::::::::::-::::::::-++
%%%%%##*+==--==---------:::::::::::::::=+++*++++=======----=-====:::::::::::::::::::::::::::::::-=++
%%%%%%#*++==-===-------:::::::::::::-++++++++++=========--------===-:::::::::::::::::::::::::::--=+*
#%%%%%##*+====-=--------:::-::::::=***+++++++===========-----------==-:::::::::::::::::::::::::--++#
%%%%%%%#*++===------:-:::::::::::+***+++++++++======-=----------=------:::::::::::::::::::-:::--=+*%
%%%%%%%##*+===-=---:::::--:::::=+#*****+++++===+=====--------------------:::::::::::::::::::::--+*#%
%%%%%%%%#*++==-=--:::::::::::-=+%%#**********+++++++====--=------=-----==-::::::::::::::-::::--=+#%%
###%%%%%##*+====---::::::::-==+#%%%%%%%%###########***********+++++++++++:::::::::::::::::::--=+*#%%
####%%%%%#*+====--::::--:-=-=+*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#-::::::::::::::-:::--=+#%%%
#####%%%%%#*+====-------=====*#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%####%%%=::::::::::::::::::-=+*%%%%
%%%%%%%%%%#*++===----=======**#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%######%%=::::::::::::::-::-=++#%%%%
++**=+%%%%%#*+====--======+***#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##########=:::::::::::::--::-=+*%%%%%
++**==*%%%%%#*+===========*****%%+++#%%%%%%%%%%%%%%%%%%%%%%%%%######+...*-::::::::::::::---=+*#%%%%%
++**===#%%%%%#*+=========+*****##*++**#%%%%%%%%%%%%%%%%%%%%#######**+...+=-:::::::::::::--=+*#%%%##%
++*=====#%%%%##*++======+******#**++*############%##################=:..:-::::::::::::---=+*#%%%####
+**+===+*#%%%%##*++++=++******#*#*++*###############################*:..:--:::::::::::---+*#%%%%####
+*++++++++*#%%%%%#**+++*******%*++-...+#############################=.::---:::---::---==+##%%%%%####
++=======++=+*#%%%%##**##****#%%**+:..:#*##########################+....----:------==+*#%%%%%%%%%###
++=======*+=++**#%%%%%%%#####%%%#*+-:::....=###################*:...::::==-=====++*##%%#%%%%%%%%####
+*+======*=:::::::=*%%%%%%%%%%%%%#**+*+=::.:#*=*############*##-....:---=+***##%%%####*==:...:+#####
##**#%%%%#=:::::::::=#####%%%%%%%%#***++=:-==.....*######=....:-::::-===+%%%%####%#+====-:.......=##
**#%%%%%%%*::......:::=*##*###***#%%#***++=++=::.:------==:...:-----==+**##*#%%%%%*----=-.........:*
:-*#%%%#**#+::......::::=*#####*#%%%%##*#**++===-=---------------===++**#%%%%%%%%#=--:--...........*
::*#%%#+===*=...:.:..:::::+**#%%%%%%%%%####****++===--------====+++++*%%%%%%%%%#+---:::............:
:-###%#==-:=+:..........:::-++**##%%%%%%%%%####*****++++++++++++***++**++==-----::::................
:+##%%#=--::--.....:......:::=+++++#%%%%%%%%%%%%%%#####*#####%%%%*=-:::::::::.......................
:###%%#=-::::-:............::::+++++++*%%%%%%%%%%%%%%%%%%%%%%%%*:....................::........::...
+##%%##=-::::-:...........:.....:=+++++++*#%%%%%%%%%%%%%%%#*=:........:.....................:.......
###%%##=-::::--.......:........:::::++++++++++***#####**=:.......................................::.
#%%%%##=-::::--.................:-::.::=++++++++++-:::......:..:......:::.........................::
***#%%*=-::::-=..........................:::::::::..................................................
+###%#+-:--::-=....................:...........................:::...:..............................
%*##%#=-::::-==...:=-.................:.......................:.:::...............................:.
#%%%%*=---:::-=:...::...........................::..........................:.................:.....
#####=---::::--..................................................:.......+****+.....................
%%%%*=---::::=-...............:........:.......:.......:..............:.***-:=**=..=+******+=:.....:
%%%#==----:::=::.................:...:.......:.......:.................:**-:::********+==++****.....
%%%+=---::::-=:..........................................=*+**************=::*****=::::::::::=**=...
%%*=------::==:.............................:-=+****+-=********+=-:::-***********:::::::::::::-**:..
%#+------::-==......:::........:......=***********++****+::::::::::::::=**+++***:::::::++-::::-**=..
%*==----:::-+-......::+*********+....***+-:::::::::::-*=:::::::::::::::+**...-**-:::::::::::=****:..
%+---::::::-+:.......-***+=-:-=**=..:**=::::::::::::::*+::::::::::::-+***=....+***=-:::::::::::**+..
*=-::::::::=+........+**-::::::**+..:**=:::::::::::::*******=::::::=***=......***::::-==:::::::=**..
+=-::::::::+=........+**-::::::***...**+::::::::=******-=+**+::::::=**:.......**+::::::::::::::***..
==-:::::::-+:........+**-::::::***.:.***:::::::::::-***...+**::::::-**-.......+**-:::::::::::-***-..
=--::::::-=+:........+**-::::::***+++***::::::::+**++***=.+**::::::-**=::.:....+***-:::::::+******=.";
        }
        static void JumpscareFoxy()
        {
            Jumpscare =
@"...:...::...:....:...::....:...:...::...:....:........::...:...::...:...::...::...:....:...::...:...
.....:.............::.......:..............:........:...:...........:.:....:........:....:........::
.....:...............................--::.........................:.......................:.........
...:...::...:...::....:........:....-#####*=-:........:....:....:..:::............:....:...:....::..
:::..::...:.:.::...::.:.:...::...:..+#########+:....:...::...:....:...::...:...::...:....:...::...::
...:...::...::...:...::...::...:...:*###%%%%#####-:...::...:...::...:...::...::...::..::...::...:...
..............::................:.:.*###%%#%%%%###+:....................:...........................
......................::.........:.:*###%%#%%%%%%##+.....................................::.........
...:....:...:..:.:...::.....:..:...:=######%%##%%###:.:..:-:.:*::...:...::....:..::::::::..::...:...
::...::...:....:...::...:...::...:..:*#####%%%%%%%##=...:-*=.=#:.::-:.::...::=*#############:.:...::
...:...::...:....::..::...::...:...::-#####%%%%%%@%#-.:...=#=+*:-**-:...::-##########%%####+:...:...
::...:.........::..:..:.....:....::...:#######%%#%#*-*###*=%##*##-:....:.+######%%%%#%%%###:.......:
........................................-*#######%*%@%##########*+=-:...+####%%#%%%#%%%%##=......:..
...:.............:..................:...::::-++-%@@@%################*:-#######%%%#%%####+:::...:...
::...::...:....:...::...:..:::...:....:....:.:#@%@@@@@@%%#############=-###%%%%%%%%%####=:..:::...::
...:....:...:..:.:...::...::...:...::...:..:@@@@%%%%%%###%##%%%%#######*@#####%%######*:........:...
............................:..............=@@@@%@@@@%%#################@*##########+-..............
................:...:......................=@@@@@@@@@@@%%################-.:=++=-:..................
...:....:...:....::..::....:...:.:.::.:.:..*@%%@@@@@@@@@@%##%@@@@%########-..::...:....:...::...:.:.
::...::...:...::...::...:...::.:.:...==--:-%@@%%@@@@@@@@@@@%@@%###########=:...::...:....:...::...::
.:.:...::...:....:...::...::..:::..::*@####%@@@%@@@@@@@@@%%@@%*=#%%%######-..::...:....:...::...:...
.......:-=**+=::...............:#######%%%#####%@@@%%%%%###@@@%#=-*@#####=..............:...........
.....-*%%*=---+#-.......:.......-*###################*#%%#####%%#########:..........................
...:*@@+:...::..*=..:::...::...:..:=##########%%%##*%@@@@%%%#############:...::...::..::...::...:...
:::=@@+...:....::+.::...:...::..::....:=*#######%##%%@@%@@@@################*:.::...::...:...::...::
...+#@=::...:...:=...::...::..::...::.:.:..:-*@%%###########*##############+::::..:....:...::...:...
...-#@*:..:...............:.................+@@@@##############################+:.:....:..:.........
....*#@+:.:................................+@@@@@@#%##########%#################*:..................
...::*#@#=:.:....:...::....:...:...::...:.-@@@@@@@@%@@@@%###@@@@%*::-==++++===-::.:.:..:...::.:.:...
::..::*#@%+:...:...::...:...::...:....:...+@@@@@@@@@@@@@@@@@@@@@@#-:..::...:...::...:....:...::...::
...:...+#@@*::...:...::...::...:..:+=:..::*@@@@@@@@@@@@@@@@@@@@@@#:.:...:-=-.::.:.:...::...::...:...
........=#@%*+=-.................-=+=+#*::#@@@@%%@@@@@@@@@@@@@@@#*:...-**===-...............:.......
.....:-#+#*:=*%#*-.............:-====#@@@###%@@%%@@@@@@@@%%%%#@##+=++##%#==--==--:..................
...::-++@@%%%:+*@#:..::...::-#%@@@@@%##%@@%#@@%%%@@@@@@@@@@@**###########+:.:######=:..:...::...:...
::...=@@@%###%@%@+:::...:.-%@@@@@@@@@@@@%%%#@%*%%@@@@@@@@@@%@#########*++-:-+########-...:...::...::
...:..+@@####%@#::...:...=#@@@@@%%@@@@@%%%%#@@%%@@@@@@@@@%#@###########%@@@@@@###+-:.......:....::..
........:+%###%#=.....:*@@%%%@@@@@@@######%%%@*%@@@@@@@@%+*###########%###*#@@@@@@*:........:.......
........:*%######:..=#%#@@@@@@%#%%+:-*#+###%%#*###%@#%@%#*###@%######+=##:..=@@%####+:..:...........
...:..:::#%######+=%%%###@@%%%##%-.::-#--#############%####*::=@#*+#=:+%::.-@%#######*::...:....:...
::...::.:#%##############%%%%##=.::...-@+=################%%:#@%%+#+:#*:...:*%######%%#:.:....:...::
...:...::###############%%###+::...::...#@%###########%**--=%%%*###%#:...:..:#@%########-:.::...:...
........:*############%%%%%+:...........%@@##########@@*%%##*########:.....:.-#@@%#######=..........
::.:.:...=#########%#%@@%+:.::...:....:.*%%####%@@#%%#%**############.::......-%@%##@@####-...:...::
...:...::-##########%%#-..:....:...::...=%%###%%@@@@@@#*############+:..:::..:::#####@@@###-:...:...
::...::..:+#########+:..:...::...:....:.:%%%##%@@@@@@@%#############=.:::..:...::*####%@@###-::...::
:..:...:::.-+**+=-:..::...::...:...::...:#%%##%@@@@@@@#######*######:....:...::..:*####@@%###:..:.:.
..........:......................:......:*%%##%@####%@##############:..............+###%@@##+:......
........................................:*%%########################..........:.....-###%#####=.....
...:...::...::...:...::...:::.::...::...:#%%########################:...::...::...:..:#%#######::...
::...::...:...::...:....:...::..::....:.:%%%########################-.::...:...::...:-#%#######-..::
...:....:...:....:.............:...::...-%%#########################+.:.::....:...:..:*%%######+:...
........................................+###########################*.................+%%#######....
::...:.:..:....:...:....:...::...:....:.#%=::##-=*###################:::...:....:...:.=%%#######..:.
...:...::...:....:...::...::...:...::...#%=---+#**%@@%###############:..::.:.::...:...:##%%#####:...
::...::...:....:...::...:...::...:....::#@@@@@@@@%###################*::...:...::...:..:%%#####*..::
............:..................:.......=@@@@@@@@@@@@@@#########%%%####=:..........:....:+######*:...
.......:....................:..........+@%%%%%%%%%%%@@@@%%%%%%%%%%%###=:................:%%%%##+....
::...:....:......................:....::@%%%%%%%%%%%%%%%%#%%%%%%%##%#*-:............:....-*=@#*-....
...:...:::..:....:...::...::...:...::..#@@@%%@%%%%%%%%%%%%%%#%%%%%%%@@@%#=....:...:....:...:*%*=:...
::...::...:...::...::...:...::...:.:..:...::...::...:...::...::..::...::.:.:...::...:....:...::...::
.................:.............:........:....:........:....:....:...................................
....................................................................................................
...............:............:....:..:.:....:...:....:...:....:....:.............:...:.........:.....";
        }
        static void JumpscareFreddy()
        {
            Jumpscare =
                @"@#@@@@@@@@@@@@@@@@@@@@@@@#+@;##+'++####@@@@@@@@+#'+'+##+'+';;;+@@@@@@@@@@@@@@@@@@@@@@@@@@@
++####@@@@@@@@@@@@@@@@@@#+@+@##++#+###@#@@@##@@@@#####@+@#+''+@#@@@@@@@@@@@@@@@@@@@@@@####
++#+++###@@@@@@@@@@@@@@@@@@@@@##@###@@@#@@@@@@@###@##@#@@+@#@@@+@@@@@@@@@@@@@@@@@@###+####
+++#'++++#@@@@@@@@@@@@@@#####@@@@@@@@@@@#@@#@#####################@@@@@@@@@@@@@@@##+#++#++
+###++++++#@@@@@@@@@@@@#+#####++++++#+#+##+####+####################@@@@@@@@@@@@####+++###
++##+++++++#@@@@@@@@@###+####+++++#++++++++#+++#++###################@@@@@@@@@@@###+######
######+++++#@@@@@@@@###+####+#+++++++++++++++'+++++##############@####@@@@@@@@@###+####@##
@@@@@@@@++++##@@@@@##++####+++++++'+++++''+++++#++######+##############@@@@@@@#++###@@@@@@
#@#@###@@#+++#@@@@###++##++'##++'++'+++++'++'''++#+#####++##############@@@@@@#+##@@@####@
#########@#+++@@@@@##++###++#+##++'''+##'+++'+'+++#+#+##+++#++###########@@@@#++#@@#######
##########@+++@@@@###+++++++++++++'+++##++++'''''+++++++++++++++#########@@@@++#@@########
###########@+#@@@####''++'''++##+++++#+#+++'''''+''+++++++++++++##########@@@#+#@#########
###+#++####@++@@@###+''++'+'+++#++++###++++++''+''+++++++++'+'+++#+##+####@@@#+@@#########
#++++++#####+#@@###+'##+++++++#++++++#+++++++'+'+''''+'+++++''+++++#+######@@##@@#########
++++++++###++#@@####'++###++++++++++++++'+++++''''''++++++'+++++++++++#####@@@+#@#########
#+++++++##@++@#@+#+#++++##+'''+'++++++++++++++'+++''++++++'++++++++++#++###@@@#+@#########
#+++++++###++@@###+#+'++##++''+++++++++++++++++++''''++++++++++++++++++#####@@#+@@########
##++++++#@'+@@@++++''++#+++++++++#++++++++++++++++++''+++++++++++++++'+#####@@@++@########
++++++++##+#@;@+#++;''++++++++++###++++++++++++++++#++'+'++++++#+++++'+++###;#@#+@@#######
#+#+++###++#@@#++++'''+++#++++++####+##++++++'++++++'++++'+++++++++++++#####@@@@+#@#######
####++##@++@@@##+++'';'+++@@@@@@@@@#+++#+++#+++++'++++++#@@@@@@@@#+++++++####@@@#+@@######
###+####++#@@@+++++;;'''@@@@@@@@@@@@@@@#+##+#####+++#@@@@@@@@@@@@@@@+++++####@@@#+#@######
#######@'#@@@##+++'''''+@@@@@@@@@@@@@@@@@+++++#+++#@@@@@@@@@@@@@@@@@+''+++###@@@@++@@#####
#@@@@@##+#@@@#+#++';'';'@@@@@@@@@@@@@@@@#+++++++++#@@@@@@@@@@@@@@@@@'+++++++##@@@#+#@@@@#@
######+++@@@@++++#'''''+@@@@@@@@@@@@@@@#+'+++++++++#@@@@@@@@@@@@@@@++++'+++++#@@@@#++#####
#++#++++#@@@#++++''''+'+@@@@@##+'+'+++++'++++++++++++++####+##@@@@@+++++++'+###@@@@#++####
+++##++#@@@##++++;''+''+#@@#+++++++++++++++++#++++++++##+++++++#@@@+++++'++++###@@@####+++
##+##@@@@@@###++'''''''++++++++++##+'+++++++##+++++++++####++++++++++++++'''+###@@@@@@####
@@@@@@@@@@@####+'''''+++++++#@@@@@@@#++'+'++++++++++++@@@@@@@##+++++'+++++++++##@@@@@@@@@@
@@@@@@@@@@@####''''''''++###@@@@#@@@@@@'++++++++++++#@@#@@@@@@@#++''+++++++'++##@@@@@@@@@@
@@@@@@@@@@@####''';'''+'+##@@@@@@@@@@@@#+++++++++++#@@@@@@@@@@#@#+'++'++++++++##@@@@@@@@@@
@@@@@@@@@@####'''';;''+++##@@@@@@@@@@@@@++++++++++#@@@@@@@@###@@@#+++++#++++++##@@@@@@@@@@
@@@@@@@@@@###+';;'''''''+@@@@@@@;:,@@@@@#+++#+++++#@@:     :@@@#@@+++++++++#+++#@@@@@@@@@@
@@@@@@@@@@###';;';++''++#@@#:.`.:,:'@@@@@+++++++++;,``,:,:   `@@@@++++#+++++'#+#@@@@@@@@@@
@@@@@@@@@@##+';''''+++++#@@':.; ...,@@@@@###+++++#:,`; ...`   @@@@#++++#++++++##@@@@@@@@@@
@@@@@@@@@@+#''''''+'++++@@@':.;:@@@,@@@@@##++++++#:,``'@@.    @@@@@+++##+++++####@@@@@@@@@
@@@@@@@@@#+++''+'''+++++@@@#:,''@@@,@@@@@++#++#++#;,,'#@@;:   @@@@@#++#++++++####@@@@@@@@@
@@@@@@@@@++'++'''';'''++@@@@:,++@@':+@@@@##+++##+#;,.++@@;;   @@@@@#+++++++++#####@@@@@@@@
@@@@@@@#+++'+'+''''''''+#@@@;,.@@#+++@@@@##+++##+#::,'@##'    @@#@@#'+#+++++#+#+###@@@@@@@
@@@@@@#+#+'';';'''';'''+#@@@+:,``,  @@@@@@@@@@@@@@@+,.`';     @@@@@#++++++++#+#+####@@@@@@
@@@@@@+++''';';;';;;''+'+@@@@;:.`` `@@@@@@@@@@@@@@@@@@@`     @@@@@#++'#+#+##++++#####@@@@@
@@@@@#+'+'';'';;'';;'''++#@@@@@#@@@@@@@@@@@@@@@@@@@@@@@@`  :@@@@@#++++++++++'+##+####@@@@@
@@@@@+''+'''';;::;;;';''+++@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@##++''+++++++++#+#####@@@@
@@@@#+'''+'+';;;;;;;;''+++#@@@#@@@@@#@@@@@@@@@@@@@@@@@@@@#@@@@@####+++++#+++++++++####@@@@
@@@@#+''++'+'';';;'''++###+++##+##@@.@@@@@@@@@@@@@@@@@@'@@@#########++#++##++++++++###@@@@
@@@@#+'''''++''';;''++##+++++++++##@@@@@@@@@@@@@@@@@@@@@@###+###########+#++++++#++####@@@
@@@@#+'''''+'';';';'##+''++'+++++++#@+#@@@@@@@@@+'::+@@@####++#++###+####+#++#++##++###@@@
@@@@#+''+'''';;';;#++';''++'+'+'++++#@@@@@@@@@@@#@@@@@@##++#+++'+'+++++##++#+++++#++###@@@
@@@@##+'''';;;;;;#'';';''++'+'''''''''+@@@@@@@@@@@@@@###+++++++++++#+'++###++++##++++##@@@
@@@@#+'''''';;'';+'';'';''''''''+''''';+++#@@@@@@#++#++#+++++++++++++++++#++++++#+++##@@@@
@@@@##'''''';;;;#';;;;';''';'''''+';;''+'++++++++++++++++++++'+++++''+''++#++#+++#++##@@@@
@@@@@#+++';''';'';;;;@#;'''';'';;';';;;''''''+#''''++++'+++++'+'+''''@''++++++++##+###@@@@
@@@@@#'+++''';''';:;:@#;''@@';;;';;'';;;''''''#''''''''+''''++++@@'''@+'''+#++++##+###@@@@
@@@@@##+++;:';'+';::;;;;;;;'';;';'';'''';'''''+'''''+''''';'+'++''''''''++'+++++#++##@@@@@
@@@@@@##+;;;;'+';::;::::;;:';;''''''';''';'''''';'''''''''''''''''''''''#'''+#+##+###@@@@@
@@@@@@##+'''''''::::;;':;::;''''''''''''''''''''''+''''';'''''''''''+'''''''###+####@@@@@@
@@@@@@@##++'+'+':;';;:@@:;:;'''''''''''''''''''''''''''';;''''''''''@@'''''+#######@@@@@@@
@@@@@@@@##+++++';';;;;''':;;;''''''''''';;''''''''''''''''''''''''''''''''''######@@@@@@@@
@@@@@@@@@+#++##+'':';;;;;;';';''''+''''''''''''''+'''''''''''''''''''''''''+#####@@@@@@@@@
@@@@@@@@@@#+#+##+';'''';';;';'''''''''''''''''''''''''''''''''''''+'+''''+'####@@@@@@@@@@@
@@@@@@@@@@@#####+'''''+';';'''''''''''''''''+''+''+'''''''''''''+'+++++'''++###@@@@@@@@@@@
@@@@@@@@@@@@####+++++'';'++'+'''++'+'''''''''+''++++'+'''''''+++++++++'''+###@@@@@@@@@@@@@
@@@@@@@@@@@@@@+##++''+'''+++++'++++++++'''''++'+++'+'''''''++++++++'++++++#@#@@@@@@@@@@@@@
@@@@@@@@@@@@@@+'#++++'+++''+'++++++++++++'''++''++++''+++'''++++++++++#++####@@@@@@@@@@@@@
@@@@@@@@@@@@@@++#@++++++'++++++++++++++++++'+++++++++++'++++++++++++#+##+####@@@@@@@@@@@@@
@@@@@@@@@@@@@@+++@@#++++++++++++++++++++++++++++++'++++++++++++#++#####@#####@@@@@@@@@@@@@
@@@@@@@@@@@@@@+'#@@@###+###+++++#+#++++++++++++++++++++++++++###+######@#####@@@@@@@@@@@@@
@@@@@@@@@@@@@@+'+#@@@@##@########++++++++++++++++++++++############@#@@#@##++@@@@@@@@@@@@@
@@@@@@@@@@@@@@++##@@@@@@@@+#@@@@###############+#+########@@##@+'###@##@##+#+@@@@@@@@@@@@@
@@@@@@@@@@@@@@+++##@@@@@@@'#@@@@@@@@@@@@@@@@@@@@@@@@@@@#:`@@@#@#'@@@@@@@##++#@@@@@@@@@@@@@
@@@@@@@@@@@@@@+#+###@@@@@@'#@++'+'+'@@@@@@@@@@@@#+'';##'+#''''@''+@@@@@#####+@@@@@@@@@@@@@
@@@@@@@@@@@@@@++#+####@@@@:@@,:;;;;;##+'''#''';:'''''+@';;;;;:@;;+@@@@########@@@@@@@@@@@@
@@@@@@@@@@@@@@##++++++##@@;@@.:::::,;':;;;;;@@'@;::;;;:;,::::,@:,'@@##########@@@@@@@@@@@@
@@@@@@@@@@@@@@+#++'''+######@.:::,,,@+::::,,@@@@::,:,:@#,,,,,.@@@######++#####@@@@@@@@@@@@
@@@@@@@@@@@@@@+'+''++'''+########;.`@',,,.,.@@@@;,,,..@@,:'@@@##########++++#@@@@@@@@@@@@@
@@@@@@@##@@@@@++'+++;'''++++###########@@#@#####@#@@@##@########+#+++++++##+#@@@@@@@@@@@@@
@@@#########@@#++'++'';'++++++###############+#@##@#@##+##++#+++++++'+++++#+###########@@@
@#+##########@+++''+''++'++++'++++++###+###++########+++##+++++++++++++##+#+##############
###++######@@@#++''++''''+#'+#+++###+'+++#++++#++++++++#++'++++++++++++##+################
+++#####+##@@@@#+''++'''+'+#+++#++++++++++++++#++++++++++#++'++++++++###+#################
+++#########@@@#+'++++++''+'#++++'++++++'+++++#++++++++'+++++++#+++#+#######@#############
+#++####@#@#@@@@#++'+++''+'+'+'++'++++++'+++++++''+++++++++++++###+##+#####@@########+####
+++++#+####@@@@@@#++#+++#++++++++''+++++++++++++'''+++++++++++###++########@@########++##+
;#++#+#####@@@@@@@##+++++++++++++++++++++++##+++'+'+++++++++##+###########@@@@#########++#
++'+++#####@@@@@@@@#+##+#+++#++#+++++++++#+##+++++++++++++#+#############@@@@@#######+++++
'''++#++##@@@@@@@@@@###+#+###+##+++++++++++###++++++#++++################@@@@@######++++''
;''+++++###@@@@@@@@@#############+###+++#+###++++##+++++#################@@@@@#####++++++'
;''++++#####@@@@@@@###.############++++#######+++++#+#####################@+@@@#+#++'+++'+
+;''+'+####@@@@@@@####+@+###########+##########+++############@@###@###+##@@@@@###++++++''
@#'''+++###@@@@@@+###++.#@@###########++################@#@##@@@@@'@######@@@@@#++#++++'+@
(edited by Epicgamedemon)
";
        }
        static void JumpscareBonnie()
        {
            Jumpscare =
@"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%%#######@@@@@@%#####*####%@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%#%%@%%%@@@@@@%#########%@@@@@@@@@@@@@@@@@@*-%+.:+@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@**#%@@@@@@@@@@@%%@@@@@%%@@@@@@@@@@@@@@@@@@@*#@@#%%@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%%##########%%@@@%#%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%##################%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%########################%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@%@@@@@@@@@@@@@@@@@@@@@@@@###*#######################%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@%%@@@@@@@@@@@@@@@@@@@@@%#*#**#####**###############%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@%@@@@@@@@@@%@%@%%%@@%####*+:...:=**#####%%%%######%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@######%@%####%+...=-..=#####:::-*@%*###%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%#####**..*#+..*###*:..:.:=@@%##%@@@@%@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%%#####*%%#+=+#%@@@%*.:=#+.-%@@##%@@@@%@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%######%#%%%%@%##%%@@#.::::*@@%##%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%#####******+++*###%@@@@@%@@@@%###%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%@%%###*++++++++++++++*****##%%######%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%@@%%%*+++++++++++++++++++++**#%#####%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%@@%@%#*++++++++**++++++++******#%###%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%#@@@@#***++*++***++++++++++++**#%@%%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%%##@@@@%%###*******++++++++++++*#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@%@@@@@@@@@@@@@@@@@#%@@@@@@@@@@@@%%#*#*****+++++**%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@%@@@@%@@%@@@@@@@@@%%@@@@@@@@@@@@@@@@@@@%%#######%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@%@@%@@@@@@%%@%#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@%%%@%@@@@%###@%##%+.:%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@%%%#%@@%%@@%###%#####++%%%%%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@%%%%%%@%%#%%###%%####%=.:*%#%%###%%%%%%%#=#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@%%%@@@@%%%###%##@@%####%#%*.:=%=-*%%#%#*+-:+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@#%%%%@@#%%%%+==#@@@@@%%%####%@@@@%%######**#+:-*+..*+::*%%###%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@*#@@@@@@@@@@@%%%%####@@@@@%%%%%#########%#**%%%%%%####%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@#++=+*%++@@@@@@@@@@%%%%%#%%%@@@@@@@%%%%%%%################%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@%%%%%%%%@@@@@@@@@@%%%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@";
        }



    }

}
