using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week41TextClassification.Domain;

namespace Week41TextClassification.Leftovers
{
    public abstract class AbstractPdfListBuilder
    {
        public abstract void GenerateFileNamesInA();

        public abstract void GenerateFileNamesInB();

        //  get the complete FileLists-object
        public abstract PdfLists GetPdfLists();
    }
}
