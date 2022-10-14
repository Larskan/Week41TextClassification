using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week41TextClassification.Domain;
using Week41TextClassification.Business;
using Week41TextClassification.FileIO;

namespace Week41TextClassification.Controller
{
    public class KnowledgeBuilder : AbstractKnowledgeBuilder
    {
        private Knowledge _knowledge; // the composite object

        private FileLists _fileLists;
        //private PdfLists _pdfLists;
        private BagOfWords _bagOfWords;
        private Vectors _vectors;

        private FileAdapter _fileAdapter;
        //private PdfAdapter _pdfAdapter;

        public KnowledgeBuilder()
        {
            _fileAdapter = new TextFile("txt","pdf");
            //_pdfAdapter = new TextFile("pdf");
            _knowledge = new Knowledge();
        }

        public override void BuildFileLists()
        {

            FileListBuilder flb = new FileListBuilder();

            flb.GenerateFileNamesInA();

            flb.GenerateFileNamesInB();

            _fileLists = flb.GetFileLists();
            _knowledge.SetFileLists(_fileLists);
        }
        
        /*
        public override void BuildPdfLists()
        {
            PdfListBuilder pdflb = new PdfListBuilder();
            pdflb.GenerateFileNamesInA();
            pdflb.GenerateFileNamesInB();
            _pdfLists = pdflb.GetPdfLists();
            _knowledge.GetPdfLists(_pdfLists);
        }
        */
        

        public override void Train()
        {
            // (1) 
            BuildFileLists();
            // (1.1)
            //BuildPdfLists();
            // (2)
            BuildBagOfWords();
            // (3)
            BuildVectors();
        }

        private void AddToBagOfWords(string folderName)
        {
            List<string> list;
            if (folderName.Equals("ClassA"))
            {
                list = _fileLists.GetA();
                //list = _pdfLists.GetA();
            }
            else
            {
                list = _fileLists.GetB();
                //list = _pdfLists.GetB();
            }
            for (int i = 0; i < list.Count; i++)
            {
                string text;

                if (folderName.Equals("ClassA"))
                {
                    text = _fileAdapter.GetAllTextFromFileA(list[i]);
                }
                else
                {
                    text = _fileAdapter.GetAllTextFromFileB(list[i]);
                }
                List<string> wordsInFile = Tokenization.Tokenize(text);

                foreach (string word in wordsInFile)
                {
                    _bagOfWords.InsertEntry(word);
                }
            }
        }
        /*
        private void AddToBagOfWordsPdf(string folderName)
        {
            List<string> list;
            if (folderName.Equals("ClassA"))
            {
                list = _pdfLists.GetA();
            }
            else
            {
                list = _pdfLists.GetB();
            }
            for(int i = 0; i < list.Count; i++)
            {
                string text;
                if (folderName.Equals("ClassA"))
                {
                    
                }
            }
        }
        */

        public override void BuildBagOfWords()
        {
            if (_fileLists == null)
            {
                BuildFileLists();
            }
            _bagOfWords = new BagOfWords();

            AddToBagOfWords("ClassA");
            AddToBagOfWords("ClassB");

            _knowledge.SetBagOfWords(_bagOfWords);
        }

        private void AddToVectors(string folderName, VectorsBuilder vectorsBuilder)
        {
            List<string> list;


            if (folderName.Equals("ClassA"))
            {
                list = _fileLists.GetA();
            }
            else
            {
                list = _fileLists.GetB();
            }
            for (int i = 0; i < list.Count; i++)
            {
                List<bool> vector = new List<bool>();
                foreach (string key in _bagOfWords.GetAllWordsInDictionary())
                {
                    string text;
                    if (folderName.Equals("ClassA"))
                    {
                        text = _fileAdapter.GetAllTextFromFileA(_fileLists.GetA()[i]);
                    }
                    else
                    {
                        text = _fileAdapter.GetAllTextFromFileB(_fileLists.GetA()[i]);
                    }
                    List<string> wordsInFile = Tokenization.Tokenize(text);
                    if (wordsInFile.Contains(key))
                    {
                        vector.Add(true);
                    }
                    else
                    {
                        vector.Add(false);
                    }
                }
                if (folderName.Equals("ClassA"))
                {
                    vectorsBuilder.AddVectorToA(vector);
                }
                else
                {
                    vectorsBuilder.AddVectorToB(vector);
                }
            }
        }

        public override void BuildVectors()
        {
            if (_fileLists == null)
            {
                BuildFileLists();
            }
            if (_bagOfWords == null)
            {
                BuildBagOfWords();
            }
            _vectors = new Vectors();
            VectorsBuilder vectorsBuilder = new VectorsBuilder();
            AddToVectors("ClassA", vectorsBuilder);
            AddToVectors("ClassB", vectorsBuilder);

            _vectors = vectorsBuilder.GetVectors();
            _knowledge.SetVectors(_vectors);
        }

        public override Knowledge GetKnowledge()
        {
            return _knowledge;
        }
    }
}
