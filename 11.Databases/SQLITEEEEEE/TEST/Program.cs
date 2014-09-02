using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MODELS;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new StudentsContext();
            Person p = new Person();
            p.Name = "Radka";
            var added = context.Power.Add(p);
            Console.WriteLine(added.ID);
            context.SaveChanges();

            foreach (var item in context.Power)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
