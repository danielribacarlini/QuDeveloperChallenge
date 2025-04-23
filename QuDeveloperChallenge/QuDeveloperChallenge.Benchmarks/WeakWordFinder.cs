using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuDeveloperChallenge.Benchmarks
{
    public class WeakWordFinder
    {
        private readonly HashSet<string> _matrixWords;

        public WeakWordFinder(IEnumerable<string> matrix)
        {
            _matrixWords = new HashSet<string>();
            int size = matrix.Count();

            // Guardar horizontales
            foreach (var row in matrix)
                _matrixWords.Add(row);

            // Guardar verticales
            for (int col = 0; col < matrix.First().Length; col++)
            {
                var verticalWord = new StringBuilder();
                foreach (var row in matrix)
                    verticalWord.Append(row[col]);

                _matrixWords.Add(verticalWord.ToString());
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var uniqueWords = wordstream.Distinct();
            var wordCount = new Dictionary<string, int>();

            foreach (var word in uniqueWords)
            {
                int count = 0;

                foreach (var line in _matrixWords)
                {
                    int index = line.IndexOf(word);
                    while (index != -1)
                    {
                        count++;
                        index = line.IndexOf(word, index + 1);
                    }
                }

                if (count > 0)
                    wordCount[word] = count;
            }

            return wordCount
                .OrderByDescending(kvp => kvp.Value)
                .Take(10)
                .Select(kvp => kvp.Key);
        }
    }
}
