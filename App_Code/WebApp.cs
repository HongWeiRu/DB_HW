using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// WebApp 的摘要描述
/// </summary>
public class WebApp
{
    //private const string connStr = @"Data Source=ORCL; User Id=GROUP7;Password=number0707;";
    private const string connStr = "user id=GROUP7;password=number0707;data source=" +
     "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
     "(HOST=140.117.69.58)(PORT=1521))(CONNECT_DATA=" +
     "(SID=ORCL)))";

    //private const string connStr = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=100.100.100.100)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=myservice.com)));User Id=scott;Password=tiger;";
    public WebApp()
    {

    }

    public static object GetValue(string SqlCmd)
    {
        object result = null;
        using (OracleConnection conn = new OracleConnection(connStr))
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand(SqlCmd, conn);
            result = cmd.ExecuteScalar();
            conn.Close();
        }

        return result;
    }


    public static DataTable GetDatas(string SqlCmd)
    {
        DataTable result = new DataTable();
        using (OracleConnection conn = new OracleConnection(connStr))
        {
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter(SqlCmd, conn);
            da.Fill(result);
            da.Dispose();
            da = null;
            conn.Close();
        }

        return result;
    }

    public static int ExceCmd(string SqlCmd)
    {
        int result = 0;
        using (OracleConnection conn = new OracleConnection(connStr))
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand(SqlCmd, conn);
            result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        return result;
    }
}