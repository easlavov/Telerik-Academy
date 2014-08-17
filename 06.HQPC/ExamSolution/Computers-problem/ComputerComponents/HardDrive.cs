namespace ComputerComponents
{
    using System.Collections.Generic;

    public class HardDrive : IHardDrive
    {
        private int capacity;
        private Dictionary<int, string> data;

        public HardDrive(int capacity)
        {
            this.capacity = capacity;
            this.data = new Dictionary<int, string>();
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public void SaveData(int addr, string newData)
        {
            this.data[addr] = newData;
        }

        public string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
