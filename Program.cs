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
    if(SecurityRoom.CounterB == 2)
    {
        SecurityRoom.CounterB = 0;
        SecurityRoom.Batterie--;
    }
    if(SecurityRoom.Batterie == 0)
    {
        Console.WriteLine("\n\tTu as perdu, Freddy est venu te chercher quand le generateur du restaurent s'est arrete...");
        Game.Finish();
    }
    Console.WriteLine($"Tu est a {SecurityRoom.Batterie}% de ta batterie.");
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    Console.Clear();
    game.ReceiveChoice(choice);
}

Console.WriteLine("FIN");
Console.ReadLine();