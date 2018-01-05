using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesser.Core
{
    public class EntityBase<T>
    {

        public TableStruct Struct { get; private set; }

        public ISQLBulider Bulider { get; private set; }

        public EntityBase()
        {
            Struct = GetCache();
          //  Bulider = new MSSQLBulider(this, Struct);
        }

        ConcurrentDictionary<Type, TableStruct> TableStructs = new ConcurrentDictionary<Type, TableStruct>();

        TableStruct GetCache()
        {
            var type = typeof(T);
            if (TableStructs.ContainsKey(type))
                return TableStructs[type];
            else
                return TableStructs.GetOrAdd(type,(ty)=> ReadTableStruct());
        }

        TableStruct ReadTableStruct()
        {
            var table = new TableStruct();
            Extensions.ReadTableAttribute<T>(ref table);
            Extensions.ReadColumns<T>(ref table);
            return table;
        }


      
    }
}
