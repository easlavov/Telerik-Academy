namespace ComputerComponents
{
    public interface IHardDrive
    {
        void SaveData(int address, string data);

        string LoadData(int address);
    }
}
