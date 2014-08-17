namespace ComputerComponents
{
    internal class Ram : IRam
    {
        private int currentValue;
        private int amount;

        public Ram(int totalAmount)
        {
            this.amount = totalAmount;
        }

        public void SaveValue(int newValue)
        {
            this.currentValue = newValue;
        }

        public int LoadValue()
        {
            return this.currentValue;
        }
    }
}