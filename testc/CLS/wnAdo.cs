// Decompiled with JetBrains decompiler
// Type: smartMain.CLS.wnAdo
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.Data;
using System.Data.SqlClient;

namespace smartMain.CLS
{
    public class wnAdo
    {
        public DataTable SqlCommandSelect(SqlCommand sCommand, string sConn)
        {
            SqlConnection sqlConnection = new SqlConnection(sConn);
            try
            {
                sCommand.Connection = sqlConnection;
                sqlConnection.Open();
                wnLog.writeLog(301, sCommand.CommandText);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sCommand;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                wnLog.writeLog(301, dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                return (DataTable)null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int SqlCommandEtc(SqlCommand sCommand, string wQuery, string sConn)
        {
            SqlConnection sqlConnection = new SqlConnection(sConn);
            SqlTransaction sqlTransaction = (SqlTransaction)null;
            try
            {
                sCommand.Connection = sqlConnection;
                sqlConnection.Open();
                wnLog.writeLog(301, sCommand.CommandText);
                sqlTransaction = sqlConnection.BeginTransaction();
                sCommand.Transaction = sqlTransaction;
                int num = sCommand.ExecuteNonQuery();
                if (num > 0)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();
                wnLog.writeLog(301, wQuery + "-" + (object)num);
                return num;
            }
            catch (Exception ex)
            {
                if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                {
                    sqlTransaction?.Rollback();
                    sqlConnection.Close();
                }
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
