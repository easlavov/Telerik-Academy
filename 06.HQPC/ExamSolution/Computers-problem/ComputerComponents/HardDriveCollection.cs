namespace ComputerComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDriveCollection : IHardDrive
    {
        private IList<IHardDrive> hardDrives;

        public HardDriveCollection()
        {
            this.hardDrives = new List<IHardDrive>();
        }

        public void AddDrive(IHardDrive drive)
        {
            this.hardDrives.Add(drive);
        }

        public void SaveData(int address, string data)
        {
            foreach (var hdd in this.hardDrives)
            {
                hdd.SaveData(address, data);
            }
        }

        public string LoadData(int address)
        {
            if (this.hardDrives.Count == 0)
            {
                throw new InvalidOperationException("No hard drive in the RAID array!");
            }

            string data = this.hardDrives.First().LoadData(address);
            return data;
        }
    }
}
