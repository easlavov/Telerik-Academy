namespace ComputerComponents.ComputerFactory
{
    using ComputerComponents.ComponentsFactory;
    using ComputerComponents.Computers;

    public class LenovoManufacturer : ComputerManufacturer
    {
        public override PersonalComputer ManufacturePersonalComputer()
        {
            ComputerModel model = ComputerModel.LenovoPersonal;
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
            ComputerModel model = ComputerModel.LenovoLaptop;
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
            ComputerModel model = ComputerModel.LenovoServer;
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
