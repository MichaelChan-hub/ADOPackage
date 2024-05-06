using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    /// <summary>
    /// 封装CreateSql方法中执行生成的Sql语句和参数数组
    /// </summary>
    public class SqlModel
    {
        public string Sql { get; set; }
        public SqlParameter[] Paras { get; set; }
    }
}
