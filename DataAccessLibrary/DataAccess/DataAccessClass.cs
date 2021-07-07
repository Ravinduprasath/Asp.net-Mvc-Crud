using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccessLibrary.DataAccess
{
    public static class DataAccessClass
    {
        public static string GetCon()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection con = new SqlConnection(GetCon()))
            {
                return con.Query<T>(sql).ToList();
            }
        }


        //For Insert, Update and Delete use this method
        public static void SaveData<T>(string sql, T data)
        {
            using (IDbConnection con = new SqlConnection(GetCon()))
            {
                con.Execute(sql, data);
            }
        }
    }
}
