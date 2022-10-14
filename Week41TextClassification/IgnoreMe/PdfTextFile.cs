using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week41TextClassification.Leftovers
{
    public class PdfTextFile : PdfAdapter
    {
        const string PROJECTPATH = "C:\\Users\\Lars\\source\\repos\\Week41TextClassification\\Week41TextClassification\\Classes\\";
        const string FOLDERA = "ClassA";
        const string FOLDERB = "ClassB";

        public PdfTextFile(string fileType) : base(fileType) { }

        public override List<string> GetAllFileNames(string folderName)
        {
            List<string> fileNames = new List<string>();
            string[] paths = Directory.GetFiles(PROJECTPATH + folderName, "*." + GetFileType());

            foreach (string path in paths)
            {
                fileNames.Add(path);
            }
            return fileNames;
        }

        public string GetFilePathA(string fileName)
        {
            return @PROJECTPATH + FOLDERA + "\\" + fileName + "." + GetFileType(); //filetype is pdf
        }

        public string GetFilePathB(string fileName)
        {
            return PROJECTPATH + FOLDERB + "\\" + fileName + "." + GetFileType();
        }

        public override string GetAllTextFromFileA(string path)
        {
            string text = File.ReadAllText(path);

            return text;
        }

        public override string GetAllTextFromFileB(string path)
        {
            string text = File.ReadAllText(path);

            return text;
        }
    }
}