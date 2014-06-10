namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        private const int ID_NUMBER_MINIMAL_VALUE = 10000;
        private const int ID_NUMBER_MAXIMAL_VALUE = 99999;
        private string name;
        private int id;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < ID_NUMBER_MINIMAL_VALUE || ID_NUMBER_MAXIMAL_VALUE > value)
                {
                    string message = string.Format("ID must be a value between {0} and {1}.",
                                                    ID_NUMBER_MINIMAL_VALUE,
                                                    ID_NUMBER_MAXIMAL_VALUE);
                    throw new ArgumentOutOfRangeException(message);
                }

                this.id = value;
            }
        }
    }
}
