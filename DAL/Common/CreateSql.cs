using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common;
using System.Reflection;

namespace DAL.Common
{   

    /// <summary>
    /// 封装生成Sql语句和参数的相关方法方法
    /// </summary>
    public class CreateSql
    {   


        /// <summary>
        /// 创建插入语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体类实例</param>
        /// <param name="cols">插入语句必要的列名字符串</param>
        /// <param name="isReturn">1为返回主键值，0为只生成insert语句</param>
        /// <returns></returns>
        public static SqlModel CreateInsertSql<T>(T model,string cols,int isReturn)
        {
            string sql = "";
            Type type = typeof(T);
            string tableName = type.GetTName();
            string primaryKey = type.GetPKName();
            PropertyInfo[] properties = null;
            if (cols.Contains(primaryKey))
            {
                if (type.IsAutoIncrement())
                {
                    cols = cols.RemoveSubStr(primaryKey);
                }
            }
            else
            {
                if (!type.IsAutoIncrement())
                {
                    throw new Exception("主键非自增且主键列为空");
                }
            }
            properties = PropertyHelper.GetProperties<T>(cols);
            string strCols = string.Join(",", properties.Select(p => p.GetColName()));
            string paraCols = string.Join(",", properties.Select(p => $"@{p.Name}"));
            sql = $"insert into [{tableName}] ({strCols}) values ({paraCols})";
            if (isReturn == 1)
                sql += ";select @@identity;";

            //参数数组生成
            SqlParameter[] paras = properties.Select(p => new SqlParameter("@" + p.Name, p.GetValue(model) ?? DBNull.Value)).ToArray();
            return new SqlModel() { Sql = sql, Paras = paras };
        }
    }
}
