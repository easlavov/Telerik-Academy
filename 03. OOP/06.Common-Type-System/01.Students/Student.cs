// Define a class Student, which contains data about a student – first, middle and last name, SSN,
// permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration
// for the specialties, universities and faculties. Override the standard methods, inherited by  
// System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
using System;
using System.Net.Mail;

public class Student : ICloneable, IComparable<Student>
{
    // Fields
    private string firstName;
    private string middleName;
    private string lastName;

    private University university;
    private Faculty faculty;
    private Specialty specialty;

    private string permAddress;
    private int socSecNum;
    private string mobilePhone;
    private MailAddress email;

    // Constructors
    public Student(string firstName, string middleName, string lastName, int socSecNum)
        : this(firstName, middleName, lastName, University.None, Faculty.None, Specialty.None, null, socSecNum, null, null)
    {
    }

    public Student(string firstName, string middleName, string lastName, University university, Faculty faculty, Specialty specialty, string permAddress, int socSecNum, string mobilePhone, MailAddress email)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;

        this.University = university;
        this.Faculty = faculty;
        this.Specialty = specialty;

        this.PermAddress = permAddress;
        this.SocSecNum = socSecNum;
        this.MobilePhone = mobilePhone;
        this.Email = email;
    }

    // Properties
    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (value.Length < 2 || value.Length > 30)
            {
                throw new ArgumentOutOfRangeException("First name length must be between 2 and 30 characters!");
            }
            this.firstName = value;
        }
    }

    public string MiddleName
    {
        get
        {
            return this.middleName;
        }
        set
        {
            if (value.Length < 2 || value.Length > 30)
            {
                throw new ArgumentOutOfRangeException("Middle name length must be between 2 and 30 characters!");
            }
            this.middleName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (value.Length < 2 || value.Length > 30)
            {
                throw new ArgumentOutOfRangeException("Last name length must be between 2 and 30 characters!");
            }
            this.lastName = value;
        }
    }

    public University University
    {
        get
        {
            return this.university;
        }
        set
        {
            this.university = value;
        }
    }

    public Faculty Faculty
    {
        get
        {
            return this.faculty;
        }
        set
        {
            this.faculty = value;
        }
    }

    public Specialty Specialty
    {
        get
        {
            return this.specialty;
        }
        set
        {
            this.specialty = value;
        }
    }

    public string PermAddress
    {
        get
        {
            return this.permAddress;
        }
        set
        {
            if (value != null)
            {
                if (value.Length < 2 || value.Length > 30)
                {
                    throw new ArgumentOutOfRangeException("Address length must be between 5 and 50 characters!");
                }
                this.permAddress = value;
            }
            
        }
    }

    public int SocSecNum
    {
        get
        {
            return this.socSecNum;
        }
        set
        {
            if (value < 100000000 || value > 999999999)
            {
                throw new ArgumentOutOfRangeException("SSN must be 9 digits!");
            }
            this.socSecNum = value;
        }
    }

    public string MobilePhone
    {
        get
        {
            return this.mobilePhone;
        }
        set
        {
            if (value != null)
            {
                if (value.Length < 10 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException("Mobile phone number length must be between 10 and 20 characters!");
                }
                this.mobilePhone = value;
            }            
        }
    }

    public MailAddress Email
    {
        get
        {
            return this.email;
        }
        set
        {
            this.email = value;
        }
    }

    // Overrides
    public override bool Equals(object obj)
    {
        Student student = obj as Student;
        if (student == null)
        {
            return false;
        }
        // Social security number is unique
        if (!Object.Equals(this.SocSecNum, student.SocSecNum))
        {
            return false;
        }
        //if (!Object.Equals(this.FirstName, student.FirstName))
        //{
        //    return false;
        //}
        //if (!Object.Equals(this.MiddleName, student.MiddleName))
        //{
        //    return false;
        //}
        //if (!Object.Equals(this.LastName, student.LastName))
        //{
        //    return false;
        //}
        return true;
    }

    public override int GetHashCode()
    {
        return this.FirstName.GetHashCode() ^ this.socSecNum.GetHashCode();
    }

    public override string ToString()
    {
        string info = string.Format(
            "{0} {1} - {2}, {3} faculty, specialty: {4}",
            this.FirstName, this.LastName, this.University, this.Faculty, this.Specialty);
        return info;
    }

    public static bool operator ==(Student stud1, Student stud2)
    {
        return Student.Equals(stud1, stud2);
    }

    public static bool operator !=(Student stud1, Student stud2)
    {
        return !(Student.Equals(stud1, stud2));
    }

    // Implementations
    public object Clone()
    {
        return new Student(this.FirstName, this.MiddleName, this.LastName, this.University, this.Faculty, this.Specialty, this.PermAddress, this.SocSecNum, this.MobilePhone, this.Email);
    }

    public int CompareTo(Student otherStudent)
    {
        if (this.FirstName != otherStudent.FirstName)
        {
            return string.Compare(this.FirstName, otherStudent.FirstName);
        }
        if (this.MiddleName != otherStudent.MiddleName)
        {
            return string.Compare(this.MiddleName, otherStudent.MiddleName);
        }
        if (this.LastName != otherStudent.LastName)
        {
            return string.Compare(this.LastName, otherStudent.LastName);
        }
        if (this.SocSecNum != otherStudent.SocSecNum)
        {
            return this.SocSecNum.CompareTo(otherStudent.SocSecNum);
        }
        return 0;
    }
}