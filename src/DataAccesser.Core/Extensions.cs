using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesser.Core
{

    internal static class Extensions
    {

        public static void ReadTableAttribute<T>(ref TableStruct table)
        {
            var type = typeof(T);
            var tableAttr = GetCustomAttribute<TableAttribute>(type);
            if (tableAttr == null) throw (new Exception($"{ typeof(T)} TableAttribute 属性未正确设置"));
            table.TableName = tableAttr.Name;
            table.TableSchema = string.IsNullOrEmpty(tableAttr.Schema) ? "dbo" : tableAttr.Schema;
        }

        public static A GetCustomAttribute<A>(Type type) where A : Attribute
        {
            var attrs = type.GetCustomAttributes(false);
            foreach (var attr in attrs)
            {
                if (attr.GetType() == typeof(A)) return attr as A;
            }
            return null;
        }

        public static void ReadColumns<T>(ref TableStruct table)
        {
            var type = typeof(T);
            table.Columns = new List<Column>();
            PropertyInfo[] pro = type.GetProperties();
            foreach (PropertyInfo propInfo in pro)
            {
                var colAttr = propInfo.GetCustomAttribute<ColumnAttribute>();
                if (colAttr != null)
                {
                    var key = propInfo.GetCustomAttribute<KeyAttribute>();
                    var generated = propInfo.GetCustomAttribute<DatabaseGeneratedAttribute>();
                    var col = new Column
                    {
                        Name = string.IsNullOrEmpty(colAttr.Name)? propInfo.Name: colAttr.Name,
                        TypeName = propInfo.PropertyType,
                        Primary = (key != null),
                        Identity = (generated != null && generated.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity),
                    };
                    table.Columns.Add(col);
                }
              
            }
        }

      
       
    }
 
}
