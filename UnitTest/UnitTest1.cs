
using Week41TextClassification;
using Week41TextClassification.Controller;
using Week41TextClassification.Domain;
using Week41TextClassification.FileIO;
using Week41TextClassification.Business;
using Week41TextClassification.Foundation;
using Week41TextClassification.Helpers;
using Week41TextClassification.View;
using Week41TextClassification.ViewModel;


namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        //Test to make sure the Unit Test actually works
        public void TestStringOperationsGetFileName()
        {
            string expected = "iamatest"; //the file I made 
            string path = "C:\\Users\\Lars\\Documents\\IAmATest.txt"; //Direct path to the txt    

            //act
            //Launches the method within StringOperations
            //Grabs the path, removes the .txt first, followed by starting the actual string after \\
            string actual = StringOperations.getFileName(path);

            //assert
            Assert.AreEqual(expected, actual);

        }

        
        /*
        [Test]
        public void TestGetFilePathA()
        {
            //arrange
            string folderA = "ClassA";
            string fileType = "pdf";
            string fileName = "filnavn";
            string expected = "C:\\Users\\Lars\\source\\repos\\Week41TextClassification\\Week41TextClassification\\Classes\\" + folderA + "\\filnavn." + fileType;

            //act
            TextFile tf = new TextFile(fileType);
            string actual = tf.GetFilePathA(fileName);

            //assert
            Assert.AreEqual(expected, actual);
        }
        */

        

        [Test]
        public void TestVectorLength()
        {
            //arrange
            KnowledgeBuilder kb = new KnowledgeBuilder();
            kb.Train();
            Knowledge knowledge = kb.GetKnowledge();
            BagOfWords bagOfWords = knowledge.GetBagOfWords();

            int expected = bagOfWords.GetAllWordsInDictionary().Count();

            //act
            int actual = knowledge.GetVectors().GetVectorA()[0].Count();

            //assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestRemovePunctuation()
        {
            //arrange
            string word = "............hello,.//?!\"";
            string expected = "hello";

            //act
            string actual = Tokenization.RemovePunctuation(word);
            Console.WriteLine(actual);

            //assert
            Assert.AreEqual(expected, actual);
        }

        
    }
}