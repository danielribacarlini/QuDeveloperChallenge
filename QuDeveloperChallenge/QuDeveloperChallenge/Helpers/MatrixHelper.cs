using QuDeveloperChallenge.CustomExceptions;

namespace QuDeveloperChallenge.Helpers
{
    public class MatrixHelper 
    {
        private IEnumerable<string> matrix;

        public MatrixHelper()
        {
            matrix = new List<string>();
        }

        public IEnumerable<string> CreateMatrix(string firstRow)
        {
            AddRow(firstRow);
            
            while (true)
            {
                Console.WriteLine("Please insert the follow line of the matrix, press enter when finished.");
                var row = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(row))
                {
                    break;
                }
                else
                {
                    AddRow(row);
                }
            }

            return matrix;
        }

        public void AddRow(string row)
        {
            if (!matrix.Any())
            {
                matrix = matrix.Append(row);
            }
            else
            {
                int firstRowLength = matrix.First().Length;

                if (row.Length == firstRowLength)
                {
                    matrix = matrix.Append(row);
                }
                else
                {
                    throw new InvalidMatrixRowLengthException($"The provided row does not have the required length of {firstRowLength} characters.");
                }
            }
        }

        public void DisplayMatrix(IEnumerable<string> matrix)
        {
            Console.WriteLine("\nMatrix where to search:");
            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }
        }

        public void ValidateMatrix(IEnumerable<string> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null.");

            var rows = matrix.ToList();

            if (rows.Count > 64)
                throw new InvalidMatrixSizeException("Matrix exceeds maximum allowed number of rows (64).");

            int expectedLength = rows.FirstOrDefault()?.Length ?? 0;

            if (expectedLength == 0)
                throw new EmptyMatrixRowException("Matrix cannot have empty rows.");

            if (expectedLength > 64)
                throw new InvalidMatrixSizeException("Matrix exceeds maximum allowed number of columns (64).");

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Length != expectedLength)
                {
                    throw new InvalidMatrixRowLengthException($"Row {i} length ({rows[i].Length}) does not match expected length ({expectedLength}).");
                }
            }
        }
    }
}
