using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS;

namespace DATA
{
    public class StudentsContext : DbContext
    {
        public IDbSet<Person> Power { get; set; }
    }
}
