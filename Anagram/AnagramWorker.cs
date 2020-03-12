using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram
{
    public class AnagramWorker
    {
        private List<String> words = new List<String>();

        public void SetList(List<String> words)
        {
            this.words = words;
        }

        public List<String> FindOnWord(String word)
        {
            List<String> searchWords = new List<String>();
            String sortWord = SortLettersInWord(word);

            foreach (String existWord in words)
            {
                String sortExistWord = SortLettersInWord(existWord);

                if (sortWord == sortExistWord)
                {
                    searchWords.Add(existWord);
                }
            }

            return searchWords;
        }


        public List<List<String>> FindAllAnagrams()
        {
            List<String> words = CreateCopyWords(this.words);

            return FindAndDeleteAllEnteringAnagrams(words);
        }
        private List<List<String>> FindAndDeleteAllEnteringAnagrams(List<String> words)
        {
            List<List<String>> allAnagrams = new List<List<String>>();

            while (words.Count != 0)
            {
                allAnagrams.Add(FindAndDeleteFirstEnteringAnagrams(words));
            }

            return allAnagrams;
        }
        private List<String> FindAndDeleteFirstEnteringAnagrams(List<String> words)
        {
            List<String> anagramsList = new List<String>();
            List<String> wordsWithSortedLetters = CreateCopyWordsWithSortedLetters(words);

            anagramsList.Add(words[0]);
            Int32 indexVerifiableWord = 1;

            while (indexVerifiableWord < wordsWithSortedLetters.Count)
            {
                if (wordsWithSortedLetters[0] == wordsWithSortedLetters[indexVerifiableWord])
                {
                    anagramsList.Add(words[indexVerifiableWord]);
                    words.RemoveAt(indexVerifiableWord);
                    wordsWithSortedLetters.RemoveAt(indexVerifiableWord);
                    continue;
                }

                indexVerifiableWord++;
            }

            words.RemoveAt(0);
            return anagramsList;
        }

        private List<String> CreateCopyWordsWithSortedLetters(List<String> words)
        {
            return SortLettersInWordsList(CreateCopyWords(words));
        }

        private List<String> CreateCopyWords(List<String> words)
        {
            var copyWords = new List<String>();

            foreach (String word in words)
            {
                copyWords.Add(word);
            }
            return copyWords;
        }

        private List<String> SortLettersInWordsList(List<String> words)
        {
            List<String> sortedWords = new List<String>();

            foreach (String word in words)
            {
                sortedWords.Add(SortLettersInWord(word));
            }

            return sortedWords;
        }
        private String SortLettersInWord(String word)
        {
            StringBuilder wordBuilder = new StringBuilder();

            var letters = from letter in word
                          orderby letter
                          select letter;

            foreach (Char letter in letters)
            {
                wordBuilder.Append(letter);
            }

            return wordBuilder.ToString();
        }

        public List<String> FindMostLengthAnagramsInAnagramsList(List<List<String>> anagramsSet)
        {
            List<String> findAnagrams = new List<String>();
            Int32 anagramLength = 0;

            foreach (List<String> anagrams in anagramsSet)
            {
                if(anagrams[0].Length > anagramLength)
                {
                    anagramLength = anagrams[0].Length;
                    findAnagrams = anagrams;
                }
            }
            return findAnagrams; 
        }

    }
}
