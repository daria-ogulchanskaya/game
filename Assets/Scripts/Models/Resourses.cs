using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Resourses
{
    public double Credits { get; set; }
    public double Goods { get; set; }
    public double People { get; set; }

    public Resourses(double credits, double goods, double people)
    {
        Credits = credits;
        Goods = goods;
        People = people;
    }

    public bool IsEnough(Resourses resourses) =>
        People >= resourses.People && Credits >= resourses.Credits && Goods >= resourses.Goods;

    public void Substract(Resourses resourses)
    {
        Credits -= resourses.Credits;
        People -= resourses.People;
        Goods -= resourses.Goods;
    }

    public void Add(Resourses resourses)
    {
        Credits += resourses.Credits;
        People += resourses.People;
        Goods += resourses.Goods;
    }
}

