using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week41TextClassification.FileIO
{
    public abstract class FileAdapter
    {
        private List<string> _fileType; //Changed to List to match both pdf and txt
        public FileAdapter(params string[] fileType)
        {
            _fileType = new List<string>();
            for(int i = 0; i < fileType.Length; i++)
            {
                _fileType.Add(fileType[i].ToString());
            }
        }
        public abstract List<string> GetAllFileNames(string folderName); //To be used in showing ClassA and ClassB
        public abstract string GetAllTextFromFileA(string fileName); //ClassA

        public abstract string GetAllTextFromFileB(string fileName); //ClassB

        public List<string> GetFileType() //the type used: txt, pdf
        {
            return _fileType;
        }
    }
}
