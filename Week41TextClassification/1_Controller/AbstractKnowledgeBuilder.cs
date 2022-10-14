using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week41TextClassification.Domain;

namespace Week41TextClassification.Controller
{
    public abstract class AbstractKnowledgeBuilder
    {
        // Called to initiate the learning process

        public abstract void Train();

        // (Internal) steps in creating the Knowledge:
        // step 1
        public abstract void BuildFileLists();

        // Step 1.1
        //public abstract void BuildPdfLists();

        // step 2
        public abstract void BuildBagOfWords();

        // step 3
        public abstract void BuildVectors();

        // step after each training
        public abstract Knowledge GetKnowledge();
    }
}
