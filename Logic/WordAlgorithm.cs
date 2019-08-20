using BluePrismTechnicalTest.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BluePrismTechnicalTest.Logic
{
    public class WordAlgorithm
    {
        private Parameters Parameters { get; set; }
        private Dictionary<KeyValuePair<string, int>, List<string>> WordsTree { get; set; }

        public WordAlgorithm(Parameters parameters)
        {
            Parameters = parameters;
            WordsTree = new Dictionary<KeyValuePair<string, int>, List<string>>();
        }

        public List<string> GetWordAlgorithmResult()
        {
            var topNodeLevel = GetAlgorithmResult();
            var result = GetWordListResult(topNodeLevel);

            return result;
        }

        private int GetAlgorithmResult()
        {
            // STEP I: Global initialization
            KeyValuePair<string, int> parentWord;
            var wordsQueue = new Queue<KeyValuePair<string, int>>();

            var wordList = new List<string>(Parameters.WordList);
            var tempWordList = new List<string>(Parameters.WordList);

            int currentNodeLevel;

            // Add EndWord to the Queue
            wordsQueue.Enqueue(new KeyValuePair<string, int>(Parameters.EndWord, 1));
            
            // While loop that takes in worst case scenario O(n)
            while (wordsQueue.Any())
            {
                // STEP II: Parent Node initialization
                // Set Parent Word and remove it from Queue
                parentWord = wordsQueue.First();
                wordsQueue.Dequeue();

                // Remove Parent Word from Queue
                tempWordList.Remove(parentWord.Key);

                // Reinitialize Word List
                wordList = new List<string>(tempWordList);

                // Add new Child List to the Parent Word on Current Tree Level
                WordsTree.Add(parentWord, new List<string>());

                // Foreach loop that takes in worst case scenario O(n - 1) - as each time we delete at least 1 Word from Word List
                foreach (var word in wordList)
                {
                    // STEP III: Check if next Word is valid i.e. if contains specified number of different Letters compared to Parent Word
                    // STEP III: Check takes O(m) where m is Word characters length
                    if (IsWordValid(parentWord.Key, word, Parameters.WordLetterDifferenceValue))
                    {
                        // STEP IV: Logic to Pop new valid word to the Queue for next iteration
                        // Set Current Tree Level
                        currentNodeLevel = (parentWord.Value + 1);

                        // Add Word to Queue and Tree (Child word)
                        wordsQueue.Enqueue(new KeyValuePair<string, int>(word, currentNodeLevel));
                        WordsTree[parentWord].Add(word);

                        // Remove Word from temp Word List to make sure it won't be checked ever again
                        tempWordList.Remove(word);

                        // If Start Word found then return
                        if (word == Parameters.StartWord)
                        {
                            return currentNodeLevel;
                        }
                    }
                }
            }

            return 0;
        }

        private bool IsWordValid(string firstWord, string secondWord, int wordLetterDifferenceValue)
        {
            var diffValue = 0;

            for (int i = 0; i < firstWord.Length; i++)
            {
                if (firstWord[i] != secondWord[i])
                {
                    diffValue++;
                }
            }

            return (diffValue == wordLetterDifferenceValue);
        }

        private List<string> GetWordListResult(int topNodeLevel)
        {
            var result = new List<string>();

            if(topNodeLevel > 0)
            {
                result.Add(Parameters.StartWord);

                for (int i = topNodeLevel - 1; i > 0; i--)
                {
                    var currentWordsTree = WordsTree.Where(r => r.Key.Value == i && r.Value.Any(v => v == result.Last()));

                    foreach (var word in currentWordsTree)
                    {
                        result.Add(word.Key.Key);
                    }
                }
            }
            else
            {
                result.Add("Tree path not found");
            }

            return result;
        }
    }
}
