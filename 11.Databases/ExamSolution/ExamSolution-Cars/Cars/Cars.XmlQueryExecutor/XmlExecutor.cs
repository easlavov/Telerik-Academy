namespace Cars.XmlQueryExecutor
{
    using System;
    using System.Linq;
    using Cars.Data;

    public class XmlExecutor
    {
        private string xmlPath;
        private CarsDataContext context;

        public XmlExecutor(string path, CarsDataContext context)
        {
            this.xmlPath = path;
            this.context = context;
        }

        public void Execute()
        {
            
        }
    }
}
