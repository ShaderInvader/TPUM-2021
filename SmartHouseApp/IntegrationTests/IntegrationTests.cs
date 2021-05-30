using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ClientLogicLayer.Interfaces;
using ClientLogicLayer.InternalDTOs;
using NUnit.Framework;

namespace IntegrationTests
{
    public class Tests
    {
        private IConnectionService _connectionService;
        private IDeviceService _deviceService;

        [SetUp]
        public void Setup()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            ClientDataLayer.DataContext.Instance.ClearContext();
            _connectionService = ClientLogicLayer.ServiceFactory.CreateConnectionService;
            _deviceService = ClientLogicLayer.ServiceFactory.CreateDeviceService;

            var task1 = Task.Run(async () => { await ServerPresentationLayer.Program.CreateServer(); });
            var task2 = Task.Run(async () => { await _connectionService.Connect(new Uri("ws://localhost:8081/")); });
            task2.Wait();

            var task = Task.Run(async () => ClientDataLayer.DeviceRepository.Instance.Refresh());
            task.Wait();
        }

        [Test]
        public void RefreshTest()
        {
            var task = Task.Run( async () => await ClientDataLayer.DeviceRepository.Instance.Refresh());
            task.Wait();
            Assert.AreEqual(8, ClientDataLayer.DeviceRepository.Instance.Get().ToList().Count);
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual("Philips Hue Bluetooth White and Color Ambiance Bulb", ClientDataLayer.DeviceRepository.Instance.Get(0).Name);
            Assert.AreEqual(1, ClientDataLayer.DeviceRepository.Instance.Get("Yeelight Smart LED Bulb").Id);
        }

        [Test]
        public void AddTest()
        {
            _deviceService.AddDevice(new DeviceDTO() { Enabled = false, Id = 10, Name = "device0" });

            Assert.AreEqual(ClientDataLayer.DeviceRepository.Instance.Get(0).Name, ServerDataLayer.DeviceRepository.Instance.Get(0).Name);
            Assert.AreEqual(ClientDataLayer.DeviceRepository.Instance.Get(10).Name, ServerDataLayer.DeviceRepository.Instance.Get(10).Name);

            Assert.AreEqual(8, ClientDataLayer.DeviceRepository.Instance.Get().ToList().Count);
            Assert.AreEqual(8, ServerDataLayer.DeviceRepository.Instance.Get().ToList().Count);
        }

        [Test]
        public void ToggleTest()
        {
            _deviceService.ToggleDevice(0);

            Assert.AreEqual(false, ClientDataLayer.DeviceRepository.Instance.Get(0).Enabled);
        }
    }
}