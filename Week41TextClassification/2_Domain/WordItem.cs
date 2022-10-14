using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week41TextClassification.Helpers;

namespace Week41TextClassification.Domain
{
    public class WordItem : Bindable
    {
        
        //Tommys version changed from being placeholders to Bindings
        public WordItem(string words, int repeats)
        {
            Words = words;
            Repeats = repeats;

        }

        #region Getter and Setter for the Bindings
        private string words;
        public string Words
        {
            get { return words; }
            set { words = value; PropertyIsChanged(); }
        }

        private int repeats;
        public int Repeats
        {
            get { return repeats; }
            set { repeats = value; PropertyIsChanged(); }
        }
        #endregion



    }
}
