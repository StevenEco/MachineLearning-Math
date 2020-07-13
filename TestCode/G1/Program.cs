using System;
namespace G1
{
    class Program
    {
        private static double epsilon = 0.001;
        public static double Binary(Func<double, double> func, double a, double b)
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
            return Binary(func, a, b);
        }
        static void Main(string[] args)
        {
            var fx = new Func<double, double>(x => (x - 1) * (x + 1));
            try
            {
                var real = Binary(fx, 0, 1.857);
                Console.WriteLine("The x = {0},fx={1}", real, fx.Invoke(real));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
