namespace QuDeveloperChallenge.Helpers
{  
    public class WordStreamHelper 
    {
        private IEnumerable<string> wordStream; 
       
        public WordStreamHelper()
        {
            wordStream = new List<string>();
        }
        
        public IEnumerable<string> CreateWordStream(string firstWord)
        {
            wordStream = wordStream.Append(firstWord);

            while (true)
            {
                Console.WriteLine("Please enter following word to search, press enter when finished.");
                var row = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(row))
                {
                    break;
                }
                else
                {
                    wordStream = wordStream.Append(row);
                }
            }

            return wordStream;
        }

        public void DisplayWordStream(IEnumerable<string> wordStream)
        {
            Console.WriteLine("\nWords to search:");
            DisplayWords(wordStream);
        }

        public void DisplayMatches(IEnumerable<string> matches)
        {
            Console.WriteLine("\nFound words");
            DisplayWords(matches);
        }

        private void DisplayWords(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
