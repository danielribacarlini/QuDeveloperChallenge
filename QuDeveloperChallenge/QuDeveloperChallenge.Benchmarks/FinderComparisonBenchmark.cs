using BenchmarkDotNet.Attributes;
using QuDeveloperChallenge;

namespace QuDeveloperChallenge.Benchmarks
{
    [MemoryDiagnoser]
    public class FinderComparisonBenchmark
    {
        private WordFinder finder;
        private WeakWordFinder weakFinder;

        private IEnumerable<string> matrix;
        private IEnumerable<string> wordsToFind;

        [GlobalSetup]
        public void Setup()
        {
            matrix = Mocks.MatrixMock64x64;
            wordsToFind = Mocks.MoreThan10WordStreamMock;

            finder = new WordFinder(matrix);
            weakFinder = new WeakWordFinder(matrix);
        }

        [Benchmark]
        public void FindWords()
        {
            finder.Find(wordsToFind);
        }

        [Benchmark]
        public void WeakWordFinder_Find()
        {
            weakFinder.Find(wordsToFind);
        }
    }
}
