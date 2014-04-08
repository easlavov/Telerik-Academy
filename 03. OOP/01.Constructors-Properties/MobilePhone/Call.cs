using System;

namespace MobilePhone
{
    // TASK 8
    public class Call
    {
        // Fields
        private DateTime timeOfCall;
        private string dialedPhoneNumber;
        private int callDuration;

        // Constructors
        public Call(DateTime time, string number, int duration)
        {
            this.TimeOfCall = time;
            this.DialedPhoneNumber = number;
            this.CallDuration = duration;
        }

        // Properties
        public DateTime TimeOfCall
        {
            get
            {
                return this.timeOfCall;
            }
            set
            {
                this.timeOfCall = value;
            }
        }

        public string DialedPhoneNumber
        {
            get
            {
                return this.dialedPhoneNumber;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Dialed phone number length should be at least 3 characters.");
                }
                this.dialedPhoneNumber = value;
            }
        }

        public int CallDuration
        {
            get
            {
                return this.callDuration;
            }
            set
            {
                // in seconds
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Call duration value should be bigger than zero");
                }
                this.callDuration = value;
            }
        }

        // Override
        public override string ToString()
        {
            return string.Format("Time of call: {0}" + Environment.NewLine
                + "Number dialed: {1}" + Environment.NewLine
                + "Call duration: {2}",
                this.TimeOfCall, this.DialedPhoneNumber, this.CallDuration);
        }
    }
}
