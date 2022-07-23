using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11.DataAccess
{
    internal class RoomDAO
    {
        public void AddRoom(string title, int square, int floor, string description, string comment)
        {
            string sql = "insert into Rooms values (@title, @square, @floor, @description, @comment)";
            SqlParameter parameter1 = new SqlParameter("@title", DbType.String);
            parameter1.Value = title;
            SqlParameter parameter2 = new SqlParameter("@square", DbType.String);
            parameter2.Value = square;
            SqlParameter parameter3 = new SqlParameter("@floor", DbType.Int32);
            parameter3.Value = floor;
            SqlParameter parameter4 = new SqlParameter("@description", DbType.Int32);
            parameter4.Value = description;
            SqlParameter parameter5 = new SqlParameter("@comment", DbType.Int32);
            parameter5.Value = comment;
            DAO.ExecuteSql(sql, parameter1, parameter2, parameter3, parameter4, parameter5);
        }
    }
}
