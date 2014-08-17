namespace ComputerComponents.Computers
{
    using ComputerComponents;

    public abstract class Computer
    {
        public Computer(
            ComputerType type,
            ICpu cpu,
            IHardDrive hardDrives,
            IMotherboard motherboard)
        {
            this.Type = type;
            this.Cpu = cpu;
            this.HardDrives = hardDrives;
            this.Motherboard = motherboard;
        }

        protected ComputerType Type { get; set; }

        protected ICpu Cpu { get; set; }

        protected IHardDrive HardDrives { get; set; }

        protected IMotherboard Motherboard { get; set; }        
    }
}
