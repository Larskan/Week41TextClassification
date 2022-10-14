using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


namespace Week41TextClassification.FileIO
{
    public class TextFile : FileAdapter
    {
        string PROJECTPATH = "C:\\Users\\Lars\\source\\repos\\Week41TextClassification\\Week41TextClassification\\Classes\\";
        //"C:\Users\Lars\source\repos\Week41TextClassification\Week41TextClassification\bin\Debug\Classes"


        const string FOLDERA = "ClassA";
        const string FOLDERB = "ClassB";

        //Without params it wont allow the method to use 2 types of filetypes
        public TextFile(params string[] fileType) : base(fileType) 
        {
            _ = PROJECTPATH;
            //PROJECTPATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Classes\\";
        }
        public override List<string> GetAllFileNames(string folderName)
        {

            List<string> fileNames = new List<string>();
            for(int i = 0; i < GetFileType().Count(); i++)
            {
                string[] paths = Directory.GetFiles(PROJECTPATH + folderName, "*." + GetFileType()[i]);

                foreach (string path in paths)
                {
                    fileNames.Add(path);
                }
                
            }
            return fileNames;

        }

        public string GetFilePathA(string fileName)
        {
            return @PROJECTPATH + FOLDERA + "\\" + fileName + "." + base.GetFileType(); //filetype is txt,pdf
        }

        public override string GetAllTextFromFileA(string path)
        {
            string text = string.Empty;
            if (path.EndsWith(".pdf"))
            {
                PdfReader reader = new PdfReader(path);
                for(int page = 1; page <= reader.NumberOfPages; page++)
                {
                    text += PdfTextExtractor.GetTextFromPage(reader, page);
                }
                reader.Close();
            }
            else
            {
                text = File.ReadAllText(path);
            }

            return text;
        }

        public override string GetAllTextFromFileB(string path)
        {
            string text = string.Empty;
            if (path.EndsWith(".pdf"))
            {
                PdfReader reader = new PdfReader(path);
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    text += PdfTextExtractor.GetTextFromPage(reader, page);
                }
                reader.Close();
            }
            else
            {
                text = File.ReadAllText(path);
            }

            return text;
        }
    }
}
