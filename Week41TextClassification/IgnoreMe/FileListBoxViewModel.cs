using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week41TextClassification.Business;
using Week41TextClassification.FileIO;
using Week41TextClassification.Helpers;

namespace Week41TextClassification.Leftovers
{
    public class FileListBoxViewModel : Bindable
    {
        #region Declarations
        private ObservableCollection<string> _folderCollection; //Where ClassA and ClassB both are
        private ObservableCollection<string> _filesCollectionA; //ClassA
        private ObservableCollection<string> _filesCollectionB; //ClassB
        private string _selectedString;
        private string _textInsideFile; //If select file, show the text
        private string _wordAmount; //Obvious
        private FileAdapter _fileAdapter;
        #endregion

        public FileListBoxViewModel()
        {
            _fileAdapter = new TextFile("txt", "pdf"); //txt is the filetype it will accept

            //Has been binded in the xaml
            FilesCollectionA = new ObservableCollection<string>(_fileAdapter.GetAllFileNames("ClassA"));
            FilesCollectionB = new ObservableCollection<string>(_fileAdapter.GetAllFileNames("ClassB"));
        }

        #region Get and Set for Bindings
        public string SelectedString
        {
            get { return _selectedString; }
            set
            {
                //Goes through FileAdapter to TextFile where Path data is
                TextInsideFile = _fileAdapter.GetAllTextFromFileA(value);
                _selectedString = value;
                PropertyIsChanged();
            }
        }
        public string TextInsideFile
        {
            get { return _textInsideFile; }
            set
            {
                _textInsideFile = value;
                //Tokenize is where it removes punctuation from the words and makes them lower case
                WordAmount = "Number of Words: " + Tokenization.Tokenize(value).Count();
                PropertyIsChanged();
            }
        }
        public string WordAmount
        {
            set { _wordAmount = value; PropertyIsChanged(); }
            get { return _wordAmount; }
        }
        public ObservableCollection<string> FolderCollection
        {
            set { _folderCollection = value; PropertyIsChanged(); }
            get { return _folderCollection; }
        }

        public ObservableCollection<string> FilesCollectionA
        {
            set { _filesCollectionA = value; PropertyIsChanged(); }
            get { return _filesCollectionA; }
        }
        public ObservableCollection<string> FilesCollectionB
        {
            set { _filesCollectionB = value; PropertyIsChanged(); }
            get { return _filesCollectionB; }
        }
        #endregion
    }
}
