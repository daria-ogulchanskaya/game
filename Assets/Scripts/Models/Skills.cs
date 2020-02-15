public struct Skills
{
    public double Attack { get; private set; }
    public double Defence { get; private set; }
    public int Speed { get; private set; }

    public Skills(double attack, double defence, int speed)
    {
        Attack = attack;
        Defence = defence;
        Speed = speed;
    }

    public void Add(Skills skills)
    {
        Attack += skills.Attack;
        Defence += skills.Defence;
        Speed += skills.Speed;
    }
}
