using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week41TextClassification.Domain
{
    // composite object - the complete "brain" of the app
    public class Knowledge
    {
        private FileLists _fileLists;
        private PdfLists _pdfLists;
        private BagOfWords _bagOfWords;
        private Vectors _vectors;

        public Knowledge() { }

        public BagOfWords GetBagOfWords() { return _bagOfWords; }
        public FileLists GetFileLists() { return _fileLists; }
        public PdfLists GetPdfLists() { return _pdfLists; }

        public Vectors GetVectors() { return _vectors; }
        public void SetFileLists(FileLists fileLists) { _fileLists = fileLists; }
        public void SetPdfLists(PdfLists pdfLists) { _pdfLists = pdfLists; }

        public void SetBagOfWords(BagOfWords bagOfWords) { _bagOfWords = bagOfWords; }

        public void SetVectors(Vectors vectors) { _vectors = vectors; }

    }
}
