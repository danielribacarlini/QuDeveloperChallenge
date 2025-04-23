using QuDeveloperChallenge.CustomExceptions;

namespace QuDeveloperChallenge.Tests
{
    public class WordFinderTests
    {
        [Fact]
        public void Find_ShouldReturnEmpty_WhenNoWordsMatch()
        {
            // Arrange
            var matrix = new List<string>
            {
                "abc",
                "def",
                "ghi"
            };

            var wordStream = new List<string> { "xyz", "lmn", "opq" };
            
            var wordFinder = new WordFinder(matrix);

            // Act
            var result = wordFinder.Find(wordStream);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Find_ShouldReturnMatchedWords_WhenTheyAreInMatrix()
        {
            // Arrange
            var matrix = new List<string>
            {
                "coldd",
                "rainn",
                "heatu",
                "dniws"
            };

            var wordStream = new List<string> { "cold", "wind", "heat", "sun" };
            var wordFinder = new WordFinder(matrix);

            // Act
            var result = wordFinder.Find(wordStream);

            // Assert
            Assert.Contains("cold", result);
            Assert.Contains("wind", result);
            Assert.Contains("heat", result);
            Assert.Contains("sun", result);
        }

        [Fact]
        public void Find_ShouldNotReturnRowSplitedWords_WhenTheyAreInMatrix()
        {
            // Arrange
            var matrix = new List<string>
            {
                "xxxxco",
                "ldxxxx",
                "xxxxni",
                "arxxxx"
            };

            var wordStream = new List<string> { "cold", "rain" };
            var wordFinder = new WordFinder(matrix);

            // Act
            var result = wordFinder.Find(wordStream);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Find_ShouldIgnoreDuplicatesInWordStream()
        {
            // Arrange
            var matrix = new List<string>
            {
                "cold",
                "wind",
                "cold",
                "wind"
            };

            var wordStream = new List<string> { "cold", "cold", "wind", "wind" };
            var wordFinder = new WordFinder(matrix);

            // Act
            var result = wordFinder.Find(wordStream);

            // Assert
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Contains("cold", resultList);
            Assert.Contains("wind", resultList);
        }

        [Fact]
        public void Find_ShouldReturnOneLetterWordsFounded()
        {
            // Arrange
            var matrix = Mocks.MatrixMock30x30;

            var wordStream = Mocks.WordStreamMockOneLetters;

            var wordFinder = new WordFinder(matrix);

            // Act
            var result = wordFinder.Find(wordStream);

            // Assert           
            Assert.Equal(5, result.Count());
            Assert.Contains("a", result);
            Assert.Contains("b", result);
            Assert.Contains("c", result);
            Assert.Contains("d", result);
            Assert.Contains("e", result);
        }

        [Fact]
        public void Find_ShouldReturnTop10MostFrequentWords()
        {
            // Arrange
            var matrix = Mocks.MatrixMock64x64;

            var wordStream = Mocks.MoreThan10WordStreamMock;

            var wordFinder = new WordFinder(matrix);

            // Act
            var result = wordFinder.Find(wordStream);

            // Assert
            Assert.True(result.Count() <= 10);
            Assert.Contains("daniele", result);  // 6 occurrences  times in the matrix mock
            Assert.Contains("juan", result); // 5 occurrences
            Assert.Contains("saturday", result); // 4 occurrences
            Assert.Contains("julian", result); // 4 occurrences
            Assert.Contains("pedro", result); // 3 occurrences
            Assert.Contains("hector", result); // 2 occurrences
            Assert.Contains("sky", result); // 2 occurrences
            Assert.Contains("cloud", result); // 2 occurrences
            Assert.Contains("wind", result); // 2 occurrences
            Assert.Contains("sun", result); // 2 occurrences
        }

        [Fact]
        public void Constructor_ShouldBuildCorrectly_WhenValidMatrix()
        {
            // Arrange
            var matrix = new List<string>
            {
                "abc",
                "def",
                "ghi"
            };

            // Act & Assert
            var exception = Record.Exception(() => new WordFinder(matrix));
            Assert.Null(exception);
        }

        [Fact]
        public void Constructor_ThrowsInvalidMatrixSizeException_WhenMatrixIsTooLarge()
        {
            // Arrange: 65 rows of 65 characters (exceeds 64x64)
            var largeMatrix = Mocks.MatrixMock65x65;

            // Act & Assert
            Assert.Throws<InvalidMatrixSizeException>(() =>
            {
                var wordFinder = new WordFinder(largeMatrix);
            });
        }
    }
}