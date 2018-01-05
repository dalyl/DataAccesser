using DataAccesser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesser.MSSQL
{
    public class MSSQLBulider : ISQLBulider
    {
        object Entity { get; set; }
        TableStruct Struct { get; set; }

        public MSSQLBulider(object entity, TableStruct table)
        {
            Entity = entity;
            Struct = table;
        }

        public string GetInsertText()
        {
            var colbulider = new StringBuilder();
            var colvbulider = new StringBuilder();

            foreach (var col in Struct.Columns)
            {
                if (col.Identity == false)
                {
                    colbulider.Append($" {col.Name},");
                    colvbulider.Append($" @{col.Name},");
                }
            }

            return $" insert into [{Struct.TableSchema}].[{ Struct.TableName }] ( { colbulider.ToString().TrimEnd(',')}) values ( {  colvbulider.ToString().TrimEnd(',') } ) ";
        }


    }
}
