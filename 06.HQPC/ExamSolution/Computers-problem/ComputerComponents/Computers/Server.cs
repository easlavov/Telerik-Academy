namespace ComputerComponents.Computers
{
    public class Server : Computer
    {
        public Server(
                ComputerType type,
                ICpu cpu,
                IHardDrive hardDrives,
                IMotherboard motherboard)
            : base(type, cpu, hardDrives, motherboard)
        {
        }

        public void Process(int number)
        {
            this.Motherboard.Save(number);

            this.Cpu.CalculateSquareRoot();
        }
    }
}
