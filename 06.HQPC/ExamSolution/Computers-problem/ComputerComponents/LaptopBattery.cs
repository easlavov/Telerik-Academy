namespace ComputerComponents
{
    public class LaptopBattery : IBattery
    {
        private const int INITIAL_POWER_PERCENTAGE = 50;

        public LaptopBattery()
        {
            this.PowerLeft = INITIAL_POWER_PERCENTAGE;
        }

        public int PowerLeft { get; private set; }

        public void Charge(int percentage)
        {
            this.PowerLeft += percentage;
            if (this.PowerLeft > 100)
            {
                this.PowerLeft = 100;
            }

            if (this.PowerLeft < 0)
            {
                this.PowerLeft = 0;
            }
        }
    }
}
