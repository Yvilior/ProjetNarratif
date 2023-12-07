﻿using ProjetNarratif;
using ProjetNarratif.Rooms;
using System.ComponentModel;

var game = new Game();
game.Add(new SecurityRoom());
game.Add(new BathroomBoy());
game.Add(new BathroomGirl());
game.Add(new CouloirDroite());
game.Add(new CouloirGauche());
game.Add(new DinnerRoom());
game.Add(new Stage());
game.Add(new StorageRoom());
game.Add(new FoxysStage());
game.Add(new Kitchen());
game.Add(new PartAndService());
game.Add(new MiniJeu1());
game.Add(new MiniJeu2());
game.Add(new MiniJeu3());
game.Add(new MiniJeu4());
game.Add(new MiniJeu5());
game.Add(new Devinettecs());
Console.WriteLine("\tFNAF 1\n");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("La premiere heure, aucun animatronique va ce deplacer tu peux donc apprendre les touches et\nensuite passer le temps jusqu'a la premiere heure ou la passer directement.");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Tu es dans une pizzeria ou des robots (animatroniques):\n-Freddy l'ours brun,\n-Foxy le renard pirate,\n-Chica le poulet jaune,\n-Bonnie le lapin bleu\noccupe les enfants la journee.");
Console.WriteLine("Tu es un gardien de nuit et dois surveiller les robots la nuit car ceux-ci ce deplacent et veulent te tuer.\n Le restaurant ouvre ses portes a 6AM donc tu dois survivre jusqu'au matin");
Console.WriteLine("Pour ne pas perdre tu peux utiliser les portes pour les empecher d'entrer dans le poste de securite.\nil n'y a pas de camera dans le poste de securite donc tu dois alumer les lumieres \na ta gauche ou droite pour verifier s'il ne sont pas sur le point de rentrer dans le poste et te tuer.");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("ATTENTION \nSi ta batterie tombe a 0% avant 6AM tu as perdu car tu n'aura plus d'electricite pour ferme les portes.\nN'oublie pas que les portes consomme de l'electricite quand elles sont ferme donc pense a les ouvrir.\n\n");
Console.ForegroundColor = ConsoleColor.White;
while (!game.IsGameOver())
{
    
    Console.WriteLine($"Tu es a {SecurityRoom.Batterie}% de ta batterie.");
    Console.WriteLine($"Il est {SecurityRoom.AM}AM de la nuit.");
    Console.WriteLine("--");
    game.CurrentCondition();
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    Console.Clear();
    game.ReceiveChoice(choice);
    if (SecurityRoom.CounterB == 2)
    {
        SecurityRoom.CounterB = 0;
        SecurityRoom.Batterie--;
    }
    if (SecurityRoom.Batterie == 0)
    {
        
        string jumpscare =
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
        Console.WriteLine(jumpscare);
        Console.WriteLine("\n\tTu as perdu, Freddy est venu te chercher quand le generateur du restaurant s'est arrete...");
        Game.Finish();
    }
    if(SecurityRoom.CounterAM == 15)
    {
        SecurityRoom.AM++;
        SecurityRoom.CounterAM = 0;
    }
    if(SecurityRoom.AM == 6)
    {

        Console.WriteLine("\n\tTu as Gagne! Il est 6am! tu quitte le restaurent et demissionne!");
        Game.Finish();

    }
}

Console.WriteLine("FIN");
Console.ReadLine();

