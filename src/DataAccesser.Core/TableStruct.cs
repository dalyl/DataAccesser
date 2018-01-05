using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesser.Core
{
    public struct TableStruct
    {
        public string TableName { get; set; }

        public string TableSchema { get; set; }

        public List<Column> Columns { get; set; }
    }
}
