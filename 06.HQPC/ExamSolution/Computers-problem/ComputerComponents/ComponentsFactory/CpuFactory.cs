namespace ComputerComponents.ComponentsFactory
{
    using System;

    internal static class CpuFactory
    {
        public static ICpu GetCpu(ComputerModel model)
        {
            ICpu newCpu;

            switch (model)
            {
                case ComputerModel.DellPersonal:
                    newCpu = new Cpu(4, CpuArchitecture._64bit);
                    return newCpu;
                case ComputerModel.DellLaptop:
                    newCpu = new Cpu(4, CpuArchitecture._32bit);
                    return newCpu;
                case ComputerModel.DellServer:
                    newCpu = new Cpu(8, CpuArchitecture._64bit);
                    return newCpu;
                case ComputerModel.HpPersonal:
                    newCpu = new Cpu(2, CpuArchitecture._32bit);
                    return newCpu;
                case ComputerModel.HpLaptop:
                    newCpu = new Cpu(2, CpuArchitecture._64bit);
                    return newCpu;
                case ComputerModel.HpServer:
                    newCpu = new Cpu(4, CpuArchitecture._32bit);
                    return newCpu;
                case ComputerModel.LenovoPersonal:
                    newCpu = new Cpu(2, CpuArchitecture._64bit);
                    return newCpu;
                case ComputerModel.LenovoLaptop:
                    newCpu = new Cpu(2, CpuArchitecture._64bit);
                    return newCpu;
                case ComputerModel.LenovoServer:
                    newCpu = new Cpu(2, CpuArchitecture._128bit);
                    return newCpu;
                default:
                    break;
            }

            throw new ArgumentException("Invalid model");
        }
    }
}
