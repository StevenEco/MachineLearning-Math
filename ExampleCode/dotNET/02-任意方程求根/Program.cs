
using System;
double epsilon = 0.001;
int times = 20;
double Binary1(Func<double, double> func, double a, double b)
{
    var f1 = func.Invoke(a);
    var f2 = func.Invoke(b);
    if (f1 * f2 > 0)
        throw new ArgumentException("此区间无根或根不唯一");
    double mid = (a + b) / (double)2;
    var fm = func.Invoke(mid);
    if (fm == 0)
        return fm;
    if (f1 * fm < 0)
        b = mid;
    else if (f2 * fm < 0)
        a = mid;
    if (Math.Abs(b - a) <= epsilon)
        return (a + b) / (double)2;
    return Binary1(func, a, b);
}
double Binary2(Func<double, double> func, double a, double b)
{
    double mid = int.MaxValue;
    for (int i = 0; i < times; i++)
    {
        var f1 = func.Invoke(a);
        var f2 = func.Invoke(b);
        if (f1 * f2 > 0)
            throw new ArgumentException("此区间无根或根不唯一");
        mid = (a + b) / (double)2;
        var fm = func.Invoke(mid);
        if (fm == 0)
            return fm;
        if (f1 * fm < 0)
            b = mid;
        else if (f2 * fm < 0)
            a = mid;
    }
    return mid;
}

double Iterative1(Func<double, double> func, double x)
{
    double temp = func.Invoke(x);
    if (Math.Abs(temp - x) <= epsilon)
    {
        return temp;
    }
    x = temp;
    return Iterative1(func, x);
}

double Iterative2(Func<double, double> func, double x)
{
    double temp = 0;
    for (int i = 0; i < times; i++)
    {
        temp = func.Invoke(x);
        x = func.Invoke(temp);
    }
    return temp;
}

double Newtown(Func<double, double> fx, Func<double, double> f1x, double x)
{
    var temp = f1x.Invoke(x);
    if (temp == 0)
    {
        throw new ArgumentException();
    }
    x = x - fx.Invoke(x) / temp;
    if (Math.Abs(fx.Invoke(x)) <= epsilon)
    {
        return x;
    }
    return Newtown(fx, f1x, x);
}

double StringCut(Func<double, double> func, double x1, double x2)
{
    var temp = x1 - (func.Invoke(x1) / (func.Invoke(x1) - func.Invoke(x2))) * (x1 - x2);
    x2 = x1;
    x1 = temp;
    if (Math.Abs(func.Invoke(x1)) <= epsilon)
    {
        return x1;
    }
    return StringCut(func, x1, x2);
}

void ShowIterative()
{
    double x = 0, temp = x, e1 = 0, e2 = 0;
    double real = 0.7853982;
    Console.WriteLine();
    for (int i = 0; i < 20; i++)
    {
        temp = x;
        Console.Write($"\ti={string.Format("{0:D2}", i)}  |  x={temp.ToString("0.0000000")}  |  g(x)={x.ToString("0.0000000")}  |  e = {Math.Abs(x - real).ToString("0.0000000")}  |  ");
        if (i >= 1 && i < 19)
        {
            Console.WriteLine($"ei/ei-1={(e2 / e1).ToString("0.000")}");
        }
        else
        {
            Console.WriteLine();
        }
        e1 = Math.Abs(x - real);
        x = x + Math.Cos(x) - Math.Sin(x);
        e2 = Math.Abs(x - real);
    }
    Console.WriteLine();
}

ShowIterative();