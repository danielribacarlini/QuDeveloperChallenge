# Word Finder Challenge

## Objective
This project addresses the Word Finder developer challenge, where the goal is to find and return the top 10 most frequent words from a word stream that are found in a given matrix of characters. The words can appear in horizontal (left to right) or vertical (top to bottom) directions.

## Highlights
- Written in C# (.NET)
- Efficient search using precomputed character position indexing and binary search
- Handles matrix size up to 64x64
- Ignores repeated words in the word stream (uniqueness enforced before search)
- Includes a console interface for custom input or using mock data

## Design & Performance Considerations

- **Matrix Indexing**: During construction, the matrix is transformed into a `Dictionary<char, int[]>` where each character maps to a sorted array of linear positions in the matrix. This significantly accelerates search by allowing binary search to validate each step.
- **Recursive Search**: The algorithm checks 4 directions (right, left, down, up) recursively, maintaining boundary constraints and validating each character via `Array.BinarySearch`.
- **Memory Efficiency**: By using `IEnumerable<string>` and avoiding unnecessary copies or allocations, the implementation stays performant.
- **Stream Filtering**: Words are de-duplicated using `Distinct()` before processing.

## Usage

To run the application:
1. Build the solution in your .NET IDE (e.g., Visual Studio or `dotnet build`).
2. Execute the compiled application.
3. Follow the prompts to input a custom matrix and word stream, or press Enter to use built-in mock data.

## Example

**Input Matrix:**
```
cold
wind
warm
heat
```

**Input Word Stream:**
```
cold
wind
hot
chill
cold
```

**Output:**
```
Found words:
cold
wind
```

## File Structure

- `Program.cs`: Entry point. Manages input, output, and error handling.
- `WordFinder.cs`: Core logic for searching the matrix.
- `MatrixHelper.cs`: Handles user input and display for the matrix.
- `WordStreamHelper.cs`: Handles user input and display for the word stream.
- `InvalidMatrixRowLengthException.cs`: Custom exception for matrix validation.

## Future Improvements

- Add support for diagonal word searches
- Unit testing using xUnit or NUnit
- Benchmarking performance with large matrices and word streams
- UI wrapper or API exposure

## Author
Developed for a technical challenge. For any questions or improvements, please reach out.