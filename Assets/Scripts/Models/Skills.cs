public struct Skills
{
    public int Speed { get; private set; }
    public double Attack { get; private set; }
    public double Defence { get; private set; }

    public Skills(int speed, double attack, double defence)
    {
        Speed = speed;
        Attack = attack;
        Defence = defence;
    }
}
