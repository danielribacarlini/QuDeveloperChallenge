using QuDeveloperChallenge;
using QuDeveloperChallenge.Helpers;

var matrixHelper = new MatrixHelper();
var wordStreamHelper = new WordStreamHelper();

IEnumerable<string> matrix;
IEnumerable<string> wordStream;

try
{    
    Console.WriteLine("Please insert rows for the matrix where to search, press enter if you want to use in memory one");
    var matrixline = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(matrixline))
        matrix = matrixHelper.CreateMatrix(matrixline);
    else
        matrix = Mocks.MatrixMock64x64;

    Console.WriteLine("Please insert words to search, press enter if you want to use in memory ones");
    var wordStreamLine = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(wordStreamLine))
        wordStream = wordStreamHelper.CreateWordStream(wordStreamLine);
    else
        wordStream = Mocks.MoreThan10WordStreamMock;

    matrixHelper.DisplayMatrix(matrix);
    wordStreamHelper.DisplayWordStream(wordStream);

    var wordFinder = new WordFinder(matrix);

    wordFinder.DisplayMactches(wordFinder.Find(wordStream));
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error: {ex.Message}");
    Console.ResetColor();
    Console.WriteLine("Please try again.\n");
}







