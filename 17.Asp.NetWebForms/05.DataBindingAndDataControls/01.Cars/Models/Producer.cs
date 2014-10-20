namespace _01.Cars.Models
{
    using System.Collections.Generic;

    public class Producer
    {
        public string Name { get; set; }

        public ICollection<string> Models { get; set; }
    }
}