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
	
	
	#region ��ͨOleDb ���ݿ�������
	/// <summary>
	/// ��ͨOleDb ���ݿ�������
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
               MessageBox.Show ("���������ݿ�����ӣ�");
            }
		}

			
			
		#region �����������ݿ�
		/// <summary>
		/// �����������ݿ�
		/// </summary>
		/// <param name="strDatabase">���ݿ����Ӵ�</param>
		#endregion
		public void Use(string strDatabase)
		{
			this.oleConnection.ChangeDatabase(strDatabase);
		}
		#region �����ݿ�����
		/// <summary>
		/// �����ݿ�����
		/// </summary>
		/// <param name="strConnectionString"></param>
		#endregion
		public void Open(string strConnectionString)
		{
			this.oleConnection.ConnectionString = strConnectionString;
			this.oleConnection.Open();
		}

		#region �ر����ݿ�����
		/// <summary>
		/// �ر����ݿ�����
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

		#region ִ��SQL ����Ӱ�������
		/// <summary>
		/// ִ��SQL ����Ӱ�������
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

		#region ִ��SQL ����Ӱ�������
		/// <summary>
		/// ִ��SQL ����Ӱ�������
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

		#region ����һ������
		/// <summary>
		/// ����һ������
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

		#region ����һ������
		/// <summary>
		/// ����һ������
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


		#region ͨ��ƥ��SQL ���õ�һ�����ݼ�
		/// <summary>
		/// ͨ��ƥ��SQL ���õ�һ�����ݼ�
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
 
		#region ͨ��ֱ�Ӳ�ѯ����һ�����ݼ� 
		/// <summary>
		/// ͨ��ֱ�Ӳ�ѯ����һ�����ݼ�
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

		#region ͨ��ƥ��SQL ���õ�һ����
		/// <summary>
		/// ͨ��ƥ��SQL ���õ�һ����
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

		#region ͨ��ֱ�Ӳ�ѯ����һ����
		/// <summary>
		/// ͨ��ֱ�Ӳ�ѯ����һ����
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
      
		#region ���ݿ�ĳ�ʱʱ��
		/// <summary>
		/// ���ݿ�ĳ�ʱʱ��
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
		#region ���ݿ�����Ӵ�
		/// <summary>
		/// ���ݿ�����Ӵ�
		/// </summary>
		#endregion
		public string ConnectionString
		{
			get
			{
				return this.oleConnection.ConnectionString;
			}
		} 
		#region �������ݿ������״̬
		/// <summary>
		/// �������ݿ������״̬
		/// </summary>
		#endregion
		public bool Opened
		{
			get
			{
				return (this.oleConnection.State == ConnectionState.Open);
			}
		}
 


		#region ��ʱʱ��
		/// <summary>
		/// ��ʱʱ��
		/// </summary>
		#endregion
		protected int nCommandTimeout;
		#region ���Ӵ�
		/// <summary>
		/// ���Ӵ�
		/// </summary>
		#endregion
		protected OleDbCommand oleCommand;
		#region ���ݿ�����
		/// <summary>
		/// ���ݿ�����
		/// </summary>
		#endregion
		protected OleDbConnection oleConnection;

        //--------------------------һЩ���õĹ���------------------------------//
        #region����ѯָ�����ָ���е�ֵ����
        /// <summary>
        /// ��ѯָ�����ָ���е�ֵ�ĸ���
        /// </summary>
        /// <param name="strTableName">ָ���ı���</param>
        /// <param name="strKey">����</param>
        /// <param name="strValue">ֵ</param>
        /// <returns>��ѯ���ĸ���</returns>
        #endregion
        public int IsValueExsits(String strTableName, String strKey, String strValue)
        {
            String sql = String.Format("SELECT COUNT(*) FROM  {0} WHERE {1}='{2}'", strTableName, strKey, strValue);
            return (int)this.ExecSQLScalarDirect(sql);
        }
        #region �޸�ʱ��ѯָ���е�ָ��ֵ�Ƿ���ڣ�����������
        /// <summary>
        /// �޸�ʱ��ѯָ���е�ָ��ֵ�Ƿ���ڣ�����������
        /// </summary>
        /// <param name="strTableName">����</param>
        /// <param name="strKey">��Ҫ��ѯ����</param>
        /// <param name="strValue">��Ҫ��ѯ��ֵ</param>
        /// <param name="strPrimaryKey">����������</param>
        /// <param name="strPrimaryKeyValue">������ֵ</param>
        /// <returns></returns>
        #endregion
        public int IsValueExsits_Modify(String strTableName, String strKey, String strValue, String strPrimaryKey, String strPrimaryKeyValue)
        {
            String sql = String.Format("SELECT COUNT(*) FROM  {0} WHERE {1}='{2}' AND {3} != '{4}'", strTableName, strKey, strValue,strPrimaryKey ,strPrimaryKeyValue);
            return (int)this.ExecSQLScalarDirect(sql);
        }

        #region �Զ���ȡ���
        /// <summary>
        /// �Զ���ȡ���
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

	#region ���Դ���������ݿ�������
	/// <summary>
	/// ���Դ���������ݿ�������
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

			
		#region ����
		/// <summary>
		/// ����
		/// </summary>
		#endregion
		protected OleDbTransaction oleTransaction;

		#region ������
		/// <summary>
		/// ������
		/// </summary>
		#endregion
		public void Begin()
		{
			this.oleTransaction = base.oleConnection.BeginTransaction(IsolationLevel.RepeatableRead);
		}

		#region ���ض������񼶱������
		/// <summary>
		/// ���ض������񼶱������
		/// </summary>
		/// <param name="isolationLevel"></param>
		#endregion
		public void Begin(IsolationLevel isolationLevel)
		{
			this.oleTransaction = base.oleConnection.BeginTransaction(isolationLevel);
		}
		#region �ύ����
		/// <summary>
		/// �ύ����
		/// </summary>
		#endregion
		public void Commit()
		{
			this.oleTransaction.Commit();
		}
		#region �ع�����
		/// <summary>
		/// �ع�����
		/// </summary>
		#endregion 
		public void Rollback()
		{
			this.oleTransaction.Rollback();
		}

		#region ִ��SQL ����Ӱ�������
		/// <summary>
		/// ִ��SQL ����Ӱ�������
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual int TExecSQLNonQuery(params object[] objData)
		{
			return this.ExecSQLNonQuery(objData);
		}

		#region ִ��SQL ����Ӱ�������
		/// <summary>
		/// ִ��SQL ����Ӱ�������
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

		#region ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual object TExecSQLScalar(params object[] objData)
		{
			return this.ExecSQLScalar(objData);
		}
		#region ����һ������
		/// <summary>
		/// ����һ������
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

		#region ͨ��ƥ��SQL ���õ�һ�����ݼ�
		/// <summary>
		/// ͨ��ƥ��SQL ���õ�һ�����ݼ�
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual DataSet TExecSQLSet(params object[] objData)
		{
			return this.ExecSQLSet(objData);
		}

		#region ͨ��ֱ�Ӳ�ѯ����һ�����ݼ� 
		/// <summary>
		/// ͨ��ֱ�Ӳ�ѯ����һ�����ݼ�
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
		#region ͨ��ƥ��SQL ���õ�һ����
		/// <summary>
		/// ͨ��ƥ��SQL ���õ�һ����
		/// </summary>
		/// <param name="objData"></param>
		/// <returns></returns>
		#endregion
		public virtual DataTable TExecSQLTable(params object[] objData)
		{
			return this.ExecSQLTable(objData);
		}

		#region ͨ��ֱ�Ӳ�ѯ����һ����
		/// <summary>
		/// ͨ��ֱ�Ӳ�ѯ����һ����
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

        //--------------------------������һЩ���õĹ���----------------------------------//
        public DateTime GetServerTime()
        {
            String strSQL = "SELECT GETDATE() ";
            return Convert.ToDateTime(this.ExecSQLScalarDirect(strSQL));
        }

	}
}
	


