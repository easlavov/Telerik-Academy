namespace ComputerComponents
{
    /// <summary>
    /// A concrete implementation to the IMotherboard interface
    /// </summary>
    internal class Motherboard : IMotherboard
    {
        private IRam ram;
        private IVideoCard videoCard;

        /// <summary>
        /// Creates a new instance of the Motherboard class
        /// </summary>
        /// <param name="ram">The RAM the motherboard will work with.</param>
        /// <param name="videoCard">The videocard the motherboard will work with.</param>
        public Motherboard(IRam ram, IVideoCard videoCard)
        {
            this.ram = ram;
            this.videoCard = videoCard;
        }

        /// <summary>
        /// Loads the currently stored value from the RAM.
        /// </summary>
        /// <returns>The currently stored value as 32-bit integer.</returns>
        public int Load()
        {
            return this.ram.LoadValue();
        }

        /// <summary>
        /// Saves a value to the RAM
        /// </summary>
        /// <param name="value">The 32-bit integer value to be saved.</param>
        public void Save(int value)
        {
            this.ram.SaveValue(value);
        }

        /// <summary>
        /// Calls the onboard videocard to print a message to the console
        /// </summary>
        /// <param name="data">The message to be printed</param>
        public void Draw(string data)
        {
            this.videoCard.Draw(data);
        }
    }
}
