using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week41TextClassification.FileIO;
using Week41TextClassification.IgnoreMe;

namespace Week41TextClassification.Leftovers
{
    public class PdfListBuilder : AbstractPdfListBuilder
    {
        const string AFOLDERNAME = "ClassA";
        const string BFOLDERNAME = "ClassB";

        private PdfLists _pdfLists;
        private PdfAdapter _pdfAdapter;

        public PdfListBuilder()
        {
            _pdfLists = new PdfLists();

            _pdfAdapter = new PdfTextFile("pdf");
        }

        public override PdfLists GetPdfLists()
        {
            return _pdfLists;
        }

        public override void GenerateFileNamesInA()
        {
            List<string> fileNames = _pdfAdapter.GetAllFileNames(AFOLDERNAME);
            _pdfLists.SetA(fileNames);
        }

        public override void GenerateFileNamesInB()
        {
            List<string> fileNames = _pdfAdapter.GetAllFileNames(BFOLDERNAME);
            _pdfLists.SetB(fileNames);
        }


    }
}
