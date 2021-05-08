﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClientDataLayer.Interfaces;
using ModelCommon;
using ModelCommon.Interfaces;

namespace ClientDataLayer
{
    public class DeviceRepository : IDeviceRepository
    {
        private static DeviceRepository _instance;
        public static DeviceRepository Instance
        {
            get { return _instance ??= new DeviceRepository(); }
            private set => _instance = value;
        }

        public async Task<IEnumerable<IDevice>> Get()
        {
            await DataContext.Instance.RequestDataUpdate();
            return DataContext.Instance.Devices;
        }

        public IDevice Get(int id)
        {
            return DataContext.Instance.Devices.Find(device => device.Id == id);
        }

        public async Task<bool> Add(IDevice item)
        {
            string addDeviceRequest = "AddDevice";
            addDeviceRequest += JsonSerializer.Serialize((ExampleDevice)item);

            await DataContext.Instance.RequestWithConfirmation(addDeviceRequest);
            await DataContext.Instance.RequestDataUpdate();

            return await Task.FromResult(true);
        }

        public bool Remove(int id)
        {
            return DataContext.Instance.Devices.RemoveAll(device => device.Id == id) > 0;
        }

        public bool Remove(IDevice item)
        {
            return DataContext.Instance.Devices.Remove(item);
        }

        public bool Update(int id, IDevice item)
        {
            IDevice found = DataContext.Instance.Devices.Find(device => device.Id == id);
            if (found != null)
            {
                found.Name = item.Name;
                found.Enabled = item.Enabled;
                return true;
            }
            else
            {
                return false;
            }
        }

        public IDevice Get(string name)
        {
            return DataContext.Instance.Devices.Find(device => device.Name == name);
        }

        public IEnumerable<IDevice> GetAll(string name)
        {
            return DataContext.Instance.Devices.FindAll(device => device.Name == name);
        }

        public int[] GetIds(string name)
        {
            List<IDevice> found = DataContext.Instance.Devices.FindAll(device => device.Name == name);
            int[] ids = new int[found.Count];
            for (int i = 0; i < found.Count; i++)
            {
                ids[i] = found[i].Id;
            }

            return ids;
        }

        public int Remove(string name)
        {
            return DataContext.Instance.Devices.RemoveAll(device => device.Name == name);
        }

        public int UpdateAll(string name, IDevice item)
        {
            List<IDevice> found = DataContext.Instance.Devices.FindAll(device => device.Name == name);
            foreach (var t in found)
            {
                t.Enabled = item.Enabled;
                t.Name = item.Name;
            }
            return found.Count;
        }

        public bool SetState(int id, bool enabled)
        {
            IDevice device = Get(id);
            if (device != null)
            {
                device.Enabled = enabled;
                return true;
            }

            return false;
        }

        public int SetStates(string name, bool enabled)
        {
            List<IDevice> devices = (List<IDevice>)GetAll(name);
            foreach (var device in devices)
            {
                device.Enabled = enabled;
            }
            return devices.Count;
        }

        public async Task<bool> Toggle(int id)
        {
            await DataContext.Instance.RequestWithConfirmation($"ToggleDevice:{id}");
            await DataContext.Instance.RequestDataUpdate();
            return await Task.FromResult(true);
        }

        public int ToggleAll(string name)
        {
            List<IDevice> devices = (List<IDevice>)GetAll(name);
            foreach (var device in devices)
            {
                device.Enabled = !device.Enabled;
            }
            return devices.Count;
        }
    }
}
