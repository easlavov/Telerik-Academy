namespace ComputerComponents
{
    using System;

    public class Cpu : ICpu
    {
        private const string TOO_LOW_MESSAGE = "Number too low.";
        private const string TOO_HIGH_MESSAGE = "Number too high.";
        private const string SQUARE_MESSAGE = "Square of {0} is {1}.";
        private const int ARCH_32_UPPER = 500;
        private const int ARCH_64_UPPER = 1000;
        private const int ARCH_128_UPPER = 2000;
        private static readonly Random random = new Random();
        private readonly CpuArchitecture architecture;
        private byte numberOfCores;

        public Cpu(byte numberOfCores, CpuArchitecture numberOfBits)
        {
            this.architecture = numberOfBits;
            this.numberOfCores = numberOfCores;
        }

        public IMotherboard Motherboard { get; set; }

        public void CalculateSquareRoot()
        {
            var number = this.Motherboard.Load();
            if (number < 0)
            {
                this.Motherboard.Draw(TOO_LOW_MESSAGE);
                return;
            }
            else if (((this.architecture == CpuArchitecture._32bit) && number > ARCH_32_UPPER) ||
                      ((this.architecture == CpuArchitecture._64bit) && number > ARCH_64_UPPER) ||
                      ((this.architecture == CpuArchitecture._128bit) && number > ARCH_128_UPPER))
            {
                this.Motherboard.Draw(TOO_HIGH_MESSAGE);
                return;
            }

            int result = 0;

            // BUG: The code did not return the square
            result = number * number;
            this.Motherboard.Save(result);

            this.Motherboard.Draw(string.Format(SQUARE_MESSAGE, number, result));
        }

        public void GenerateRandomNumber(int from, int to)
        {
            int randomNumber;

            // BOTTLENECK
            randomNumber = random.Next(from, to);

            this.Motherboard.Save(randomNumber);
        }
    }
}
