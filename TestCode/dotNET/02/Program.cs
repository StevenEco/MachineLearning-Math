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

        public static double Iterative(Func<double, double> func, double x)
        {
            double temp = func.Invoke(x);
            if (Math.Abs(temp - x) <= epsilon)
            {
                return temp;
            }
            x = temp;
            return Iterative(func, x);
        }

        public static double Newtown(Func<double, double> fx, Func<double, double> f1x, double x)
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

        public static double StringCut(Func<double, double> func, double x1, double x2)
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

        static void Main(string[] args)
        {
            var fx = new Func<double, double>(x => (x - 1) * (x + 1));
            var f1 = new Func<double, double>(x => Math.Pow(x, 3) - x - 1);
            var phix = new Func<double, double>(x => Math.Pow(x + 1, 1.0 / 3.0));
            try
            {
                var real = Binary(fx, 0, 1.857);
                var real1 = Iterative(phix, 3);
                var real2 = Newtown(x => x * x, x => 2 * x, 1.5);
                Console.WriteLine("The x = {0},fx={1}", real, fx.Invoke(real));
                Console.WriteLine("The x = {0},fx={1}", real1, f1.Invoke(real1));
                Console.WriteLine("The x = {0},fx={1}", real2, real2 * real2);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
