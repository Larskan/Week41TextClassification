using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week41TextClassification.Domain;
using Week41TextClassification.FileIO;


namespace Week41TextClassification.Controller
{
    public class FileListBuilder : AbstractFileListsBuilder
    {
        const string AFOLDERNAME = "ClassA";
        const string BFOLDERNAME = "ClassB";

        private FileLists _fileLists;
        private FileAdapter _fileAdapter;

        public FileListBuilder()
        {
            _fileLists = new FileLists();
            _fileAdapter = new TextFile("txt","pdf");           
        }

        public override FileLists GetFileLists(){return _fileLists;}

        public override void GenerateFileNamesInA()
        {
            List<string> fileNames = _fileAdapter.GetAllFileNames(AFOLDERNAME);
            _fileLists.SetA(fileNames);
        }

        public override void GenerateFileNamesInB()
        {
            List<string> fileNames = _fileAdapter.GetAllFileNames(BFOLDERNAME);
            _fileLists.SetB(fileNames);
        }
    }
}
