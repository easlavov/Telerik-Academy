using System;
using System.Collections.Generic;
using System.Linq;

namespace MobilePhone
{
    // TASK 1
    public class Gsm
    {
        // TASK 2
        // Fields        
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>(); // TASK 9
        // Static
        private static Gsm iPhone4S = new Gsm("4S", "Apple"); // TASK 6

        // minimal constructor
        public Gsm(string model, string manufacturer)
            : this(model, manufacturer, null, "unspecified", null, null)
        {
        }

        // complete constructor
        public Gsm(string model, string manufacturer, double? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public static string IPhone4S // TASK 6
        {
            get
            {
                return iPhone4S.ToString();
            }
        }

        // TASK 5
        // Properties
        public List<Call> CallHistory // TASK 9
        {
            get
            {
                return this.callHistory;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                // owner name is not mandatory
                if (value != null)
                {
                    if (value.Length > 40 && value != null)
                    {
                        throw new ArgumentOutOfRangeException("The gsm owner name should be less than 40 characters.");
                    }
                }
                this.owner = value;
            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                // price not mandatory
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The gsm price value should be a positive number.");
                }
                this.price = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                // manufacturer name not mandatory but if used, should be at least 2 chars (abreviation)
                if (value.Length < 2 && value.Length != 0) // can be "value.length == 1" but will be harder to modify
                {
                    throw new ArgumentOutOfRangeException("The manufacturer name should be at least 2 characters.");
                }
                if (value.Length > 40)
                {
                    throw new ArgumentOutOfRangeException("The manufacturer name should be less than 40 characters.");
                }
                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value.Length < 2 && value.Length != 0) // can be "value.length == 1" but will be harder to modify
                {
                    throw new ArgumentOutOfRangeException("The gsm model name should be at least 2 characters.");
                }
                if (value.Length > 40)
                {
                    throw new ArgumentOutOfRangeException("The gsm model name should be less than 40 characters.");
                }
                this.model = value;
            }
        }

        // Methods
        public void MakeCall(string dialedNumber, int duration) // TASK 10
        {
            this.CallHistory.Add(new Call(DateTime.Now, dialedNumber, duration));
        }

        public void DeleteCall(int callNumber) // TASK 10
        {
            try
            {
                this.CallHistory.RemoveAt(callNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("The call you want to delete ({0}) does not exist.", callNumber);
            }
        }

        public void ClearCallHistory() // TASK 10
        {
            this.CallHistory.Clear();
        }

        public double CalculatePrice(double pricePerMinute) // TASK 11
        {
            // Get total duration of calls in SECONDS
            int totalSeconds = 0;
            for (int i = 0; i < this.CallHistory.Count; i++)
            {
                totalSeconds += this.callHistory[i].CallDuration;
            }
            // Convert seconds to minutes
            double totalMinutes = totalSeconds / 60.0;
            // Calculate price
            return totalMinutes * pricePerMinute;
        }

        // TASK 4
        // ToString override
        public override string ToString()
        {
            string toDisplay = string.Format("Mobile phone" + Environment.NewLine +
                                 "Model: {0}, Manufacturer: {1}, Price: {2}, Owner: {3}" + Environment.NewLine, this.model, this.manufacturer, this.price ?? null, this.owner);
            if (this.Battery != null)
            {
                toDisplay += this.Battery.ToString() + Environment.NewLine;
            }
            if (this.display != null)
            {
                toDisplay += this.Display.ToString() + Environment.NewLine;
            }

            return toDisplay;
        }
    }
}