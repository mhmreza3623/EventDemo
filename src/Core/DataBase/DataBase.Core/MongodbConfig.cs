using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Core
{
    public class MongodbConfig
    {
        public const string SectionName = "MongoDBConfig";

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
