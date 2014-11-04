using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONTest
{
    class Program
    {
        static void Main(string[] args)
        {
            object p = new
            {
                Name = "Pesho",
                Age = 20,
                Grades = new int[]
                {
                    1,4,5,6
                }
            };

            var ser = JsonConvert.SerializeObject(p);
            Console.WriteLine(ser);

            var deser = JsonConvert.DeserializeObject<object>(ser);
            Console.WriteLine(deser);
        }
    }
}
