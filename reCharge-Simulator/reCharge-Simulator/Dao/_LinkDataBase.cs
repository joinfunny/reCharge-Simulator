using System;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AutoSend 
{
	
	
	#region 普通OleDb 数据库连接类
	/// <summary>
	/// 普通OleDb 数据库连接类
	/// </summary>
	#endregion
	public class DataBase
	{
        public DataBase()
        {
            this.oleConnection = new OleDbConnection();
            this.nCommandTimeout = 30;
            this.oleCommand = null;

        }
		public DataBase(string strConnectionString)
		{
            try
            {
                this.oleConnection = new OleDbConnection();
                this.nCommandTimeout = 30;
                this.oleCommand = null;
                this.Open(strConnectionString);
            }
            catch
            {
               MessageBox.Show ("请检查与数据库的连接！");
            }
		}

			
			
		#region 重新设置数据库
		/// <summary>
		/// 重新设置数据库
		/// </summary>
		/// <param name="strDatabase">数据库连接串</param>
		#endregion
		public void Use(string strDatabase)
		{
			this.oleConnection.ChangeDatabase(strDatabase);
		}
		#region 打开数据库连接
		/// <summary>
		/// 打开数据库连接
		/// </summary>
		/// <param name="strConnectionString"></param>
		#endregion
		public void Open(string strConnectionString)
		{
			this.oleConnection.ConnectionString = strConnectionString;
			this.oleConnection.Open();
		}

		#region 关闭数据库连接
		/// <summary>
		/// 关闭数据库连接
		/// </summary>
		#endregion
		public void Close()
		{
			this.oleConnection.Close();
		}


		public virtual void Prepare(string strSQLCommand, params OleDbParameter[] oleParams)
		{
			this.oleCommand = this.oleConnection.CreateCommand();
			this.oleCommand.CommandTimeout = this.nCommandTimeout;
			this.oleCommand.CommandText = strSQLCommand;
			foreach (OleDbParameter parameter1 in oleParams)
			{
				this.oleCommand.Parameters.Add(parameter1);
			}
		}

		#region 执行SQL 返回影响的行数
		/// <summary>
		/// 执行SQL 返回影响的行数
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual int ExecSQLNonQuery(params object[] objData)
		{
			for (int num1 = 0; num1 < objData.Length; num1++)
			{
				this.oleCommand.Parameters[num1].Value = objData[num1];
			}
			return this.oleCommand.ExecuteNonQuery();
		}

		#region 执行SQL 返回影响的行数
		/// <summary>
		/// 执行SQL 返回影响的行数
		/// </summary>
		/// <param name="strSQLCommand"></param>
		/// <returns></returns>
		#endregion
		public virtual int ExecSQLNonQueryDirect(string strSQLCommand)
		{
			this.oleCommand = this.oleConnection.CreateCommand();
			this.oleCommand.CommandTimeout = this.nCommandTimeout;
			this.oleCommand.CommandText = strSQLCommand;
			return this.oleCommand.ExecuteNonQuery();
		}

		#region 返回一个对象
		/// <summary>
		/// 返回一个对象
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual object ExecSQLScalar(params object[] objData)
		{
			for (int num1 = 0; num1 < objData.Length; num1++)
			{
				this.oleCommand.Parameters[num1].Value = objData[num1];
			}
			return this.oleCommand.ExecuteScalar();
		}

		#region 返回一个对象
		/// <summary>
		/// 返回一个对象
		/// </summary>
		/// <param name="strSQLCommand"></param>
		/// <returns></returns>
		#endregion
		public virtual object ExecSQLScalarDirect(string strSQLCommand)
		{
			this.oleCommand = this.oleConnection.CreateCommand();
			this.oleCommand.CommandTimeout = this.nCommandTimeout;
			this.oleCommand.CommandText = strSQLCommand;
			return this.oleCommand.ExecuteScalar();
		}


		#region 通过匹配SQL 来得到一个数据集
		/// <summary>
		/// 通过匹配SQL 来得到一个数据集
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual DataSet ExecSQLSet(params object[] objData)
		{
			for (int num1 = 0; num1 < objData.Length; num1++)
			{
				this.oleCommand.Parameters[num1].Value = objData[num1];
			}
			DataSet set1 = new DataSet();
			new OleDbDataAdapter(this.oleCommand).Fill(set1);
			return set1;
		}
 
		#region 通过直接查询返回一个数据集 
		/// <summary>
		/// 通过直接查询返回一个数据集
		/// </summary>
		/// <param name="strSQLCommand"></param>
		/// <returns></returns>
		#endregion
		public virtual DataSet ExecSQLSetDirect(string strSQLCommand)
		{
			this.oleCommand = this.oleConnection.CreateCommand();
			this.oleCommand.CommandTimeout = this.nCommandTimeout;
			this.oleCommand.CommandText = strSQLCommand;
			DataSet set1 = new DataSet();
			new OleDbDataAdapter(this.oleCommand).Fill(set1);
			return set1;
		}
		public virtual DataSet ExecSQLSetDirect(string strSQLCommand,string strTableName)
		{
			this.oleCommand = this.oleConnection.CreateCommand();
			this.oleCommand.CommandTimeout = this.nCommandTimeout;
			this.oleCommand.CommandText = strSQLCommand;
			DataSet set1 = new DataSet();
			new OleDbDataAdapter(this.oleCommand).Fill(set1,strTableName);
			return set1;
		}

		#region 通过匹配SQL 来得到一个表
		/// <summary>
		/// 通过匹配SQL 来得到一个表
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual DataTable ExecSQLTable(params object[] objData)
		{
			for (int num1 = 0; num1 < objData.Length; num1++)
			{
				this.oleCommand.Parameters[num1].Value = objData[num1];
			}
			DataSet set1 = new DataSet();
			new OleDbDataAdapter(this.oleCommand).Fill(set1);
			return set1.Tables[0];
		}

		#region 通过直接查询返回一个表
		/// <summary>
		/// 通过直接查询返回一个表
		/// </summary>
		/// <param name="strSQLCommand"></param>
		/// <returns></returns>
		#endregion
		public virtual DataTable ExecSQLTableDirect(string strSQLCommand)
		{
                this.oleCommand = this.oleConnection.CreateCommand();
                this.oleCommand.CommandTimeout = this.nCommandTimeout;
                this.oleCommand.CommandText = strSQLCommand;
                DataSet set1 = new DataSet();
                new OleDbDataAdapter(this.oleCommand).Fill(set1);
                return set1.Tables[0];
        }
      
		#region 数据库的抄时时间
		/// <summary>
		/// 数据库的抄时时间
		/// </summary>
		#endregion
		public int CommandTime
		{
			get
			{
				return this.nCommandTimeout;
			}
			set
			{
				this.nCommandTimeout = value;
			}
		}
		#region 数据库的连接串
		/// <summary>
		/// 数据库的连接串
		/// </summary>
		#endregion
		public string ConnectionString
		{
			get
			{
				return this.oleConnection.ConnectionString;
			}
		} 
		#region 返回数据库的连接状态
		/// <summary>
		/// 返回数据库的连接状态
		/// </summary>
		#endregion
		public bool Opened
		{
			get
			{
				return (this.oleConnection.State == ConnectionState.Open);
			}
		}
 


		#region 超时时间
		/// <summary>
		/// 超时时间
		/// </summary>
		#endregion
		protected int nCommandTimeout;
		#region 连接串
		/// <summary>
		/// 连接串
		/// </summary>
		#endregion
		protected OleDbCommand oleCommand;
		#region 数据库连接
		/// <summary>
		/// 数据库连接
		/// </summary>
		#endregion
		protected OleDbConnection oleConnection;

        //--------------------------一些常用的工具------------------------------//
        #region　查询指定表的指定列的值个数
        /// <summary>
        /// 查询指定表的指定列的值的个数
        /// </summary>
        /// <param name="strTableName">指定的表名</param>
        /// <param name="strKey">列名</param>
        /// <param name="strValue">值</param>
        /// <returns>查询出的个数</returns>
        #endregion
        public int IsValueExsits(String strTableName, String strKey, String strValue)
        {
            String sql = String.Format("SELECT COUNT(*) FROM  {0} WHERE {1}='{2}'", strTableName, strKey, strValue);
            return (int)this.ExecSQLScalarDirect(sql);
        }
        #region 修改时查询指定列的指定值是否存在，不包括本列
        /// <summary>
        /// 修改时查询指定列的指定值是否存在，不包括本列
        /// </summary>
        /// <param name="strTableName">表名</param>
        /// <param name="strKey">需要查询的列</param>
        /// <param name="strValue">需要查询的值</param>
        /// <param name="strPrimaryKey">主键列列名</param>
        /// <param name="strPrimaryKeyValue">主键列值</param>
        /// <returns></returns>
        #endregion
        public int IsValueExsits_Modify(String strTableName, String strKey, String strValue, String strPrimaryKey, String strPrimaryKeyValue)
        {
            String sql = String.Format("SELECT COUNT(*) FROM  {0} WHERE {1}='{2}' AND {3} != '{4}'", strTableName, strKey, strValue,strPrimaryKey ,strPrimaryKeyValue);
            return (int)this.ExecSQLScalarDirect(sql);
        }

        #region 自动获取编号
        /// <summary>
        /// 自动获取编号
		/// </summary>
		#endregion
        public String SelectCode(string strTableName, int iRow)
        {
            try
            {
                string strNewCode = "";
                string strSQL = "SELECT * FROM " + strTableName;
                DataTable dt = this.ExecSQLTableDirect(strSQL);
                if (dt.Rows.Count == 0)
                {
                    return "1";
                }
                if (Convert.ToInt32(dt.Rows[0][iRow].ToString()) > 1)
                {
                    return "1";
                }
                if (dt.Rows.Count == 1)
                {
                    return Convert.ToString(Convert.ToInt32(dt.Rows[0][iRow].ToString()) + 1);
                }
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i + 1][iRow].ToString()) - Convert.ToInt32(dt.Rows[i][iRow].ToString()) >= 2)
                    {
                        return Convert.ToString(Convert.ToInt32(dt.Rows[i][iRow].ToString()) + 1);
                        
                    }
                    strNewCode = Convert.ToString(Convert.ToInt32(dt.Rows[i + 1][iRow].ToString()) + 1);
                }
                return strNewCode;
            }
            catch
            {
                return "";
            }
        }

	}

	#region 可以带事务的数据库连接类
	/// <summary>
	/// 可以带事务的数据库连接类
	/// </summary>
	#endregion
	public class TDataBaseWithTransaction : DataBase
	{

        public TDataBaseWithTransaction()
        {
            this.oleTransaction = null;
        }
 
		public TDataBaseWithTransaction(string strConnectionString) : base(strConnectionString)
		{
			this.oleTransaction = null;
		}

			
		#region 事务
		/// <summary>
		/// 事务
		/// </summary>
		#endregion
		protected OleDbTransaction oleTransaction;

		#region 打开事务
		/// <summary>
		/// 打开事务
		/// </summary>
		#endregion
		public void Begin()
		{
			this.oleTransaction = base.oleConnection.BeginTransaction(IsolationLevel.RepeatableRead);
		}

		#region 以特定的事务级别打开事务
		/// <summary>
		/// 以特定的事务级别打开事务
		/// </summary>
		/// <param name="isolationLevel"></param>
		#endregion
		public void Begin(IsolationLevel isolationLevel)
		{
			this.oleTransaction = base.oleConnection.BeginTransaction(isolationLevel);
		}
		#region 提交事务
		/// <summary>
		/// 提交事务
		/// </summary>
		#endregion
		public void Commit()
		{
			this.oleTransaction.Commit();
		}
		#region 回滚事务
		/// <summary>
		/// 回滚事务
		/// </summary>
		#endregion 
		public void Rollback()
		{
			this.oleTransaction.Rollback();
		}

		#region 执行SQL 返回影响的行数
		/// <summary>
		/// 执行SQL 返回影响的行数
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual int TExecSQLNonQuery(params object[] objData)
		{
			return this.ExecSQLNonQuery(objData);
		}

		#region 执行SQL 返回影响的行数
		/// <summary>
		/// 执行SQL 返回影响的行数
		/// </summary>			
		/// <returns></returns>
		#endregion
		public virtual int TExecSQLNonQueryDirect(string strSQLCommand)
		{
			base.oleCommand = base.oleConnection.CreateCommand();
			base.oleCommand.CommandTimeout = base.nCommandTimeout;
			base.oleCommand.Transaction = this.oleTransaction;
			base.oleCommand.CommandText = strSQLCommand;
			return base.oleCommand.ExecuteNonQuery();
		}

		#region 返回一个对象
		/// <summary>
		/// 返回一个对象
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual object TExecSQLScalar(params object[] objData)
		{
			return this.ExecSQLScalar(objData);
		}
		#region 返回一个对象
		/// <summary>
		/// 返回一个对象
		/// </summary>			
		/// <returns></returns>
		#endregion 
		public virtual object TExecSQLScalarDirect(string strSQLCommand)
		{
			base.oleCommand = base.oleConnection.CreateCommand();
			base.oleCommand.CommandTimeout = base.nCommandTimeout;
			base.oleCommand.Transaction = this.oleTransaction;
			base.oleCommand.CommandText = strSQLCommand;
			return base.oleCommand.ExecuteScalar();
		}

		#region 通过匹配SQL 来得到一个数据集
		/// <summary>
		/// 通过匹配SQL 来得到一个数据集
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual DataSet TExecSQLSet(params object[] objData)
		{
			return this.ExecSQLSet(objData);
		}

		#region 通过直接查询返回一个数据集 
		/// <summary>
		/// 通过直接查询返回一个数据集
		/// </summary>
		/// <param name="strSQLCommand"></param>
		/// <returns></returns>
		#endregion
		public virtual DataSet TExecSQLSetDirect(string strSQLCommand)
		{
			base.oleCommand = base.oleConnection.CreateCommand();
			base.oleCommand.CommandTimeout = base.nCommandTimeout;
			base.oleCommand.Transaction = this.oleTransaction;
			base.oleCommand.CommandText = strSQLCommand;
			DataSet set1 = new DataSet();
			new OleDbDataAdapter(base.oleCommand).Fill(set1);
			return set1;
		}
		public virtual DataSet TExecSQLSetDirect(string strSQLCommand,string strTableName)
		{
			base.oleCommand = base.oleConnection.CreateCommand();
			base.oleCommand.CommandTimeout = base.nCommandTimeout;
			base.oleCommand.Transaction = this.oleTransaction;
			base.oleCommand.CommandText = strSQLCommand;
			DataSet set1 = new DataSet();
			new OleDbDataAdapter(base.oleCommand).Fill(set1,strTableName);
			return set1;
		}
		#region 通过匹配SQL 来得到一个表
		/// <summary>
		/// 通过匹配SQL 来得到一个表
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual DataTable TExecSQLTable(params object[] objData)
		{
			return this.ExecSQLTable(objData);
		}

		#region 通过直接查询返回一个表
		/// <summary>
		/// 通过直接查询返回一个表
		/// </summary>
		/// <param name="strSQLCommand"></param>
		/// <returns></returns>
		#endregion
		public virtual DataTable TExecSQLTableDirect(string strSQLCommand)
		{
			base.oleCommand = base.oleConnection.CreateCommand();
			base.oleCommand.CommandTimeout = base.nCommandTimeout;
			base.oleCommand.Transaction = this.oleTransaction;
			base.oleCommand.CommandText = strSQLCommand;
			DataSet set1 = new DataSet();
			new OleDbDataAdapter(base.oleCommand).Fill(set1);
			return set1.Tables[0];
		}

 
		public virtual void TPrepare(string strSQLCommand, params OleDbParameter[] oleParams)
		{
			base.oleCommand = base.oleConnection.CreateCommand();
			base.oleCommand.CommandTimeout = base.nCommandTimeout;
			base.oleCommand.Transaction = this.oleTransaction;
			base.oleCommand.CommandText = strSQLCommand;
			foreach (OleDbParameter parameter1 in oleParams)
			{
				base.oleCommand.Parameters.Add(parameter1);
			}
		}

        //--------------------------以下是一些常用的工具----------------------------------//
        public DateTime GetServerTime()
        {
            String strSQL = "SELECT GETDATE() ";
            return Convert.ToDateTime(this.ExecSQLScalarDirect(strSQL));
        }

	}
}
	


