using LogicLayer;
using System.Collections.Generic;

namespace ClientPresentationLayer.ViewModels
{
    class RoomViewModel : BaseViewModel
    {
        private List<RoomEntryViewModel> _rooms;
        private readonly IRoomService _roomService;
        private RoomDTO _selectedRoom;

        public RoomViewModel()
        {
            _roomService = new RoomService(RepositoryPlaceholder.GetRoomsRepository());
            _rooms = new List<RoomEntryViewModel>();
            ParseRooms();
        }

        public List<RoomEntryViewModel> Rooms
        {
            get => _rooms;
            set
            {
                _rooms = value;
                OnPropertyChanged("Rooms");
            }
        }

        private void ParseRooms()
        {
            Rooms.Clear();
            foreach(var room in _roomService.GetRooms())
            {
                Rooms.Add(new RoomEntryViewModel() { RoomId = room.Id, RoomName = room.Name, RoomDescription = room.Description, Devices = room.Devices });
            }
            OnPropertyChanged("Rooms");
        }
    }


    class RoomEntryViewModel : BaseViewModel
    {
        private List<DeviceDTO> _devices;
        private int _id;
        private string _name;
        private string _description;

        public List<DeviceDTO> Devices
        {
            get => _devices;
            set
            {
                _devices = value;
                OnPropertyChanged("Devices");
            }
        }

        public int RoomId
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("RoomId");
            }
        }

        public string RoomName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("RoomName");
            }
        }

        public string RoomDescription
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("RoomDescription");
            }
        }

    }
}
