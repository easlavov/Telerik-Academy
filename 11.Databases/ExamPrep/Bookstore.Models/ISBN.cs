namespace Bookstore.Models
{
    using System;
    
    public class ISBN
    {
        private const int LENGTH = 13;
        private const string INVALID_LENGTH_MESSAGE = "ISBN must be {0} long.";
        private const string INVALID_CHARACTERS_MESSAGE = "ISBN must contain digits only.";
        private string value;

        public string Value
        {
            get
            {                
                return this.value;
            }

            set
            {
                IsIsbnValid(value);
                this.value = value;
            }
        }

        private bool IsIsbnValid(string isbn)
        {
            if (isbn.Length != LENGTH)
            {
                string message = string.Format(INVALID_LENGTH_MESSAGE, LENGTH);
                throw new ArgumentException(message);
            }

            if (!IsDigitsOnly(isbn))
            {
                throw new ArgumentException(INVALID_CHARACTERS_MESSAGE);
            }

            return true;
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {                    
                    return false;
                }
            }

            return true;
        }
    }
}
