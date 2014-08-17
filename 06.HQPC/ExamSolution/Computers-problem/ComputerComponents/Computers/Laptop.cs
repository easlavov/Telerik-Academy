namespace ComputerComponents.Computers
{
    public class Laptop : Computer
    {
        private IBattery battery;

        public Laptop(
            ComputerType type,
            ICpu cpu,
            IHardDrive hardDrives,
            IMotherboard motherborad,
            IBattery battery)
            : base(type, cpu, hardDrives, motherborad)
        {
            this.battery = battery;
        }

        public void Charge(int amount)
        {
            this.battery.Charge(amount);
            string message = string.Format("Battery status: {0}%", this.battery.PowerLeft);
            this.Motherboard.Draw(message);
        }
    }
}
