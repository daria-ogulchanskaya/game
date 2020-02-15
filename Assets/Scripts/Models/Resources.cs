using System;

public struct Resources : ICloneable
{
    public double Credits { get; set; }
    public double People { get; set; }
    public double Goods { get; set; }

    public Resources(double credits, double people, double goods)
    {
        Credits = credits;
        People = people;
        Goods = goods;
    }

    public bool IsEnough(Resources resourses) =>
        Credits >= resourses.Credits && 
        People >= resourses.People && 
        Goods >= resourses.Goods;

    public void Add(Resources resourses)
    {
        Credits += resourses.Credits;
        People += resourses.People;
        Goods += resourses.Goods;
    }

    public void Subtract(Resources resourses)
    {
        Credits -= resourses.Credits;
        People -= resourses.People;
        Goods -= resourses.Goods;
    }

    public void Multiply(double value)
    {
        Credits *= value;
        People *= value;
        Goods *= value;
    }

    // TODO: Rename.
    public int Divide(Resources resourсes)
    {
        var credits = Credits / resourсes.Credits;
        var people = People / resourсes.People;
        var goods = Goods / resourсes.Goods;

        return (int) Math.Min(Math.Min(credits, people), goods);
    }

    public Resources Clone() =>
        new Resources(Credits, People, Goods);

    object ICloneable.Clone() => Clone();
}