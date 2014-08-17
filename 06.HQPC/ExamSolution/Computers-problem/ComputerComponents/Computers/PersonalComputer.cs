namespace ComputerComponents.Computers
{
    public class PersonalComputer : Computer
    {
        private const string LOSS_MESSAGE = "You didn't guess the number {0}.";
        private const string VICTORY_MESSAGE = "You win!";

        public PersonalComputer(
                ComputerType type,
                ICpu cpu,
                IHardDrive hardDrives,
                IMotherboard motherboard)
            : base(type, cpu, hardDrives, motherboard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomNumber(1, 10);
            int number = this.Motherboard.Load();

            // Bottleneck removed here:
            if (number != guessNumber)
            {
                string message = string.Format(LOSS_MESSAGE, number);
                this.Motherboard.Draw(message);
            }
            else
            {
                this.Motherboard.Draw(VICTORY_MESSAGE);
            }
        }
    }
}
