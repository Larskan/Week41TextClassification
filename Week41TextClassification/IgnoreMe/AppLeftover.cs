using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Week41TextClassification.Leftovers
{
    internal class AppLeftover
    {
        /*
        public ContentControl ContentControlRef { get; set; } = null;


        public App()
        {
            ServiceContainer.Register<MainWindowViewModel>(() => new MainWindowViewModel());
            ServiceContainer.Register<TrainingProcessViewModel>(() => new TrainingProcessViewModel());
            ServiceContainer.Register<FileListBoxViewModel>(() => new FileListBoxViewModel());
            ServiceContainer.Register<DictionaryViewModel>(() => new DictionaryViewModel());
        }

        public void ChangeUserControl(Type viewModelType)
        {
            UserControl tmpUC = CreatePage(viewModelType, null);
            var viewModel = ServiceContainer.Resolve(viewModelType);
            //view.BindingContext = viewModel

            tmpUC.DataContext = viewModel;
            this.ContentControlRef.Content = tmpUC;
        }

        /// <summary>
        /// This metod will use the naming convention between the ViewModel and the View
        /// To find the name of the View that matches the ViewModel
        /// The view name is then used to find the type (the view class name)
        /// </summary>
        /// <param name="viewModelType"></param>
        /// <returns></returns>
        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private UserControl CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }
            //CreateInstance, will create an instance based on the type, the default constructor is always invoked
            UserControl page = Activator.CreateInstance(pageType) as UserControl;

            return page;
        }
        */
    }

}
