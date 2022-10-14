using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Week41TextClassification.Leftovers;

namespace Week41TextClassification.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ChangeUserControl makes FileListBoxViewModel able to take control of part of Main Window
            //ContentControlRef marks the area for use for FileListBoxViewModel, the area being the White Right DockPanel
            //((App)App.Current).ContentControlRef = this.ContentController;
            //((App)App.Current).ChangeUserControl(typeof(FileListBoxViewModel));
        }
    }
}
