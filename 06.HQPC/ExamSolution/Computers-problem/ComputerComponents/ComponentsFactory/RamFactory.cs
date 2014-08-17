namespace ComputerComponents.ComponentsFactory
{
    using System;

    internal static class RamFactory
    {
        internal static IRam GetRam(ComputerModel model)
        {
            IRam newRam;

            switch (model)
            {
                case ComputerModel.DellPersonal:
                    newRam = new Ram(8);
                    return newRam;
                case ComputerModel.DellLaptop:
                    newRam = new Ram(8);
                    return newRam;
                case ComputerModel.DellServer:
                    newRam = new Ram(64);
                    return newRam;
                case ComputerModel.HpPersonal:
                    newRam = new Ram(2);
                    return newRam;
                case ComputerModel.HpLaptop:
                    newRam = new Ram(4);
                    return newRam;
                case ComputerModel.HpServer:
                    newRam = new Ram(32);
                    return newRam;
                case ComputerModel.LenovoPersonal:
                    newRam = new Ram(4);
                    return newRam;
                case ComputerModel.LenovoLaptop:
                    newRam = new Ram(16);
                    return newRam;
                case ComputerModel.LenovoServer:
                    newRam = new Ram(8);
                    return newRam;
                default:
                    break;
            }

            throw new ArgumentException("Invalid model");
        }
    }
}
