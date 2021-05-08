using System;
using System.Collections.Generic;
using System.Text;
using ClientDataLayer;
using ClientLogicLayer.Interfaces;
using ClientLogicLayer.Services;
using LogicLayer;
using LogicLayer.Interfaces;

namespace ClientLogicLayer
{
    public static class ServiceFactory
    {
        public static IDeviceService CreateDeviceService => new DeviceService(DeviceRepository.Instance);
        public static IRoomService CreateRoomService => new RoomService(RoomRepository.Instance);
        public static IUserService CreateUserService => new UserService(UserRepository.Instance);
        public static IConnectionService CreateConnectionService => new ClientConnectionService();
    }
}
