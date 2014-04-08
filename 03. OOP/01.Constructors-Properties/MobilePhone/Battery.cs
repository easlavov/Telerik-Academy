using System;

namespace MobilePhone
{
    // TASK 3
    public enum BatteryType
    {
        LiIon, NiMH, NiCd, NiMn
    }

    // TASK 1
    public class Battery
    {
        // TASK 2
        // Fields
        private string model;
        private double? hoursIdle;
        private double? hoursTalk;
        // TASK 3
        private BatteryType? batteryType;

        // Constructors
        public Battery()
        {
        }

        public Battery(string model)
            : this(model, null, null, null)
        {
        }

        public Battery(string model, BatteryType batteryType)
            : this(model, null, null, batteryType)
        {
        }

        public Battery(double hoursIdle, double hoursTalk)
            : this(null, hoursIdle, hoursTalk, null)
        {
        }

        public Battery(double hoursIdle, double hoursTalk, BatteryType batteryType)
            : this(null, hoursIdle, hoursTalk, batteryType)
        {
        }

        public Battery(string model, double? hoursIdle, double? hoursTalk, BatteryType? batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        // TASK 5
        // Properties
        public BatteryType? BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                // arguments are enumerated
                this.batteryType = value;
            }
        }

        public double? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentOutOfRangeException("Battery talking hours value should be in the range 0 to 24.");
                }
                this.hoursTalk = value;
            }
        }

        public double? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0 || value > 336)
                {
                    throw new ArgumentOutOfRangeException("Battery idle hours value should be in the range 0 to 336.");
                }
                this.hoursIdle = value;
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
                if (value.Length < 3 && value.Length != 0) // can be "value.length == 1" but will be harder to modify
                {
                    throw new ArgumentOutOfRangeException("Battery model name should be at least 3 characters.");
                }
                if (value.Length > 40)
                {
                    throw new ArgumentOutOfRangeException("Battery model name should be no longer than 40 characters.");
                }
                this.model = value;
            }
        }

        // Override
        public override string ToString()
        {
            string toDisplay = String.Format(
                "Battery model: {0}, Hours idle: {1}, Hours talking: {2}, Type: {3}",
                this.Model, this.HoursIdle ?? null, this.HoursTalk ?? null, this.BatteryType ?? null);

            return toDisplay;
        }
    }
}
