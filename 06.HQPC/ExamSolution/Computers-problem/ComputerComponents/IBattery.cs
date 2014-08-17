namespace ComputerComponents
{
    public interface IBattery
    {
        int PowerLeft { get; }

        void Charge(int amount);
    }
}
