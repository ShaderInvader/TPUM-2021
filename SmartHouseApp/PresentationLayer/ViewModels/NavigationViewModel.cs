using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientLogicLayer;
using ClientLogicLayer.Interfaces;
using ClientPresentationLayer.ViewModels.Commands;
using System.Globalization;

namespace ClientPresentationLayer.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        #region Private

        private readonly IConnectionService _connectionService;
        private readonly ILocationService _locationService;

        #endregion

        #region ViewModel
        private string _connectButtonText = "Connect";
        public string ConnectButtonText
        {
            get => _connectButtonText;
            set
            {
                _connectButtonText = value;
                OnPropertyChanged("ConnectButtonText");
            }
        }

        private string _connectionUri = "ws://localhost:8081/";
        public string ConnectionUri
        {
            get => _connectionUri;
            set
            {
                _connectionUri = value;
                OnPropertyChanged("ConnectionUri");
            }
        }

        private string _currentPage;
        public string CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private string _log = "Waiting for connection logs...";

        public string Log
        {
            get => _log;
            set
            {
                _log = value;
                OnPropertyChanged("Log");
            }
        }
        #endregion

        #region ICommands
        public ICommand Devices { get; private set; }
        public ICommand Rooms { get; private set; }
        public ICommand Alerts { get; private set; }
        public ICommand ConnectCommand { get; private set; }
        #endregion

        public static event Action ConnectionEstablishedEvent;
        public static event Action ConnectionLostEvent;

        public NavigationViewModel()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            // Create connection service object
            _connectionService = ServiceFactory.CreateConnectionService;
            _locationService = ServiceFactory.CreateLocationService;
            // Add log messenger delegate
            _connectionService.ConnectionLogger += s => Log = s;

            // Setup the page commands
            Devices = new LoadPageCommand(this, "DevicesPage.xaml");
            Rooms = new LoadPageCommand(this, "RoomsPage.xaml", false);
            Alerts = new LoadPageCommand(this, "", false);
            ConnectCommand = new ConnectCommand(this);

            // Load the default page on connection
            Debug.WriteLine("Starting default page...");
            Devices.Execute(null);
        }

        public bool CheckConnection()
        {
            return _connectionService.Connected;
        }

        public async Task<bool> EstablishConnection(Uri peerUri)
        {
            ConnectButtonText = "Connecting...";
            bool result = await _connectionService.Connect(peerUri);
            if (result)
            {
                ConnectionEstablishedEvent?.Invoke();
                Task.Run(_locationService.StartTracking);
            }
            ConnectButtonText = result ? "Disconnect" : "Connect";
            return result;
        }

        public async Task Disconnect()
        {
            await _connectionService.Disconnect();
            ConnectionLostEvent?.Invoke();
            _locationService.StopTracking();
            ConnectButtonText = "Connect";
        }
    }
}
