namespace ComputerComponents.ComponentsFactory
{
    using System;

    internal static class HardDriveFactory
    {
        public static IHardDrive GetHardDrive(ComputerModel model)
        {
            HardDriveCollection raid;

            switch (model)
            {
                case ComputerModel.DellPersonal:
                    return new HardDrive(1000);
                case ComputerModel.DellLaptop:
                    return new HardDrive(1000);
                case ComputerModel.DellServer:
                    raid = new HardDriveCollection();
                    raid.AddDrive(new HardDrive(2000));
                    raid.AddDrive(new HardDrive(2000));
                    return raid;
                case ComputerModel.HpPersonal:
                    return new HardDrive(500);
                case ComputerModel.HpLaptop:
                    return new HardDrive(500);
                case ComputerModel.HpServer:
                    raid = new HardDriveCollection();
                    raid.AddDrive(new HardDrive(1000));
                    raid.AddDrive(new HardDrive(1000));
                    return raid;
                case ComputerModel.LenovoPersonal:
                    return new HardDrive(2000);
                case ComputerModel.LenovoLaptop:
                    return new HardDrive(1000);
                case ComputerModel.LenovoServer:
                    raid = new HardDriveCollection();
                    raid.AddDrive(new HardDrive(500));
                    raid.AddDrive(new HardDrive(500));
                    return raid;
                default:
                    break;
            }

            throw new ArgumentException("Invalid model");
        }
    }
}
