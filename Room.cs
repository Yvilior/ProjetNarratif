namespace ProjetNarratif
{
    internal abstract class Room
    {


        internal abstract void Condition();
        internal abstract string CreateDescription();
        internal abstract void ReceiveChoice(string choice);
    }
}
