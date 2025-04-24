using QuDeveloperChallenge.Helpers;

namespace QuDeveloperChallenge
{
    public class WordFinder 
    {
        private readonly Dictionary<char, HashSet<int>> chartDictionary;
        private readonly List<(string, int)> wordsCount;
        private readonly int columns;

        private readonly MatrixHelper matrixHelper = new MatrixHelper();

        public WordFinder(IEnumerable<string> matrix)
        {
            matrixHelper.ValidateMatrix(matrix);
            
            columns = matrix.First().Length;

            // Calculating all ocurrences of each leter and its position. This will help to find each word in a more efficient way
            chartDictionary = matrix.SelectMany((row, rIndex) => row.Select((character, cIndex) => new { Character = character, Position = rIndex * columns + cIndex }))
                .GroupBy(c => c.Character, c => c.Position)
                // Coverting the matrix to this Dictionary will help to find each letter faster, using a hashset insted of an array is going to be much more performant.
                .ToDictionary(c => c.Key, c => c.Order().ToHashSet());

            wordsCount = [];
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            // We only need no repeated words
            var uniqueWords = wordstream.Distinct();

            foreach (var word in uniqueWords.Where(w => !string.IsNullOrWhiteSpace(w)))
            {
                var letters = word.AsSpan();

                // Looking for the first letter of the current word in the dictionary. If it is not, we procced with the following
                var firstLetter = letters[0];
                if (!chartDictionary.ContainsKey(firstLetter))
                    continue;
                
                var letterPositions = chartDictionary[firstLetter];

                int wordCount = 0;

                // If the word that we are looking have only one letter, we count its ocurrences. Otherwise we check followings letters in letters array (letters[1..])
                if (letters.Length == 1 && letterPositions.Count >=1)
                {
                    wordCount += letterPositions.Count;
                }
                else
                {
                    // We will call Explore recursive method foreach ocurrence of firsts letters, and we will do for 4 posibles directions...
                    foreach (var initialPosition in letterPositions)
                    {
                        var slice = letters[1..];
                        wordCount += Explore(slice, initialPosition, 1, 0); //to the right for x=1
                        wordCount += Explore(slice, initialPosition, 0, 1); //upwards for y=1
                        wordCount += Explore(slice, initialPosition, -1, 0); //to the left for x=-1
                        wordCount += Explore(slice, initialPosition, 0, -1); //downwards for y=-1
                    }
                }

                wordsCount.Add((word, wordCount));
            }

            // Taking first 10 most repeates words
            return wordsCount
                .Where(w => w.Item2 > 0)
                .OrderByDescending(w => w.Item2)
                .Take(10)
                .Select(w => w.Item1);
        }

        private int Explore(ReadOnlySpan<char> letters, int currentPosition, int x, int y)
        {            
            // Letter to search
            char searchedLetter = letters[0];

            // Getting all positions for a searched letter and put it into position HashSet
            // If the letter isn't in the whole matrix, I won't keep looking, I won't find it
            if (!chartDictionary.TryGetValue(searchedLetter, out HashSet<int>? positions))
                return 0;

            // Apply the direction vector to get expected position
            int expectedPosition = currentPosition + x + y * columns;

            // Checking if the expected position is in the hashset will be very performant.
            if (!positions.Contains(expectedPosition))
                return 0;

            var followingSearch = letters[1..];

            // Closing condition (when there are no more letters left to search for)
            if (followingSearch.Length == 0)
                return 1;

            // If we are exploring horizontally, we don't have to jump from one row to another, 
            // that is for the begining and the end positions of each row
            if (x > 0 && expectedPosition % columns == 0)
                return 0;

            if (x < 0 && currentPosition % columns == 0)
                return 0;

            // Calling itself until there is no letter to search
            return Explore(followingSearch, expectedPosition, x, y);
        }

        public void DisplayMactches(IEnumerable<string> matches)
        {
            Console.WriteLine("\nFound words");

            foreach (var word in matches)
            {
                Console.WriteLine(word);
            }
        }
    }
}
