

namespace Progonka3
{
    public class ProblemSpecification
    {
        public double T_MAX = 10000; //seconds
        public double L_MAX = 0.1; // meter
        public double D = 1 * Math.Pow(10, -6); // meter^2/seconds
        public double d = 1 * Math.Pow(10, -2); // meter
        public double B = 673.1 * Math.Pow(10, -6);
        public double Cs = 10; // kg/meter^3

        public double Initial_Boundary_Condition(double value)
        {
            return 200 + 50 * value;
        }

        public double Left_Border() // fi1
        {
            return 200;
        }
        public double Right_Border1() // fi2
        {
            return -B / D;
        }
        public double Right_Border2() //psi2
        {
            return B * Cs / D;
        }

        public double func()
        {
            return 0;
        }

        public double CalculateA()
        {
            return -(D * (T_MAX / 10) / Math.Pow((L_MAX / 10), 2));
        }

        public double CalculateB()
        {
            return 1 + 2 * D * ((T_MAX / 10) / Math.Pow((L_MAX / 10), 2));
        }

        public double CalculateC()
        {
            return -(D * (T_MAX / 10) / Math.Pow((L_MAX / 10), 2));
        }
    }

    public class ProblemSpecification2
    {
        public double T_MAX = 1; //seconds
        public double L_MAX = 1; // meter
        public static double k = 4.5;
        public double D = k / 100;

        public double Initial_Boundary_Condition(double value)
        {
            return 0;
        }

        public double Left_Border() // fi1
        {
            return 0;
        }
        public double Right_Border(double t) // fi2
        {
            return k * Math.Pow((t * (T_MAX / 100)), 2);
        }

        public double coeff(double n)
        {
            return (Math.Pow((n + 2), 2) - (4.0 / 3.0));
        }

        public double func(double x, double n)
        {
            return k * ((((Math.Pow((x * (L_MAX / 10)), 2)) * (Math.Pow((T_MAX / 100), (3.0 / 2.0)))) / (Math.Pow(Math.PI, (1.0 / 2.0)))) * coeff(n)
                - 2 * D * (Math.Pow((n * (T_MAX / 100)), 2)));
        }

        public double CalculateA()
        {
            return -2 * ((D * Math.Pow(Math.PI, (1.0 / 2.0)) * (1.0 / 2.0) * (Math.Pow((T_MAX / 100), (1.0 / 2.0)))) / (Math.Pow((L_MAX / 10), 2)));
        }

        public double CalculateB()
        {
            return 4 * ((D * Math.Pow(Math.PI, (1.0 / 2.0)) * (1.0 / 2.0) * (Math.Pow((T_MAX / 100), (1.0 / 2.0)))) / (Math.Pow((L_MAX / 10), 2))) + 2.0;
        }

        public double CalculateC()
        {
            return -2 * ((D * Math.Pow(Math.PI, (1.0 / 2.0)) * (1.0 / 2.0) * (Math.Pow((T_MAX / 100), (1.0 / 2.0)))) / (Math.Pow((L_MAX / 10), 2)));
        }
    }

}

