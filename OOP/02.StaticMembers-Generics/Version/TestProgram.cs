// Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version
// in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

using System;

namespace Version
{
    class TestProgram
    {
        static void Main()
        {
            // Print version of SampleClass
            Type type = typeof(SampleClass);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (object attr in attributes)
            {
                VersionAttribute attrib = (VersionAttribute)attr;
                Console.WriteLine("The {0} class version is {1}",type.Name , attrib.Version);
            }
        }
    }
}
