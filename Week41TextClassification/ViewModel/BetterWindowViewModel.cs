using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week41TextClassification.Controller;
using Week41TextClassification.Domain;
using Week41TextClassification.Helpers;
using Week41TextClassification.Foundation;
using System.IO;
using Week41TextClassification.Business;
using Week41TextClassification.FileIO;

namespace Week41TextClassification.ViewModel
{
    class BetterWindowViewModel : Bindable
    {
        public AddCommand Show { get; set; }
        public AddCommand Learn { get; set; }
        public AddCommand FilesView { get; set; }

        private KnowledgeBuilder kb;
        private BagOfWords bagOfWords;
        private Knowledge knowledge;

        #region attempt at showing Class files before training
        private ObservableCollection<string> _folderCollection; //Where ClassA and ClassB both are
        private ObservableCollection<string> _filesCollectionA; //ClassA
        private ObservableCollection<string> _filesCollectionB; //ClassB
        private FileAdapter _fileAdapter;

        #endregion

        private long training;

        private string filename;

        public string Filename
        {
            get { return filename; }
            set { filename = value; PropertyIsChanged(); }
        }

        public long Training
        {
            get { return training; }
            set { training = value; PropertyIsChanged(); }
        }

        private WordItem wordItem;

        public WordItem WordItem
        {
            get { return wordItem; }
            set { wordItem = value; PropertyIsChanged(); }
        }

        private ObservableCollection<string> listClassA = new ObservableCollection<string>();

        public ObservableCollection<string> ListClassA
        {
            get { return listClassA; }
            set { listClassA = value; PropertyIsChanged(); }
        }

        private ObservableCollection<string> listClassB = new ObservableCollection<string>();

        public ObservableCollection<string> ListClassB
        {
            get { return listClassB; }
            set
            {
                listClassB = value;
                PropertyIsChanged();
            }
        }

        private ObservableCollection<WordItem> listOfWordItems = new ObservableCollection<WordItem>();
        public ObservableCollection<WordItem> ListOfWordItems
        {
            get { return listOfWordItems; }
            set
            {
                listOfWordItems = value;
                PropertyIsChanged();
            }
        }

        #region attempt at showing Class Files before training
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

        public BetterWindowViewModel()
        {
            Learn = new AddCommand(StartLearning);
            Show = new AddCommand(GetFileInfo);
            FilesView = new AddCommand(ShowFiles);
        }

        //Training, binded to button in GUI
        private void StartLearning(object parameter)
        {
            kb = new KnowledgeBuilder();
            //initiate
            kb.Train();
            //getting all knowledge
            knowledge = kb.GetKnowledge();
            //get part of knowledge
            bagOfWords = knowledge.GetBagOfWords();
            ListOfWordItems = new ObservableCollection<WordItem>(bagOfWords.GetEntriesInDictionary());

            GetFileNames();

        }


        private void GetFileNames()
        {
            //Clear incase I view the files before training
            ListClassA.Clear();
            //Go through listA of file and compare to current displayed file
            for (int i = 0; i < knowledge.GetFileLists().GetA().Count; i++)
            {
                if (!ListClassA.Contains(StringOperations.getFileName(knowledge.GetFileLists().GetA()[i])))
                    ListClassA.Add(StringOperations.getFileName(knowledge.GetFileLists().GetA()[i]));
            }

            ListClassB.Clear();
            //Go through listB of file and compare to current displayed file
            for (int j = 0; j < knowledge.GetFileLists().GetB().Count; j++)
            {
                if (!ListClassB.Contains(StringOperations.getFileName(knowledge.GetFileLists().GetB()[j])))
                    ListClassB.Add(StringOperations.getFileName(knowledge.GetFileLists().GetB()[j]));
            }
        }

        //Go through both lists stored in Knowledge.
        //Use the path stored to compare the file name to name stored in list
        //When match is found, new string is made of all the words in the file using File.ReadAllText
        //New string is sent to Tokenization.Tokenize to filter the words
        //Improved list with just words is added to new BagOfWords object which is used for new ObservableCollection for listview
        private void GetFileInfo(object parameter)
        {
            if (knowledge == null)
            {
                return;
            }
            //New BagOfWords to contain words
            BagOfWords bagOfWordsLocal = new BagOfWords();
            string text = "";
            //iterate through list of paths to check each file
            for (int i = 0; i < knowledge.GetFileLists().GetA().Count; i++)
            {
                //Check file with file name in the list of paths, if they match, read file and add to string
                if (Filename == StringOperations.getFileName(knowledge.GetFileLists().GetA()[i]))
                    text = File.ReadAllText(knowledge.GetFileLists().GetA()[i]);
            }
            //iterate through list of paths to check each file
            for (int j = 0; j < knowledge.GetFileLists().GetB().Count; j++)
            {
                //Check file with file name in the list of paths, if they match, read file and add to string
                if (Filename == StringOperations.getFileName(knowledge.GetFileLists().GetB()[j]))
                    text = File.ReadAllText(knowledge.GetFileLists().GetB()[j]);

            }

            //List of words using Tokenization
            List<string> wordsInFile = Tokenization.Tokenize(text);

            //go through list and add words to bag
            foreach (string word in wordsInFile)
            {
                bagOfWordsLocal.InsertEntry(word);
            }

            //new ObservableColl with list from Bag
            ListOfWordItems = new ObservableCollection<WordItem>(bagOfWordsLocal.GetEntriesInDictionary());
        }

        private void ShowFiles(object parameter)
        {
            //Current progress: No errors, however it shows the PROJECTPATH instead of the Classes
            _fileAdapter = new TextFile("txt", "pdf");

            //Has been binded in the xaml
            ListClassA = new ObservableCollection<string>(_fileAdapter.GetAllFileNames("ClassA"));
            ListClassB = new ObservableCollection<string>(_fileAdapter.GetAllFileNames("ClassB"));

        }


    }
}
