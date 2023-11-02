using ProjetNarratif;
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


while (!game.IsGameOver())
{
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    Console.Clear();
    game.ReceiveChoice(choice);
}

Console.WriteLine("FIN");
Console.ReadLine();