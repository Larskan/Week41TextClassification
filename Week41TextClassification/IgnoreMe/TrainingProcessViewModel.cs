using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Week41TextClassification.Helpers;

namespace Week41TextClassification.Leftovers
{
    public class TrainingProcessViewModel : Bindable
    {
        #region Variables
        //b) a text field to show how long training takes in millisec
        public static TimeSpan timespan = new TimeSpan(); //Difference between 2 times
        public static DispatcherTimer timer = new DispatcherTimer(); //Track time
        public static Stopwatch stopWatch = new Stopwatch(); //Measure elapsed time
        private string _timeUsed = "00:00:10"; //placeholder
        private static string _infoText = ""; //Adding explanation for why a time shows
        #endregion

        #region The Time Methods
        public TrainingProcessViewModel()
        {
            //DispatcherTimer has to contain the Interval and Tick
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += LaunchStopWatch; //Returns null for some reason. TODO: fix if possible
            timer.Start();
        }
        public void LaunchStopWatch(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                timespan = stopWatch.Elapsed;
                TimeUsedText = timespan.ToString(@"mm':'ss':'fff");

            }
            else { stopWatch.Restart(); }
        }
        #endregion

        #region Getter and Setter for TimeUsedText and InfoText
        public string TimeUsedText
        {
            set { _timeUsed = value; PropertyIsChanged(); }
            get { return _timeUsed; }
        }

        public static string InfoText
        {
            set { _infoText = value; }
            get { return _infoText; }
        }
        #endregion
    }
}
