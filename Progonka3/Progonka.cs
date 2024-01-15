

namespace Progonka3
{
    public class Progonka
    {

        public static Object[] Solve(ProblemSpecification spec, int N, int M)
        {

            double delta_t = spec.T_MAX / (M - 1); // величина шаг по времени
            double delta_x = spec.L_MAX / (N - 1); //  величина шага по coordinate
            double a = spec.CalculateA();
            double b = spec.CalculateB();
            double c = spec.CalculateC();
            double z;
            double[,] Concentration = new double[M, N];
            Object[] Test_data = new object[4];
            for (int i = 0; i < N; i++)
            {
                Concentration[0, i] = spec.Initial_Boundary_Condition(i * delta_x);
            }
            double[] Alpha = new double[N - 1];
            double[] Beta = new double[N - 1];
            Alpha[0] = 0;
            Beta[0] = spec.Left_Border(); // 1 of 3
            for (int n = 1; n < M; n++)
            {
                for (int i = 1; i < N - 1; i++)
                {
                    z = Concentration[n - 1, i];// diff
                    Alpha[i] = (-a) / (b + c * Alpha[i - 1]);
                    Beta[i] = (z - c * Beta[i - 1]) / (b + c * Alpha[i - 1]);
                }

                Concentration[n, N - 1] = (delta_x * spec.Right_Border2() + Beta[N - 2]) / (1 - Alpha[N - 2] - (delta_x * spec.Right_Border1()));// diff
                for (int i = N - 2; i > -1; i--)
                {
                    Concentration[n, i] = Alpha[i] * Concentration[n, i + 1] + Beta[i];
                }
                if (n == 1)
                {
                    double[,] gamma = new double[2, 11];
                    for (int k = 0; k < 2; k++)
                    {
                        for (int l = 0; l < 11; l++)
                        {
                            gamma[k, l] = Concentration[k, l];
                        }
                    }
                    Test_data[0] = Alpha;
                    Test_data[1] = Beta;
                    Test_data[2] = gamma;
                }

            }
            Test_data[3] = Concentration;
            return Test_data;
        }

        public static Object[] Solve2(ProblemSpecification2 spec, int M, int N) //101 11
        {

            double delta_t = spec.T_MAX / (M - 1); // величина шаг по времени
            double delta_x = spec.L_MAX / (N - 1); //  величина шага по coordinate
            double a = spec.CalculateA();
            double b = spec.CalculateB();
            double c = spec.CalculateC();
            double z;
            double[,] Concentration = new double[M, N];
            Object[] Test_data = new object[4];
            for (int i = 0; i < N; i++)
            {
                Concentration[0, i] = spec.Initial_Boundary_Condition(i * delta_x);
            }
            double[] Alpha = new double[N - 1];
            double[] Beta = new double[N - 1];
            Alpha[0] = 0;
            Beta[0] = spec.Left_Border(); // 1 of 3 
            for (int n = 1; n < M; n++)
            {
                for (int i = 1; i < N - 1; i++)
                {
                    z = Concentration[n - 1, i] + spec.func(i, n - 1) * 2 * ((1.0 / 2.0) * Math.Sqrt(Math.PI) * Math.Sqrt((delta_t)));
                    Alpha[i] = (-a) / (b + c * Alpha[i - 1]);
                    Beta[i] = (z - c * Beta[i - 1]) / (b + c * Alpha[i - 1]);
                }

                Concentration[n, N - 1] = spec.Right_Border(n);
                for (int i = N - 2; i > -1; i--)
                {
                    Concentration[n, i] = Alpha[i] * Concentration[n, i + 1] + Beta[i];
                }
                if (n == 1)
                {
                    double[,] gamma = new double[2, N];
                    for (int k = 0; k < 2; k++)
                    {
                        for (int l = 0; l < N; l++)
                        {
                            gamma[k, l] = Concentration[k, l];
                        }
                    }
                    Test_data[0] = Alpha;
                    Test_data[1] = Beta;
                    Test_data[2] = gamma;
                }

            }
            Test_data[3] = Concentration;
            return Test_data;
        }

    }
}

