using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccesser.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccesser.Test
{

    /// <summary>
    /// ip 信息
    /// </summary>
    [Table("DataAccesser.Core.Test")]
    public class IpInfo : EntityBase<IpInfo>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column]
        public int ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column]
        public DateTime CreateAt { get; set; }


    }


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
