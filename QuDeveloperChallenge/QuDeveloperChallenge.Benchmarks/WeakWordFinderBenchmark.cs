using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuDeveloperChallenge.Benchmarks
{
    public class WeakWordFinderBenchmark
    {
        private WeakWordFinder finder;

        [GlobalSetup]
        public void Setup()
        {
            var matrix = Mocks.MatrixMock64x64;

            finder = new WeakWordFinder(matrix);
        }

        [Benchmark]
        public void FindWords()
        {
            var wordsToFind = Mocks.MoreThan10WordStreamMock;
            finder.Find(wordsToFind);
        }
    }
}
