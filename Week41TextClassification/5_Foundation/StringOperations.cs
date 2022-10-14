using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Week41TextClassification.Foundation
{
    public class StringOperations
    {
        const int EXTENSIONLENGTH = 4; //extension for a string for removal of the .txt
        public static string getFileName(string path)
        {
            /// a) skipping the extension .txt (4 chars)
            //Starts at the index 0 and counts the length of chars on path, then removes the 4 chars
            string name = path.Substring(0, path.Length - EXTENSIONLENGTH);

            /// b) skipping the front part
            //LastIndexOf searches the entire thing for the specified value from the end first
            //Its working with C:\\Users\\Lars\\Documents\\suduko.txt, so goes from end until it meets '\\'
            //so startPos goes to '\\', and +1 to make sure you dont start at the \\, but starts at the letter.
            int startPos = name.LastIndexOf('\\') + 1;
            //Grabs the name of file only
            name = name.Substring(startPos, name.Length - startPos);

            //ToLower is to prevent any possible mistakes of forgetting to make a big letter in the test
            return name.ToLower();
        }

       
    }
}
