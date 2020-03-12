using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anagram;
using System.Collections.Generic;

namespace AnagramTests
{
    [TestClass]
    public class AnagramTests
    {
        [TestMethod]
        public void SearchAnagramInWordListOnWordTest()
        {
            AnagramWorker anagram = new AnagramWorker();

            String testWord = "parsley";
            List<String> words = GetTestWordsList();

            anagram.SetList(words);
            List<String> anagrams = anagram.FindOnWord(testWord);

            Assert.AreEqual(4, anagrams.Count);

            Assert.AreEqual(true, anagrams.Contains("players"));
            Assert.AreEqual(true, anagrams.Contains("replays"));
            Assert.AreEqual(true, anagrams.Contains("sparely"));
            Assert.AreEqual(true, anagrams.Contains("parsley"));
        }
        private List<String> GetTestWordsList()
        {
            return new List<String>
            {
                "parsley",
                "iopland",
                "boaster",
                "players",
                "replays",
                "boaters",
                "sparely",
                "utiturn",
                "borates"
            };
        }

        [TestMethod]
        public void SearchAllAnagramsInWordListTest()
        {
            AnagramWorker anagram = new AnagramWorker();

            anagram.SetList(GetTestWordsList());

            List<List<String>> anagramsList = anagram.FindAllAnagrams();

            Assert.AreEqual(4, anagramsList.Count);
            Assert.AreEqual(4 , anagramsList[0].Count);
            Assert.AreEqual(1 , anagramsList[1].Count);
            Assert.AreEqual(3 , anagramsList[2].Count);
            Assert.AreEqual(1 , anagramsList[3].Count);
        }

        [TestMethod]
        public void FindMostLengthAnagramsInAnagramsListTest()
        {
            AnagramWorker anagram = new AnagramWorker();

            anagram.SetList(GetTestWordsList());

            List<List<String>> anagramsList = anagram.FindAllAnagrams();

            var mostLengthanagrams = anagram.FindMostLengthAnagramsInAnagramsList(anagramsList);

            Assert.AreEqual("parsley", mostLengthanagrams[0]);
        }

        [TestMethod]
        public void SeeAllAnagramsInFile()
        {
            ReadFile file = new ReadFile();
            var wordsList = file.ReadWordsFromFile("words list.txt");

            AnagramWorker anagramWorker = new AnagramWorker();

            anagramWorker.SetList(wordsList);
            var allAnagrams = anagramWorker.FindAllAnagrams();
        }
        private void PrintAllAnagramsInList(List<List<String>> anagramsList)
        {
            foreach (List<String> anagrams in anagramsList)
            {
                foreach (String anagram in anagrams)
                {
                    Console.WriteLine(anagram);
                }
            }
        }
        
    }
}
