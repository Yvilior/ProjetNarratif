namespace ProjetNarratif.Rooms
{
    internal class Bathroom : Room
    {
        internal override string CreateDescription() =>
@"Dans la toilette, le [bain] est rempli d'eau chaude.
Le [miroir] devant toi affiche ton visage déprimé.
Tu peux revenir dans ta [chambre].
";

        internal override void ReceiveChoice(string choice)
        {
            bool isBathTaken = false;
            switch (choice)
            {
                case "bain":
                    Console.WriteLine("Tu te laisses relaxer dans le bain.");
                    isBathTaken = true;
                    break;
                case "miroir":
                    if (isBathTaken)
                    {
                        Console.WriteLine("Tu aperçois les chiffres 2314 écrits sur la brume sur le miroir.");
                    }
                    else if (isBathTaken == false)
                    {
                        Console.WriteLine("Tu fais des grimaces devant le miroir.");
                    }



                    break;
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
