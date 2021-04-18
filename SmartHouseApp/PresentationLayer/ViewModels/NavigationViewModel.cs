using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    class NavigationViewModel : BaseViewModel
    {
        public NavigationViewModel()
        {
            Devices = new LoadPageCommand(this, "DevicesPage.xaml");
            Schedule = new LoadPageCommand(this, "SchedulePage.xaml", false);
            Alerts = new LoadPageCommand(this, "", false);
            Devices.Execute(null);
        }

        #region ViewModel
        private string currentPage;
        public string CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        #endregion

        #region ICommands
        public ICommand Devices { get; private set; }

        public ICommand Schedule { get; private set; }

        public ICommand Alerts { get; private set; }
        #endregion
    }

    class LoadPageCommand : ICommand
    {
        private readonly NavigationViewModel navigationViewModel;
        private readonly string uri;
        private readonly bool shouldExecute;

        public LoadPageCommand(NavigationViewModel navigationViewModel, string uri, bool shouldExecute = true)
        {
            this.navigationViewModel = navigationViewModel;
            this.uri = uri;
            this.shouldExecute = shouldExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return shouldExecute;
        }

        public void Execute(object parameter)
        {
            navigationViewModel.CurrentPage = uri;
        }
    }

}
