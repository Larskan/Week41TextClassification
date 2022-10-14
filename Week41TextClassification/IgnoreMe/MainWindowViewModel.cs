using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Week41TextClassification.Controller;
using Week41TextClassification.Domain;
using Week41TextClassification.Helpers;

namespace Week41TextClassification.Leftovers
{
    class MainWindowViewModel : Bindable
    {
        //Makes a dynamic binding for the MainWindow and Training, making Training part of MainWindow 
        public MainWindowViewModel() { AddTrainingCMD = new DelegateCommand(Training); }

        private void Training()
        {
            //Without the (App), it wont allow you to use ChangeUserControl
            //Hands over control to TrainingProcessViewModel
            //((App)System.Windows.Application.Current).ChangeUserControl(typeof(TrainingProcessViewModel));

            //the stuff from program.cs of original files
            KnowledgeBuilder knowledgeBuilder = new KnowledgeBuilder();

            //initiate the learning process

            knowledgeBuilder.Train();

            //getting the whole knowledge found in ClassA and ClassB
            Knowledge knowledge = knowledgeBuilder.GetKnowledge();

            //get a part of the knowledge, for debug
            BagOfWords bagOfWords = knowledge.GetBagOfWords();

            List<WordItem> items = bagOfWords.GetEntriesInDictionary();

            #region Task e)
            DictionaryViewModel.Dictionary.Clear(); //Clears the Dictionary if necessary

            //for each entry in bag of words, add it to Dictionary
            //foreach (string entry in items) { DictionaryViewModel.Dictionary.Add(entry); }
            #endregion

            TrainingProcessViewModel.timer.Stop();

            TrainingProcessViewModel.InfoText = "Time used to train";

        }

        #region ICommand
        public ICommand AddTrainingCMD { get; set; }
        //public ICommand ChangeToFilesCMD { get; set; } = new DelegateCommand(() => { ((App)System.Windows.Application.Current).ChangeUserControl(typeof(FileListBoxViewModel)); });
        //public ICommand ChangeToDictionaryCMD { get; set; } = new DelegateCommand(() => { ((App)System.Windows.Application.Current).ChangeUserControl(typeof(DictionaryViewModel)); });
        #endregion

    }
}
