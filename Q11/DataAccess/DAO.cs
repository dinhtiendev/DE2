
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11.DataAccess
{
    internal class DAO
    {
        public static SqlConnection GetConnection()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return new SqlConnection(config.GetConnectionString("MyConStr"));
        }

        public static DataTable GetDataBySql(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            //command.Connection = GetConnection();
            //command.CommandText = sql;
            if (parameters != null) command.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            //adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static int ExecuteSql(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            if (parameters != null || parameters.Length == 0) command.Parameters.AddRange(parameters);
            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }
    }
}
