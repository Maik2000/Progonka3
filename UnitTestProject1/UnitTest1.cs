using System.Collections;
using Progonka3;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Validate_First_Step()
        {
            double[] Expected_alpha = new double[] {
         0,
         0.47619047619047616,
         0.61583577712609971 ,
         0.67377988539814271 ,
         0.70115404330779574 ,
         0.71487499764781859 ,
         0.72195650089474039 ,
         0.72566649793659133 ,
         0.72762542606915381 ,
         0.72866403895529319 };

            double[] Expected_beta = new double[] {
         200 ,
         103.87471346466845  ,
         73.991219356803271  ,
         59.561159924112495  ,
         50.553629240619429  ,
         43.766442750334733  ,
         37.94742596694396   ,
         32.55832911614619   ,
         27.358156577593707  ,
         22.237982902175688  };

            double[,] Expected_Concentration = new double[,] { {         200 ,200.5  ,201 ,201.5 ,202 ,202.5 , 203 , 203.5 , 204 , 204.5 ,205 } ,
                                                            { 200, 195.341455417746, 190.167056377267, 183.909362974514, 175.892605869213, 165.265109350834, 150.914123767537, 131.354550560995, 104.580432410551, 67.8643575011633, 17.4847183418915 } };
            ProblemSpecification spec = new ProblemSpecification();
            Object[] res = Progonka.Solve(spec, 11, 11);
            double[] resultA = (double[])res[0];
            double[] resultB = (double[])res[1];
            double[,] resultC = (double[,])res[2];
            CollectionAssert.AreEqual(Expected_alpha, resultA, new DoublesArrayCheckerWithDelta());
            CollectionAssert.AreEqual(Expected_beta, resultB, new DoublesArrayCheckerWithDelta());
            CollectionAssert.AreEqual(Expected_Concentration, resultC, new DoublesArrayCheckerWithDelta());
        }
    }
    public class DoublesArrayCheckerWithDelta : IComparer
    {
        double _delta = 0.00001;
        public DoublesArrayCheckerWithDelta(double delta = 0.001)
        {
            _delta = delta;
        }

        public int Compare(object x, object y)
        {
            var dx = (double?)x;
            var dy = (double?)y;
            if (Math.Abs(dx.Value - dy.Value) > _delta)
                return dx.Value.CompareTo(dy.Value);
            return 0;

            /*
            var dx = (double[,]?)x;
            var dy = (double[,]?)y;
            for(int i = 0;i < dx.GetLength(0); ++i)
            {
                for (int j = 0; j < dx.GetLength(1); ++j)
                { 
                    if (Math.Abs(dx[i,j] - dy[i,j]) > _delta)
                        return dx[i, j].CompareTo(dy[i,j]);
                }
            }
            return 0;
            */
        }
    }
}