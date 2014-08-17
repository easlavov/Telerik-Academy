namespace ComputerComponents.ComputerFactory
{
    using ComputerComponents.Computers;

    public abstract class ComputerManufacturer
    {
        public abstract PersonalComputer ManufacturePersonalComputer();

        public abstract Laptop ManufactureLaptop();

        public abstract Server ManufactureServer();
    }
}
