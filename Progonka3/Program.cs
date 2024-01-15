using System;


namespace Progonka3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double D = 4.5 / 100;
            //double T_MAX = 1;
            //double L_MAX = 1;
            //double a = -2 * ((D * Math.Pow(Math.PI, (1.0 / 2.0)) * (1.0 / 2.0) * (Math.Pow((T_MAX / 100), (1.0 / 2.0)))) / (Math.Pow((L_MAX / 10), 2)));
            ////double a = (D * Math.Pow(Math.PI, (1.0 / 2.0)) * (1.0 / 2.0) * (Math.Pow((T_MAX / 100.0), (1.0 / 2.0))));
            //Console.WriteLine(a);
            //Console.ReadKey();
            run1();
            //run2();
        }

        public static void run1()
        {
            ProblemSpecification spec = new ProblemSpecification();
            Object res = Progonka.Solve(spec, 11, 11)[3];
            double[,] result = (double[,])res;
            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                    Console.Write(string.Format("{0} ", result[i, j]));
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static void run2()
        {
            ProblemSpecification2 spec = new ProblemSpecification2();
            Object res = Progonka.Solve2(spec, 101, 11)[3];
            double[,] result = (double[,])res;
            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                    Console.Write(string.Format("{0} ", result[i, j]));
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
