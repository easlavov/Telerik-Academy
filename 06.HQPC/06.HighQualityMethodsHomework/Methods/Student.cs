using System;

namespace Methods
{
    class Student
    {
        private const int BACKWARD_LENGTH_FOR_DATE_PARSING = 10;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        /// <summary>
        /// Returns if the student is older than another.
        /// </summary>
        /// <param name="other">The other student.</param>
        /// <returns>If older.</returns>
        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = ParseDateFromOtherInfo(this);
            DateTime secondDate = ParseDateFromOtherInfo(other);
            bool isOlder = firstDate > secondDate;
            return isOlder;
        }

        private DateTime ParseDateFromOtherInfo(Student student)
        {
            string dateAsString = 
                student.OtherInfo.Substring(student.OtherInfo.Length - BACKWARD_LENGTH_FOR_DATE_PARSING);
            DateTime date = DateTime.Parse(dateAsString);
            return date;
        }
    }
}
