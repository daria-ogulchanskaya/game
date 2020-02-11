public struct Resourсes
{
    public double Credits { get; set; }
    public double Goods { get; set; }
    public double People { get; set; }

    public Resourсes(double credits, double goods, double people)
    {
        Credits = credits;
        Goods = goods;
        People = people;
    }

    public bool IsEnough(Resourсes resourses) =>
        People >= resourses.People && Credits >= resourses.Credits && Goods >= resourses.Goods;

    public void Substract(Resourсes resourses)
    {
        Credits -= resourses.Credits;
        People -= resourses.People;
        Goods -= resourses.Goods;
    }

    public void Add(Resourсes resourses)
    {
        Credits += resourses.Credits;
        People += resourses.People;
        Goods += resourses.Goods;
    }

    public Resourсes Multiply(int value)
    {
        Credits *= value;
        People *= value;
        Goods *= value;

        return this;
    }
}
