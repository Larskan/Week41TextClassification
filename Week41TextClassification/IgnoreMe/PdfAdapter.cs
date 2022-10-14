using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week41TextClassification.Leftovers
{
    public abstract class PdfAdapter
    {
        private string _fileType;


        public PdfAdapter(string fileType)
        {
            _fileType = fileType;
        }

        public abstract List<string> GetAllFileNames(string folderName); //To be used in showing ClassA and ClassB
        public abstract string GetAllTextFromFileA(string fileName); //ClassA
        public abstract string GetAllTextFromFileB(string fileName); //ClassB
        public string GetFileType() //the type used: pdf
        {
            return _fileType;
        }
    }
}
