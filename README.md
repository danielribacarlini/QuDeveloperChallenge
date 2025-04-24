# Word Finder Challenge

## Objective
This project addresses the Word Finder developer challenge, where the goal is to find and return the top 10 most frequent words from a word stream that are found in a given matrix of characters. The words can appear in horizontal (left to right) or vertical (top to bottom) directions.

## Highlights
- Written in C# (.NET)
- High-performance search using character position indexing with `HashSet<int>` for O(1) lookups
- Zero-allocation substring checks using `ReadOnlySpan<char>`
- Handles matrix size up to 64x64
- Ignores repeated words in the word stream (uniqueness enforced before search)
- Includes a console interface for custom input or using mock data

## Design & Performance Considerations

- **Matrix Indexing via HashSet**
  During construction, the matrix is transformed into a `Dictionary<char, HashSet<int>>` where each character maps to a set of its positions (as flattened 1D indices) in the matrix.
  This significantly accelerates search:

  - `HashSet<int>` enables **constant-time lookup** for verifying if a letter is present at a specific position.
  - This replaces the original `Array.BinarySearch` approach with a faster and simpler lookup strategy.

- **Recursive Search in 4 Directions**
  For each starting position of the first letter, the algorithm recursively explores four directions:

  - Right →
  - Left ←
  - Down ↓
  - Up ↑
    While ensuring boundaries are respected (no wrapping across matrix edges).

- **Zero-Allocation String Slicing**\
  The implementation uses `ReadOnlySpan<char>` for efficient, allocation-free manipulation of word substrings during recursive traversal.

- **Word Stream Filtering**
  Before search begins, input words are filtered via `.Distinct()` to ensure uniqueness and avoid redundant computation.

- **Memory Efficiency**
  The use of `IEnumerable<string>` and streaming results minimizes memory usage and improves scalability for large input sets.

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
- UI wrapper or API exposure

## Author
Developed for a technical challenge. For any questions or improvements, please reach out.