namespace ComputerComponents
{
    public interface ICpu
    {
        IMotherboard Motherboard { get; set; }

        void GenerateRandomNumber(int from, int to);

        void CalculateSquareRoot();
    }
}
