namespace SchoolTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfStudentNameIsNull()
        {
            string testName = null;
            int testId = 0;
            Student student = new Student(testName, testId);
            Assert.IsNotNull(student.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfStudentNameIsEmpty()
        {
            string testName = string.Empty;
            int testId = 0;
            Student student = new Student(testName, testId);
            Assert.AreNotEqual(student.Name, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfStudentNameCanBeSetToNull()
        {
            string testName = string.Empty;
            int testId = 0;
            Student student = new Student(testName, testId);
            student.Name = null;
            Assert.AreNotEqual(student.Name, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfStudentNameCanBeSetToEmpty()
        {
            string testName = string.Empty;
            int testId = 0;
            Student student = new Student(testName, testId);
            student.Name = string.Empty;
            Assert.AreNotEqual(student.Name, string.Empty);
        }

        [TestMethod]
        public void TestIfStudentNameIsSetCorrectly()
        {
            string testName = "TestName";
            int testId = 0;
            Student student = new Student(testName, testId);
            string newName = "NewTestName";
            student.Name = newName;
            Assert.AreEqual(student.Name, newName);
        }

        [TestMethod]
        public void TestIfStudentIdIsSetCorrectly()
        {
            string testName = "TestName";
            int testId = 500;
            Student student = new Student(testName, testId);
            Assert.AreEqual(student.Id, testId);
        }
    }
}
