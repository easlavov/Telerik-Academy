namespace ComputerComponents.ComputerFactory
{
    using ComputerComponents.ComponentsFactory;
    using ComputerComponents.Computers;

    public class HpManufacturer : ComputerManufacturer
    {
        public override PersonalComputer ManufacturePersonalComputer()
        {
            ComputerModel model = ComputerModel.HpPersonal;
            ComputerType type = ComputerType.PC;
            ICpu cpu = CpuFactory.GetCpu(model);
            IRam ram = RamFactory.GetRam(model);
            IHardDrive hardDrives = HardDriveFactory.GetHardDrive(model);
            IVideoCard videoCard = VideoCardFactory.GetVideoCard(model);
            IMotherboard motherboard = new Motherboard(ram, videoCard);
            cpu.Motherboard = motherboard;

            return new PersonalComputer(type, cpu, hardDrives, motherboard);
        }

        public override Laptop ManufactureLaptop()
        {
            ComputerModel model = ComputerModel.HpLaptop;
            ComputerType type = ComputerType.PC;
            ICpu cpu = CpuFactory.GetCpu(model);
            IRam ram = RamFactory.GetRam(model);
            IHardDrive hardDrives = HardDriveFactory.GetHardDrive(model);
            IVideoCard videoCard = VideoCardFactory.GetVideoCard(model);
            IBattery battery = new LaptopBattery();
            IMotherboard motherboard = new Motherboard(ram, videoCard);
            cpu.Motherboard = motherboard;

            return new Laptop(type, cpu, hardDrives, motherboard, battery);
        }

        public override Server ManufactureServer()
        {
            ComputerModel model = ComputerModel.HpServer;
            ComputerType type = ComputerType.Server;
            ICpu cpu = CpuFactory.GetCpu(model);
            IRam ram = RamFactory.GetRam(model);
            IHardDrive hardDrives = HardDriveFactory.GetHardDrive(model);
            IVideoCard videoCard = VideoCardFactory.GetVideoCard(model);
            IMotherboard motherboard = new Motherboard(ram, videoCard);
            cpu.Motherboard = motherboard;

            return new Server(type, cpu, hardDrives, motherboard);
        }
    }
}
