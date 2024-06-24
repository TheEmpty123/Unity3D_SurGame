public class GameSettings
{
    public enum Multiplayer
    {
        Off,
        On
    }

    public int seed;

    public Multiplayer multiplayer { get; set; }

    public GameSettings (int seed, Multiplayer multiplayer = Multiplayer.On)
    {
        this.seed = seed;
        this.multiplayer = (Multiplayer) multiplayer;
    }

}
