namespace ComputersBuildingSystem
{
    using System;
    using ComputerComponents.ComputerFactory;
    using ComputerComponents.Computers;

    public class ComputerSystemMain
    {
        private static PersonalComputer pc;
        private static Laptop laptop;
        private static Server server;
        private static ComputerManufacturer manufacturer;

        public static void Main()
        {
            var manufacturerInput = Console.ReadLine();
            switch (manufacturerInput)
            {
                case "Dell":
                    manufacturer = new DellManufacturer();                    
                    break;
                case "HP":
                    manufacturer = new HpManufacturer();
                    break;
                case "Lenovo":
                    manufacturer = new LenovoManufacturer();
                    break;
                default:
                    throw new ArgumentException("Invalid manufacturer!");
            }

            pc = manufacturer.ManufacturePersonalComputer();
            laptop = manufacturer.ManufactureLaptop();
            server = manufacturer.ManufactureServer();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == null ||
                    command.StartsWith("Exit"))
                {
                    break;
                }

                var commandParameters = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParameters.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandType = commandParameters[0];
                var commandArgument = int.Parse(commandParameters[1]);
                
                if (commandType == "Charge")
                {
                    laptop.Charge(commandArgument);
                }
                else if (commandType == "Process")
                {
                    server.Process(commandArgument);
                }
                else if (commandType == "Play")
                {
                    pc.Play(commandArgument);
                }
            }
        }
    }
}