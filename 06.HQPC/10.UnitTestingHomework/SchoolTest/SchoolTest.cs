namespace SchoolTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolInstanceInitializedWithNonNullStudentList()
        {
            School testSchool = new School();
            Assert.IsNotNull(testSchool.Students);
        }

        [TestMethod]
        public void SchoolInstanceInitializedWithNonNullCoursesList()
        {
            School testSchool = new School();
            Assert.IsNotNull(testSchool.Courses);
        }

        [TestMethod]
        public void IdCounterSetInitiallyToMinPossible()
        {
            School testSchool = new School();
            Assert.AreEqual(testSchool.IdCounter, School.ID_NUMBER_MINIMAL_VALUE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IdCounterDoesntExceedMaxCounter()
        {
            School testSchool = new School();
            int totalAssignableIds = School.ID_NUMBER_MAXIMAL_VALUE - School.ID_NUMBER_MINIMAL_VALUE;
            for (int i = 0; i <= totalAssignableIds; i++)
            {
                testSchool.AddStudent("name");
            }

            Assert.AreEqual(testSchool.IdCounter, School.ID_NUMBER_MAXIMAL_VALUE);
        }
    }
}
