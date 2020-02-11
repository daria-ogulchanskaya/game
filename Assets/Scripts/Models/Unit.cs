public class Unit
{
    public enum Type
    {
        Attack,
        Defence,
        Speed
    }

    public int Speed { get; private set; }
    public double Attack { get; private set; }
    public double Defence { get; private set; }
}
