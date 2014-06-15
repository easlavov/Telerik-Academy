using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace SchoolTest
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void StudentCountNoBiggerThanMaximumAllowed()
        {
            Course testCourse = new Course("Course");
            for (int i = 0; i <= Course.MAX_STUDENTS_COUNT; i++)
            {
                testCourse.AddStudent(new Student("name", i));
            }

            Assert.AreEqual(testCourse.Students.Count, Course.MAX_STUDENTS_COUNT);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingNonPresentStudentThrowsException()
        {
            Course testCourse = new Course("Course");
            testCourse.RemoveStudent(new Student("name", 0));
        }
    }
}
