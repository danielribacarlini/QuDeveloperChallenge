using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuDeveloperChallenge.Benchmarks
{
    public class WordFinderBenchmark
    {
        private WordFinder finder;

        [GlobalSetup]
        public void Setup()
        {
            var matrix = Mocks.MatrixMock64x64;

            finder = new WordFinder(matrix);
        }

        [Benchmark]
        public void FindWords()
        {
            var wordsToFind = Mocks.MoreThan10WordStreamMock;
            finder.Find(wordsToFind);
        }
    }
}
