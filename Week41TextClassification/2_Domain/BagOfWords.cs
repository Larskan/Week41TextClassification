using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week41TextClassification.Domain
{
    public class BagOfWords
    {
        //Keys are the words, values are the amounts
        readonly IDictionary<string, int> bagOfWords;

        public BagOfWords()
        {
            //Sorts the keys and values
            bagOfWords = new SortedDictionary<string, int>();
        }

        public void InsertEntry(string word)
        {
            word = word.Trim(); //Removes spaces
            if (word.Length == 0) //0 length means no words
            {
                return;
            }

            if (bagOfWords.ContainsKey(word)) //If the key contains a word
            {
                int count = bagOfWords[word]; //returns element with specified key
                count++;
                bagOfWords[word] = count; //updates count
            }
            else
            {
                bagOfWords.Add(word, 1);
            }
        }

        public ICollection<string> GetAllWordsInDictionary()
        {
            return bagOfWords.Keys; //keys being the words

        }

        //Sends string
        //Tommys version was a List<string> using Add(key+" "+bagOfWords[key]
        //By using List<WordItem> instead, we can Bind our Dictionary to our xaml through the WordItem
        public List<WordItem> GetEntriesInDictionary() //Uses WordItem to avoid using key too much
        {
            List<WordItem> entries = new List<WordItem>();
            foreach (string key in bagOfWords.Keys)
            {
                entries.Add(new WordItem(key, bagOfWords[key]));
            }
            return entries;
        }
    }
}
