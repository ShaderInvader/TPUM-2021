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
            Devices = new DevicesCommand(this);
            Schedule = new ScheduleCommand(this);
            Alerts = new AlertsCommand(this);
            LoadDevices();
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
        public void LoadDevices()
        {
            CurrentPage = "DevicesPage.xaml";
        }

        public ICommand Schedule { get; private set; }
        public void LoadSchedule()
        {
            CurrentPage = "";
        }

        public ICommand Alerts { get; private set; }
        public void LoadAlerts()
        {
            CurrentPage = "";
        }
        #endregion
    }

    class DevicesCommand : ICommand
    {
        private readonly NavigationViewModel navigationViewModel;

        public DevicesCommand(NavigationViewModel navigationViewModel)
        {
            this.navigationViewModel = navigationViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            navigationViewModel.LoadDevices();
        }
    }

    class ScheduleCommand : ICommand
    {
        private readonly NavigationViewModel navigationViewModel;

        public ScheduleCommand(NavigationViewModel navigationViewModel)
        {
            this.navigationViewModel = navigationViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return false;
        }

        public void Execute(object parameter)
        {
            navigationViewModel.LoadSchedule();
        }
    }

    class AlertsCommand : ICommand
    {
        private readonly NavigationViewModel navigationViewModel;

        public AlertsCommand(NavigationViewModel navigationViewModel)
        {
            this.navigationViewModel = navigationViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return false;
        }

        public void Execute(object parameter)
        {
            navigationViewModel.LoadAlerts();
        }
    }
}
