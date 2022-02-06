// See https://aka.ms/new-console-template for more information

double E1(double x)
{
    return (1 - Math.Cos(x)) / Math.Pow(Math.Sin(x), 2);
}

double E2(double x)
{
    return 1/ (1+Math.Cos(x));
}



double x = 0.000005;
for (int i = 0; i < 30; i++)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"round={i},x={x}");
    Console.ResetColor();
    Console.WriteLine($"E1={E1(x)},E2={E2(x)}");
    x /= 2;
}
