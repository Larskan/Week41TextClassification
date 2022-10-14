using iText.Kernel.Pdf.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Porter2StemmerStandard;
using Week41TextClassification.Leftovers;

namespace Week41TextClassification.Business
{
    public class Tokenization

    {
        //Tokenizer takes a sequence of characters and output a sequence of tokens
        //You create a list of regex patterns and associate each to a word
        //Then iterate through query text character by character checking if text at current location matches a pattern
        //If it matches a pattern, we create the words, create a new string cutting out the match text and continue checking
        //If it doesnt match a pattern, we create a new string cutting out the current character and check again
        private const int SMALLESTWORDLENGTH = 3;

        public static List<string> Tokenize(string originalText)
        {
            List<string> words = new List<string>();
            //Splits a string into substring and returns array that contains the substrings
            string[] tokens = originalText.Split(' '); 

            foreach (string token in tokens)
            {
                if (IsAShortWord(token)){}
                else
                {
                    string cleanWord = RemovePunctuation(token);
                    cleanWord = cleanWord.ToLower();
                    // \\d+ = Matches a string that has a backslash followed by the letter 
                    // A-Z = upper case
                    // a-z = letters
                    // ^' = begin with '
                    // ^´ = begin with ´
                    // ^` = begin with `
                    // ^’ = begin with ’
                    // | = any of whatever is within ()
                    string[] allWords = Regex.Split(cleanWord, "(\\d+|[A-Za-z^'^´^`^’]+)|, ");
                    foreach(string item in allWords)
                    {
                        //If all spaces are gone, add the words
                        if(item != "" && item != " ")
                        {
                            words.Add(item);
                        }
                    }                    
                }
            }
            return words;
        }
        public static bool IsAShortWord(string token)
        {
            if (token.Length < SMALLESTWORDLENGTH){return true;}
            return false;
        }
        public static string RemovePunctuation(string word)
        {
            //Trim space from words
            word = word.Trim();
            
            char[] punctuations = { '.', ',', '"', '?', '\n', ';', '!', ':', '/', '_', '*', '@', '$', '(', ')', '£', '%', '[', ']','-'  };
            //Char array from words
            char[] tokenChar = word.ToCharArray();
            //Create words we will be returning
            string returnWord = "";

            //Go through the symbols to remove
            for (int i = 0; i < punctuations.Length; i++)
            {
                char symbol = punctuations[i];

                //Go through each char to see if they match the symbol, and if they do, replace with a space
                for (int j = 0; j < tokenChar.Length; j++)
                {
                    if (tokenChar[j].Equals(symbol))
                    {
                        tokenChar[j] = ' ';
                    }
                }
            }
            //make the char array to string
            returnWord = new string(tokenChar);
            //Use regex to remove all spaces and numbers from string to make sure only words are present
            returnWord = Regex.Replace(returnWord, @"\s+", "");
            returnWord = Regex.Replace(returnWord, @"\d+", "");

            //Porter2 p2 = new Porter2();
            //p2.stem(returnWord);

            //return the finished string
            return returnWord;
        }

       
    }
}