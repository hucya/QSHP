using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace QSHP
{
    public static class LogHelper
    {
        static object locker = new object();
        static OleDbConnection DbCn;
        static DateTime recordTime = DateTime.Now;
        static string formName = recordTime.ToString("yyyyMMdd");
        public static void WriteDebugMessage(string s)
        {
            //Trace.WriteLine(s);
        }
        public static void CloseLogerConnect()
        {
            if (DbCn != null)
            {
                DbCn.Close();
                DbCn.Dispose();
            }
        }
        public static void ConnectLogerDataBase(string path)
        {
            string cnPath = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=True;Jet OLEDB:Database Password=qshp", path);
            DbCn = new OleDbConnection(cnPath);
            DbCn.Open();
            formName = DateTime.Now.ToString("yyyyMMdd");
            using (OleDbCommand cmd = DbCn.CreateCommand())
            {
                try
                {
                    cmd.CommandText = "select * from  TableNames";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("找不到")|| ex.Message.Contains("Find"))
                    {
                        ExecuteSQLCommand("CREATE TABLE [TableNames] ([NAME] varchar(20),[TIME] TIME)");
                    }
                }
                try
                {
                    cmd.CommandText = string.Format("select * from  {0}", formName);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("找不到"))
                    {
                        CreateNewLogerTable(formName);
                        ExecuteSQLCommand(string.Format("insert into TableNames ([NAME],[TIME]) values('{0}',Date())", formName));
                    }
                }
            }
        }

        public static bool ExecuteSQLCommand(string cmdText)
        {
            try
            {
                if (DbCn.State == ConnectionState.Closed)
                {
                    DbCn.Open();
                }
                using (OleDbCommand cmd = DbCn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch
            {
                
                return false;
            }
        }

        public static bool DeleteLogerTable(string tableName)
        {
            bool flag= ExecuteSQLCommand(string.Format("DELETE FROM TableNames WHERE NAME='{0}'", tableName));
            flag &= ExecuteSQLCommand(string.Format("DROP TABLE {0}", tableName));
            return flag;
        }

        public static bool CreateNewLogerTable(string tableName)
        {
            string cmdText = string.Format("CREATE TABLE [{0}] ([NUM] AUTOINCREMENT, [CMD] varchar(5),[TIME] TIME)", tableName);
            try
            {
                using (OleDbCommand cmd = DbCn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                WriteDebugMessage(ex.Message);
                return false;
            }
        }

        public static List<string> GetTableNames()
        {
            List<string> tables = new List<string>();
            try
            {
                if (DbCn.State == ConnectionState.Closed)
                {
                    DbCn.Open();
                }
                using (OleDbCommand cmd = DbCn.CreateCommand())
                {
                    cmd.CommandText = "SELECT NAME FROM TABLENAMES ORDER BY NAME DESC";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tables.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return tables;
        }

        public static List<CmdOles> GetLogerTable(string tabName)
        {
            List<CmdOles> dt = new List<CmdOles>();
            try
            {
                if (DbCn.State == ConnectionState.Closed)
                {
                    DbCn.Open();
                }
                using (OleDbCommand cmd = DbCn.CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT [NUM],[CMD],[TIME] FROM [{0}] ORDER BY NUM DESC", tabName);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CmdOles cmdOles = new CmdOles();
                                cmdOles.Index = reader.GetInt32(0);
                                cmdOles.Time = reader.GetDateTime(2);
                                CmdKey key;
                                if (Enum.TryParse(reader.GetString(1), out key))
                                {
                                    cmdOles.Value = Globals.SysCmd[key];
                                    dt.Add(cmdOles);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return dt;
        }

        public static bool AddNewLogerMessage(CmdKey key)
        {
            try
            {
                DateTime t = DateTime.Now;
                if (recordTime.Date != t)
                {
                    string name = DateTime.Now.Date.ToString("yyyyMMdd");
                    CreateNewLogerTable(name);
                    recordTime = t;
                    formName = name;
                }
                return ExecuteSQLCommand(string.Format("insert into {0} ([CMD],[TIME]) values('{1}',Time$())", formName, key.ToString()));//添加数据
            }
            catch
            {
                return false;
            }
        }

        public static void WriteDebugException(Exception ex)
        {
            Common.ReportCmdKeyProgress(CmdKey.S0091);
        }

        public static void AutoDeleteLogTable()
        {
            try
            {
                if (Globals.MacData.LogDropMode != 2)
                {
                    return;
                }
                int month = 1;
                switch (Globals.MacData.LogDropTime)
                {
                    case 0:
                        {
                            month = 1;
                        }
                        break;
                    case 1:
                        {
                            month = 3;
                        }
                        break;
                    case 2:
                        {
                            month = 6;
                        }
                        break;
                    case 3:
                        {
                            month = 12;
                        }
                        break;
                    default:
                        break;
                }
                using (OleDbCommand cmd = DbCn.CreateCommand())
                {
                    string date = DateTime.Now.AddMonths(-month).ToString("yyyyMM") + "32";
                    cmd.CommandText = string.Format("SELECT NAME FROM TABLENAMES WHERE(NAME < '{0}')", date);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                DeleteLogerTable(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch
            {

            }
           
        }
    }
}
