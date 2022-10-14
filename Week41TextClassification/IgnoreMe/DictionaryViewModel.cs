using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week41TextClassification.Helpers;

namespace Week41TextClassification.Leftovers
{
    public class DictionaryViewModel : Bindable
    {
        private static ObservableCollection<string> _dictionary = new ObservableCollection<string>();
        private string _wordAmount; //Or tokens
        private string _selectedString;

        public DictionaryViewModel()
        {
            //Uses the WordAmount Binding. Counts the items within the Dictionary, then links it with WordAmount through xaml Binding
            WordAmount = "Dimension/Dictionary Length: " + Dictionary.Count(); //e)
        }

        #region Get and Set for SelectedString and WordAmount and Dictionary Binding

        //Links with MainWindowViewModel to both clear it and to add the entries to the ListBox through Binding
        //Dictionary is a collection that stores Key and Value pairs
        //In this case, our keys are Words and the Values are amount of times a words is used
        public static ObservableCollection<string> Dictionary //Binding
        {
            set { _dictionary = value; } //The entire dictionary, Value here is a string which are the words inside Dictionary
            get { return _dictionary; }
        }
        public string SelectedString // Binding. Value here is words too
        {
            set { _selectedString = value; PropertyIsChanged(); }
            get { return _selectedString; }
        }
        public string WordAmount //Count. Binding. Value here is a converted string, but it is a number of times words are present
        {
            set { _wordAmount = value; PropertyIsChanged(); }
            get { return _wordAmount; }
        }
        #endregion
    }
}
