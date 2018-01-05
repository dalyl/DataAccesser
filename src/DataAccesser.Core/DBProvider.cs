using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesser.Core
{

 

    /// <summary>
    /// 基于 Dapper  进行数据访问操作的封装
    /// </summary>
    public abstract class DBProvider  
    {
        /// <summary>
        /// 获取数据服务名称
        /// </summary>
        public static  Func<string> GetConnectionString { get; set; }
        
        DbConnection CreateConnection()
        {
            if (GetConnectionString == null) throw (new Exception($" {nameof(DBProvider)} 配置不正确" ));
            var conString =  GetConnectionString();
            return new SqlConnection(conString);
        }


        public void Add<T>(T model) where T: EntityBase<T>
        {
            var cmdText= model.Bulider.GetInsertText();
            using (var con = CreateConnection())
            {
               // var result = con.Execute(cmdText,model);
            }
        }
 

    }

 
}
