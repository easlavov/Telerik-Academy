namespace ComputerComponents
{
    /// <summary>
    /// Defines a Motherboard computer component that serves as a communicator between 
    /// other computer components
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads the currently stored value from the RAM.
        /// </summary>
        /// <returns>The currently stored value as 32-bit integer.</returns>
        int Load();

        /// <summary>
        /// Saves a value to the RAM
        /// </summary>
        /// <param name="value">The 32-bit integer value to be saved.</param>
        void Save(int value);

        /// <summary>
        /// Calls the onboard videocard to print a message to the console
        /// </summary>
        /// <param name="data">The message to be printed</param>
        void Draw(string data);
    }
}
