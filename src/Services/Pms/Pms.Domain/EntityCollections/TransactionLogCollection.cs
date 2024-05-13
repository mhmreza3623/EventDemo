using DataBase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Domain.EntityCollections
{
    public class TransactionLogCollection : MongoBaseEntity
    {
        public decimal Amount { get; set; }
        public string SourceAccount { get; set; }
        public string DistinationAccount { get; set; }
    }
}
