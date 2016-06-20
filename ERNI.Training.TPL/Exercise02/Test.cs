using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ERNI.Training.TPL.Exercise02
{
    public class Test
    {
        private readonly ITestOutputHelper _output;

        public Test(ITestOutputHelper output)
        {
            _output = output;
        }

        private ITravellingSalesman CreateTravellingSalesman()
        {
            return new TravellingSalesmanParallel();
        }

        [Fact]
        public void FindRoute_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                int[,] input = null;
                var tsm = CreateTravellingSalesman();

                tsm.FindRoute(input);
            });
        }

        [Fact]
        public void FindRoute_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var input = new int[0, 0];
                var tsm = CreateTravellingSalesman();

                tsm.FindRoute(input);
            });
        }

        [Fact]
        public void FindRoute_NonUniformArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var input = new int[1, 2];
                var tsm = CreateTravellingSalesman();

                tsm.FindRoute(input);
            });
        }

        [Fact]
        public void FindRoute_SingleCity_EmptyPath()
        {
            var input = new int[1, 1];
            var tsm = CreateTravellingSalesman();

            var result = tsm.FindRoute(input);

            var expected = Enumerable.Empty<int>();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindRoute_2Cities_2WayRoute()
        {
            var input = new int[2, 2];
            input[0, 1] = 10;
            input[1, 0] = 10;
            var tsm = CreateTravellingSalesman();

            var result = tsm.FindRoute(input);

            var expected = new int[] { 1, 0 };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindRoute_3Cities_CircleRoute()
        {
            var input = new int[3, 3];
            input[0, 1] = 30;
            input[0, 2] = 10;
            input[1, 0] = 30;
            input[1, 2] = 30;
            input[2, 0] = 10;
            input[2, 1] = 20;
            var tsm = CreateTravellingSalesman();

            var result = tsm.FindRoute(input);

            var expected = new int[] { 2, 1, 0 };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindRoute_4Cities_ZicZacRoute()
        {
            var input = new int[4, 4];
            input[0, 1] = 20;
            input[0, 2] = 20;
            input[0, 3] = 30;
            input[1, 0] = 10;
            input[1, 2] = 40;
            input[1, 3] = 30;
            input[2, 0] = 40;
            input[2, 1] = 30;
            input[2, 3] = 10;
            input[3, 0] = 30;
            input[3, 1] = 30;
            input[3, 2] = 20;
            var tsm = CreateTravellingSalesman();

            var result = tsm.FindRoute(input);

            var expected = new int[] { 2, 3, 1, 0 };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindRoute_5Cities_AlmostCircle()
        {
            var input = new int[5, 5];
            input[0, 1] = 20;
            input[0, 2] = 30;
            input[0, 3] = 30;
            input[0, 4] = 20;
            input[1, 0] = 30;
            input[1, 2] = 20;
            input[1, 3] = 40;
            input[1, 4] = 20;
            input[2, 0] = 40;
            input[2, 1] = 30;
            input[2, 3] = 10;
            input[2, 4] = 50;
            input[3, 0] = 10;
            input[3, 1] = 40;
            input[3, 2] = 20;
            input[3, 4] = 90;
            input[4, 0] = 30;
            input[4, 1] = 10;
            input[4, 2] = 50;
            input[4, 3] = 60;
            var tsm = CreateTravellingSalesman();

            var result = tsm.FindRoute(input);

            var expected = new int[] { 4, 1, 2, 3, 0 };
            Assert.Equal(expected, result);
        }

        [Fact(Skip = "Performance")]
        public void FindRoute_10Cities_ParallelEqualsSequential()
        {
            var random = new Random();
            var count = 10;
            var input = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i != j)
                    {
                        input[i, j] = random.Next(100);
                    }
                }
            }

            var sequentialTsm = new TravellingSalesmanSequential();
            var parallelTsm = new TravellingSalesmanParallel();

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var sequentialResult = sequentialTsm.FindRoute(input);
            sw.Stop();
            var sequentialTime = sw.ElapsedMilliseconds;

            sw.Reset();
            sw.Start();
            var parallelResult = parallelTsm.FindRoute(input);
            sw.Stop();
            var parallelTime = sw.ElapsedMilliseconds;

            _output.WriteLine($"Sequential: {sequentialTime}, Parallel: {parallelTime}");
            Assert.Equal(sequentialResult, parallelResult);
        }

        private int[,] ComplementDistances(int[,] distances)
        {
            int count = distances.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    distances[i, j] = distances[j, i];
                }
            }

            return distances;
        }
    }
}
